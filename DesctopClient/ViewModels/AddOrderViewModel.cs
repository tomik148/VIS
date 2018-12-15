using DesctopClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesctopClient.ViewModels
{
    class AddOrderViewModel
    {
        public Order Order { get; set; }


        public ICommand SaveCommand { get; set; }

        public AddOrderViewModel()
        {
            Order = new Order();
            SaveCommand = new Command(CreateOrderAsync);
        }

        public AddOrderViewModel(Order order)
        {
            this.Order = order;
            SaveCommand = new Command(UpdateOrderAsync);
        }

        async void CreateOrderAsync()
        {
            await Order.AddAsync(Order);
        }

        async void UpdateOrderAsync()
        {
            await Order.UpdateByIDAsync(Order.id,Order);
        }
    }
}
