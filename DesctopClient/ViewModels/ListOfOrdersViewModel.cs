using DesctopClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesctopClient.ViewModels
{
    class ListOfOrdersViewModel : BaseViewModel
    {
        private Order[] _orders;

        public Order[] Orders { get => _orders; set => OnPropertyChanged(ref _orders, value); }

        public ListOfOrdersViewModel()
        {
        }

        public override async Task OnOpenAsync()
        {
            Orders = await new Order().GetAllAsync();
        }

        public override Task OnOpenAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
