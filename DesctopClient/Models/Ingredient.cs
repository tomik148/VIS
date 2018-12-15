using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesctopClient.Models
{
    public class Ingredient : ActiveRecord<Ingredient>
    {
        public Ingredient() : base("IngredientsAPI")
        {

        }

        public int id { get; set; }
        public String Name { get; set; }
        public String Category { get; set; }
        public String Image { get; set; }
        public String Amount { get; set; }
    }
}