namespace VIS
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using VIS.Models;

    public partial class Model1 : DbContext
    {
        static Model1 _context;
        public static Model1 Context
        {
            get => _context ?? (_context = new Model1());
        }
        public Model1()
            : base("name=Model1")
        {

        }
        public DbSet<Address> Address { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
