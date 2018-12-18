using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace DesctopClient.Models
{
    public class Order : ActiveRecord<Order>
    {
        public Order() : base("OrdersAPI")
        {
                
        }
        public int id { get; set; }
        public int Tax { get; set; }
        public DateTime DateOfOrder { get; set; }
        public virtual User Customer { get; set; }
        public virtual ObservableCollection<Recipe> Recipes { get; set; }

        public override string ToString()
        {
            return Customer?.Name +" "+ DateOfOrder;
        }
    }
}