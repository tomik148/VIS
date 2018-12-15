using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VIS.Models
{
    public class User
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual Address Lives { get; set; }
    }
}