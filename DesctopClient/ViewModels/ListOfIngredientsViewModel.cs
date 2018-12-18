using DesctopClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesctopClient.ViewModels
{
    class ListOfIngredientsViewModel : BaseViewModel
    {
        private Ingredient[] _ingredients;

        public Ingredient[] Ingredients { get => _ingredients; set => OnPropertyChanged(ref _ingredients, value); }

        public ListOfIngredientsViewModel()
        {
        }

        public override async Task OnOpenAsync()
        {
            Ingredients = await new Ingredient().GetAllAsync();
        }

        public override Task OnOpenAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
