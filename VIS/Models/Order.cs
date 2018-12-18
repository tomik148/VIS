using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VIS.Models
{
    public class Order
    {
        public int id { get; set; }
        public int? Tax { get; set; }
        public DateTime? DateOfOrder { get; set; }
        public virtual User Customer { get; set; }
        public virtual List<Recipe> Recipes { get; set; }


    }
}