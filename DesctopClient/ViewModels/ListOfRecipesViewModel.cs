using DesctopClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesctopClient.ViewModels
{
    class ListOfRecipesViewModel : BaseViewModel
    {
        private Recipe[] _recipes;

        public Recipe[] Recipes { get => _recipes; set => OnPropertyChanged(ref _recipes, value); }

        public ListOfRecipesViewModel()
        {
        }

        public override async Task OnOpenAsync()
        {
            Recipes = await new Recipe().GetAllAsync();
        }

        public override Task OnOpenAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

