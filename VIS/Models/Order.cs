using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VIS.Models
{
    public class Order
    {
        public int Tax { get; set; }
        public DateTime DateOfOrder { get; set; }
        public User Customer { get; set; }
        public List<Recipe> Recipes { get; set; }


    }
}