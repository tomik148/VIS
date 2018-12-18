using DesctopClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesctopClient.ViewModels
{
    class AddIngredientViewModel : BaseViewModel
    {
        private Ingredient _ingredient;

        public Ingredient Ingredient { get => _ingredient; set => OnPropertyChanged(ref _ingredient, value); }

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand BackCommand { get; set; }

        public AddIngredientViewModel()
        {
            Ingredient = new Ingredient();
            SaveCommand = new Command(CreateIngredientAsync);
            DeleteCommand = new Command(() => MainViewModel.instance.ChangeView("ListOfIngredients"));
            BackCommand = new Command(() => MainViewModel.instance.ChangeView("ListOfIngredients"));
        }

        public AddIngredientViewModel(Ingredient ingredient)
        {
            this.Ingredient = ingredient;
            SaveCommand = new Command(UpdateIngredientAsync);
            DeleteCommand = new Command(() => MainViewModel.instance.ChangeView("ListOfIngredients"));
            BackCommand = new Command(() => MainViewModel.instance.ChangeView("ListOfIngredients"));
        }

        async void CreateIngredientAsync()
        {
            await Ingredient.AddAsync(Ingredient);
            Ingredient = null;
            MainViewModel.instance.ChangeView("ListOfIngredients");
        }

        async void UpdateIngredientAsync()
        {
            await Ingredient.UpdateByIDAsync(Ingredient.id, Ingredient);
        }

        public override Task OnOpenAsync()
        {
            SaveCommand = new Command(CreateIngredientAsync);
            DeleteCommand = new Command(() => MainViewModel.instance.ChangeView("ListOfIngredients"));
            BackCommand = new Command(() => MainViewModel.instance.ChangeView("ListOfIngredients"));
            return Task.CompletedTask;
        }

        public override async Task OnOpenAsync(int id)
        {
            Ingredient = await new Ingredient().GetByIDAsync(id);
            SaveCommand = new Command(UpdateIngredientAsync);
            DeleteCommand = new Command(async () => await Ingredient.DeleteByIDAsync(id));
            BackCommand = new Command(() => MainViewModel.instance.ChangeView("ListOfIngredients"));
        }
    }
}
