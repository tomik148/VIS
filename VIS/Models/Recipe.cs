using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VIS.Models
{
    public class Recipe
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public bool IsAvailable { get; set; }
        public int Price { get; set; }
        public virtual List<Ingredient> Ingredients { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}