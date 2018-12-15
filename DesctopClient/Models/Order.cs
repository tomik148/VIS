using System;
using System.Collections.Generic;
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
        public virtual List<Recipe> Recipes { get; set; }


    }
}