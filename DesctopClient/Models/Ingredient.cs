using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace DesctopClient.Models
{
    public class Ingredient : ActiveRecord<Ingredient>
    {
        private int _id;
        private string _name;
        private string _category;
        private string _image;
        private string _amount;

        public Ingredient() : base("IngredientsAPI")
        {

        }

        public int id { get => _id; set => _id = value; }
        public string Name { get => _name; set => OnPropertyChanged(ref _name, value); }
        public string Category { get => _category; set => OnPropertyChanged(ref _category, value); }
        public string Image { get => _image; set => OnPropertyChanged(ref _image, value); }
        public string Amount { get => _amount; set => OnPropertyChanged(ref _amount, value); }

        public override string ToString()
        {
            return Name;
        }
    }
}