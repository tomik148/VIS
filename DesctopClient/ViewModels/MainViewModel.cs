using DesctopClient.Models;
using DesctopClient.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DesctopClient.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public UserControl Content { get => _content; set => OnPropertyChanged(ref _content, value); }

        public ICommand ChangeViewCommand { get; set; }

        static Dictionary<string, UserControl> Views;
        private UserControl _content;

        static public MainViewModel instance;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            Views = new Dictionary<string, UserControl>
            {
                { "ListOfOrders", new ListOfOrdersView() { DataContext = new ListOfOrdersViewModel() } },
                { "AddOrder", new AddOrderView() { DataContext = new AddOrderViewModel() } },
                { "ListOfIngredients", new ListOfIngredientsView() { DataContext = new ListOfIngredientsViewModel() } },
                { "AddIngredient", new AddIngredientView() { DataContext = new AddIngredientViewModel() } },
                { "ListOfRecipes", new ListOfRecipesView() { DataContext = new ListOfRecipesViewModel() } },
                { "AddRecipe", new AddRecipeView() { DataContext = new AddRecipeViewModel() } },
            };

            ChangeView("ListOfOrders");
            ChangeViewCommand = new Command<string>(ChangeView);
            instance = this;
        }


        async public void ChangeView(string nameOfView)
        {
            Content = Views[nameOfView];
            var a = (BaseViewModel)Content.DataContext;
            await a.OnOpenAsync();
        }

        protected void OnPropertyChanged<T>(ref T target, T val, [CallerMemberName]string PropertyName = "")
        {
            target = val;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
