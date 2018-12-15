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
        public Ingredient[] Ingredients { get; set; }

        public ListOfIngredientsViewModel()
        {
        }

        public override async Task OnOpen()
        {
            Ingredients = await new Ingredient().GetAllAsync();
        }
    }
}
