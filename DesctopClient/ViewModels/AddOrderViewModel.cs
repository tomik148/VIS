using DesctopClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesctopClient.ViewModels
{
    class AddOrderViewModel : BaseViewModel
    {
        private Order _order;
        private Recipe[] _recipes;

        public Order Order { get => _order; set => OnPropertyChanged(ref _order, value); }

        public Recipe[] Recipes { get => _recipes; set => OnPropertyChanged(ref _recipes, value); }

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand AddRecipeCommand { get; set; }

        public AddOrderViewModel()
        {
            Order = new Order();
            SaveCommand = new Command(CreateOrderAsync);
            DeleteCommand = new Command(() => MainViewModel.instance.ChangeView("ListOfOrders"));
            BackCommand = new Command(() => MainViewModel.instance.ChangeView("ListOfOrders"));
            AddRecipeCommand = new Command<Recipe>(AddRecipe);
        }

        public AddOrderViewModel(Order order)
        {
            this.Order = order;
            SaveCommand = new Command(UpdateOrderAsync);
            DeleteCommand = new Command(async () => await Order.DeleteByIDAsync(Order.id));
            BackCommand = new Command(() => MainViewModel.instance.ChangeView("ListOfOrders"));
            AddRecipeCommand = new Command<Recipe>(AddRecipe);
        }

        void AddRecipe(Recipe recipe)
        {
            if (Order.Recipes == null)
                Order.Recipes = new ObservableCollection<Recipe>();
            Order.Recipes.Add(recipe);
            OnPropertyChanged("Order");
        }

        async void CreateOrderAsync()
        {
            Order.DateOfOrder = DateTime.Now;
            Order.Tax = 21;
            await Order.AddAsync(Order);
            MainViewModel.instance.ChangeView("ListOfOrders");
        }

        async void UpdateOrderAsync()
        {
            await Order.UpdateByIDAsync(Order.id, Order);
        }

        public override async Task OnOpenAsync()
        {
            SaveCommand = new Command(CreateOrderAsync);
            DeleteCommand = new Command(() => MainViewModel.instance.ChangeView("ListOfOrders"));
            Recipes = await new Recipe().GetAllAsync();
        }

        public override async Task OnOpenAsync(int id)
        {
            Order = await new Order().GetByIDAsync(id);
            SaveCommand = new Command(UpdateOrderAsync);
            DeleteCommand = new Command(async () => await Order.DeleteByIDAsync(Order.id));
            Recipes = await new Recipe().GetAllAsync();
        }
    }
}
