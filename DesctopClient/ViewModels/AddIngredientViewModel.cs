using DesctopClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesctopClient.ViewModels
{
    class AddIngredientViewModel
    {
        public Ingredient Ingredient { get; set; }


        public ICommand SaveCommand { get; set; }

        public AddIngredientViewModel()
        {
            Ingredient = new Ingredient();
            SaveCommand = new Command(CreateIngredientAsync);
        }

        public AddIngredientViewModel(Ingredient ingredient)
        {
            this.Ingredient = ingredient;
            SaveCommand = new Command(UpdateIngredientAsync);
        }

        async void CreateIngredientAsync()
        {
            await Ingredient.AddAsync(Ingredient);
        }

        async void UpdateIngredientAsync()
        {
            await Ingredient.UpdateByIDAsync(Ingredient.id, Ingredient);
        }
    }
}
