using DesctopClient.Models;
using DesctopClient.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DesctopClient.ViewModels
{
    class MainViewModel
    {
        public UserControl Content { get; set; }

        public ICommand ChangeViewCommand { get; set; }

        static Dictionary<string, UserControl> Views;

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
        }


        async void ChangeView(string nameOfView)
        {
            Content = Views[nameOfView];
            var a = (BaseViewModel)Content.DataContext;
            await a.OnOpen();
        }
    }
}
