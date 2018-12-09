﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VIS.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public bool IsAvailable { get; set; }
        public int Price { get; set; }
        List<Ingredient> Ingredients { get; set; }
    }
}