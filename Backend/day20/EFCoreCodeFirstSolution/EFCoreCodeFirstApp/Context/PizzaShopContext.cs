using EFCoreCodeFirstApp.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstApp.Context
{
    public class PizzaShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-A92QBO1\\DEMO;Integrated Security=true;Initial Catalog=dbPizzaShop;");
        }
        public DbSet<Pizza> Pizzas { get; set; }
    }
}
