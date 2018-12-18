using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace DesctopClient.Models
{
    public class Recipe : ActiveRecord<Recipe>
    {
        public Recipe() : base("RecipesAPI")
        {
                
        }

        public int id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public bool IsAvailable { get; set; }
        public int Price { get; set; }
        public virtual ObservableCollection<Ingredient> Ingredients { get; set; }
        [JsonIgnoreAttribute]
        public virtual List<Order> Orders { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}