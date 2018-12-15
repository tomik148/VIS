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
        public Recipe[] Recipes { get; set; }

        public ListOfRecipesViewModel()
        {
        }

        public override async Task OnOpen()
        {
            Recipes = await new Recipe().GetAllAsync();
        }
    }
}

