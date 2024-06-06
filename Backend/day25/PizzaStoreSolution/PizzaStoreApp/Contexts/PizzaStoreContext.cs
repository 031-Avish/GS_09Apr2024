using Microsoft.EntityFrameworkCore;
using PizzaStoreApp.Models;

namespace PizzaStoreApp.Contexts
{
    public class PizzaStoreContext: DbContext
    {
        public PizzaStoreContext(DbContextOptions options) :base(options)
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set;}
        public DbSet<Order> Orders { get; set;}

    }
}
