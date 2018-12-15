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
    class MainViewModel : BaseViewModel
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
                { "DetailOrder", new DetailOrderView() { DataContext = new DetailOrderViewModel() } },
            };


            ChangeViewCommand = new Command<string>(ChangeView);
        }


        void ChangeView(string nameOfView)
        {
            Content = Views[nameOfView];
        }
    }
}
