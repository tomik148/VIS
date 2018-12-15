using DesctopClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesctopClient.ViewModels
{
    class AddRecipeViewModel
    {
        public Recipe Recipe { get; set; }


        public ICommand SaveCommand { get; set; }

        public AddRecipeViewModel()
        {
            Recipe = new Recipe();
            SaveCommand = new Command(CreateRecipeAsync);
        }

        public AddRecipeViewModel(Recipe recipe)
        {
            this.Recipe = recipe;
            SaveCommand = new Command(UpdateRecipeAsync);
        }

        async void CreateRecipeAsync()
        {
            await Recipe.AddAsync(Recipe);
        }

        async void UpdateRecipeAsync()
        {
            await Recipe.UpdateByIDAsync(Recipe.id, Recipe);
        }
    }
}

