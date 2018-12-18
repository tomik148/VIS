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
    class AddRecipeViewModel : BaseViewModel
    {
        private Recipe _recipe;
        private Ingredient[] _ingredients;

        public Recipe Recipe { get => _recipe; set => OnPropertyChanged(ref _recipe, value); }

        public Ingredient[] Ingredients { get => _ingredients; set => OnPropertyChanged(ref _ingredients, value); }
        
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand BackCommand { get; set; }   
        public ICommand AddIngredientCommand { get; set; }
        public AddRecipeViewModel()
        {
            SaveCommand = new Command(CreateRecipeAsync);
            BackCommand = new Command(() => MainViewModel.instance.ChangeView("ListOfRecipes"));
            DeleteCommand = new Command(() => MainViewModel.instance.ChangeView("ListOfRecipes"));
            AddIngredientCommand = new Command<Ingredient>(AddIngredient);
        }

        public AddRecipeViewModel(Recipe recipe)
        {
            this.Recipe = recipe;
            SaveCommand = new Command(UpdateRecipeAsync);
            BackCommand = new Command(() => MainViewModel.instance.ChangeView("ListOfRecipes"));
            DeleteCommand = new Command(async () => await Recipe.DeleteByIDAsync(Recipe.id));
        }

        async void CreateRecipeAsync()
        {
            await Recipe.AddAsync(Recipe);
            MainViewModel.instance.ChangeView("ListOfRecipes");
        }

        void AddIngredient(Ingredient ingredient)
        {
            if (Recipe.Ingredients == null)
                Recipe.Ingredients = new ObservableCollection<Ingredient>();
            Recipe.Ingredients.Add(ingredient);
            OnPropertyChanged("Recipe");
        }

        async void UpdateRecipeAsync()
        {
            await Recipe.UpdateByIDAsync(Recipe.id, Recipe);
        }

        public override async Task OnOpenAsync()
        {
            Recipe = new Recipe();
            Ingredients = await new Ingredient().GetAllAsync();
            SaveCommand = new Command(CreateRecipeAsync);
            DeleteCommand = new Command(() => MainViewModel.instance.ChangeView("ListOfRecipes"));
        }

        public override async Task OnOpenAsync(int id)
        {
            Recipe = await new Recipe().GetByIDAsync(id);
            Ingredients = await new Ingredient().GetAllAsync();
            SaveCommand = new Command(UpdateRecipeAsync);
            DeleteCommand = new Command(async () => await Recipe.DeleteByIDAsync(Recipe.id));
        }
    }
}

