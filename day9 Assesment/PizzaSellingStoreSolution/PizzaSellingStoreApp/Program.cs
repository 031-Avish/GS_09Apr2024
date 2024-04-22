using PizzaAppBLLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSellingStoreApp
{
    internal class Program
    {
        void AddIncredient()
        {
            IncredientsBL incredientsBL = new IncredientsBL();
            try
            {
                Incredients ingredient1 = new Incredients { Name = "Tomato sauce", Price = 50.0, QuantityAvailable = 100 };
                Incredients ingredient2 = new Incredients { Name = "Mozzarella", Price = 100.0, QuantityAvailable = 50 };
                Incredients ingredient3 = new Incredients { Name = "Basil", Price = 75.0, QuantityAvailable = 30 };
                Incredients ingredient4 = new Incredients { Name = "Pepperoni", Price = 150.0, QuantityAvailable = 70 };
                Incredients ingredient5 = new Incredients { Name = "Ham", Price = 175.0, QuantityAvailable = 60 };
                Incredients ingredient6 = new Incredients { Name = "Pineapple", Price = 100.0, QuantityAvailable = 40 };
                Incredients ingredient7 = new Incredients { Name = "Mushrooms", Price = 100.0, QuantityAvailable = 50 };
                Incredients ingredient8 = new Incredients { Name = "Onions", Price = 75.0, QuantityAvailable = 45 };
                Incredients ingredient9 = new Incredients { Name = "Bell peppers", Price = 75.0, QuantityAvailable = 55 };
                Incredients ingredient10 = new Incredients { Name = "Olives", Price = 100.0, QuantityAvailable = 50 };

                incredientsBL.AddIncredients(ingredient1);
                incredientsBL.AddIncredients(ingredient2);
                incredientsBL.AddIncredients(ingredient3);
                incredientsBL.AddIncredients(ingredient4);
                incredientsBL.AddIncredients(ingredient5);
                incredientsBL.AddIncredients(ingredient6);
                incredientsBL.AddIncredients(ingredient7);
                incredientsBL.AddIncredients(ingredient8);
                incredientsBL.AddIncredients(ingredient9);
                incredientsBL.AddIncredients(ingredient10);
            }
            catch (DuplicateOrderException de)
            {
                Console.WriteLine(de.Message);
            }


        }
        static void Main(string[] args)
        {
            Program program = new Program();
        }
    }
}
