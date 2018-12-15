using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VIS.Models
{
    public class Ingredient
    {
        public int id { get; set; }
        public String Name { get; set; }
        public String Category { get; set; }
        public String Image { get; set; }
        public String Amount { get; set; }
    }
}