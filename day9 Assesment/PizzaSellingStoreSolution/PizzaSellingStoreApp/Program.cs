using PizzaAppBLLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSellingStoreApp
{
    internal class Program
    {
        /// <summary>
        /// To add the ingredients that are available 
        /// </summary>
        /// <returns> The object of incredients business logic class </returns>
        IncredientsBL AddIncredient()
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
            return incredientsBL;
        }

        /// <summary>
        /// to add the pizza that are avialable in Store
        /// </summary>
        /// <returns>Object of pizza bussiness logic class </returns>
        PizzaBL AddPizza()
        {
            PizzaBL pizzaBL = new PizzaBL();
            try
            {
                Pizza pizza1 = new Pizza()
                {
                    Name = "Margherita",
                    Incredients = new List<int> { 1, 2, 3 }, // Tomato sauce, mozzarella, basil
                    PriceAccToSize = new Dictionary<string, double> { { "Small", 9.99 }, { "Medium", 12.99 }, { "Large", 15.99 } },
                    IsAvailable = true
                };
                Pizza pizza2 = new Pizza()
                {
                    Name = "Pepperoni",
                    Incredients = new List<int> { 1, 2, 4 }, // Tomato sauce, mozzarella, pepperoni
                    PriceAccToSize = new Dictionary<string, double> { { "Small", 10.99 }, { "Medium", 13.99 }, { "Large", 16.99 } },
                    IsAvailable = true
                };
                Pizza pizza3 = new Pizza()
                {
                    Name = "Hawaiian",
                    Incredients = new List<int> { 1, 2, 5, 6 }, // Tomato sauce, mozzarella, ham, pineapple
                    PriceAccToSize = new Dictionary<string, double> { { "Small", 11.99 }, { "Medium", 14.99 }, { "Large", 17.99 } },
                    IsAvailable = true
                };
                Pizza pizza4 = new Pizza()
                {
                    Name = "Veggie Supreme",
                    Incredients = new List<int> { 1, 2, 7, 8, 9, 10 }, // Tomato sauce, mozzarella, mushrooms, onions, bell peppers, olives
                    PriceAccToSize = new Dictionary<string, double> { { "Small", 12.99 }, { "Medium", 15.99 }, { "Large", 18.99 } },
                    IsAvailable = true
                };
                Pizza pizza5 = new Pizza()
                {
                    Name = "Meat Lover's",
                    Incredients = new List<int> { 1, 2, 4, 5 }, // Tomato sauce, mozzarella, pepperoni, ham
                    PriceAccToSize = new Dictionary<string, double> { { "Small", 13.99 }, { "Medium", 16.99 }, { "Large", 19.99 } },
                    IsAvailable = true
                };
                Console.WriteLine(pizzaBL.AddPizza(pizza1));
                pizzaBL.AddPizza(pizza2);
                pizzaBL.AddPizza(pizza3);
                pizzaBL.AddPizza(pizza4);
                pizzaBL.AddPizza(pizza5);
                //return pizzaBL;

            }
            catch (DuplicateOrderException de)
            {
                Console.WriteLine(de.Message);
            }
            return pizzaBL;

        }



        public OrderBL orderBL = new OrderBL();

        /// <summary>
        /// to get the user preference , it is a healper function 
        /// </summary>
        /// <param name="order">Order's object </param>
        /// <param name="incredientsBL">IncredientBL's object</param>
        /// <param name="pizza">Pizza's Object</param>
        /// <returns>retrun 1 if continue part executed else 0</returns>

        int GetPizzaPrefrence(Order order, IncredientsBL incredientsBL, PizzaBL pizza)
        {
            Pizza newPizza = new Pizza();
            Console.WriteLine("---------------------------\n");

            Console.WriteLine("Choose Pizza Of User Choice Enter Id");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry. Please try again");
            }
            Pizza p = pizza.GetPizzaById(id);
            if (p == null)
            {
                Console.WriteLine("Invalid ID !!! Try again");
                return 1;
            }
            newPizza.PizzaId = id;
            newPizza.Name = p.Name;

            while (true)
            {
                Console.WriteLine("----------------------------------\n");

                Console.WriteLine("Choose Pizza Size : ");
                Console.WriteLine("1 for Small pizza");
                Console.WriteLine("2 for Medium pizza");
                Console.WriteLine("3 for Large Pizza");
                int size;
                while (!int.TryParse(Console.ReadLine(), out size))
                {
                    Console.WriteLine("Invalid entry. Please try again");
                }
                if (size == 1)
                {
                    newPizza.PriceAccToSize.Add("Small", p.PriceAccToSize["Small"]);
                    order.TotalCost = order.TotalCost + p.PriceAccToSize["Medium"];
                    break;
                }
                else if (size == 2)
                {
                    newPizza.PriceAccToSize.Add("Medium", p.PriceAccToSize["Medium"]);
                    order.TotalCost = order.TotalCost + p.PriceAccToSize["Small"];
                    break;
                }
                else if (size == 3)
                {
                    newPizza.PriceAccToSize.Add("Large", p.PriceAccToSize["Large"]);
                    order.TotalCost = order.TotalCost + p.PriceAccToSize["Large"];
                    break;
                }
                else
                {
                    Console.WriteLine("Please Enter Correct choice");
                }
            }
            int choice = -1;
            while (choice != 0)
            {
                Console.WriteLine("Choose incredients of Your choice ");
                //IncredientsBL incredientsBL = new IncredientsBL();
                int i = 1;
                foreach (int incredientId in p.Incredients)
                {
                    var incredient = incredientsBL.GetIncredientsById(incredientId);
                    Console.WriteLine($"press {i++} to add :  {incredient.Name} (₹{incredient.Price} per unit)");
                }
                Console.WriteLine("Press 0 to stop");

                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid entry. Please try again");
                }
                for (int j = 1; j <= p.Incredients.Count; j++)
                {
                    if (choice == j)
                    {
                        Incredients incredient = incredientsBL.GetIncredientsById(p.Incredients[j - 1]);
                        if (incredient.QuantityAvailable <= 0)
                        {
                            Console.WriteLine("this incredient is finished , try something else ");
                            break;
                        }
                        newPizza.Incredients.Add(incredient.IncId);
                        //order.Incredients.Add(incredient);
                        Console.WriteLine($"{incredient.Name} is added");
                        order.TotalCost += incredient.Price;
                        break;
                    }
                }

            }
            order.Pizzas.Add(newPizza);
            return 0;
        }
        /// <summary>
        ///  to get the contact details of Customer
        /// </summary>
        /// <param name="order"> Order's object </param>
        void GetContactDetails(Order order)
        {
            Console.WriteLine("**************************************************\n");
            Console.WriteLine("You are Almost Done Provide name and contact to place order ");
            string Cname;
            string Ccontact;
            Console.WriteLine("Please Enter Your Name");
            Cname = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Please Enter Your Mobile Number");
            Ccontact = Console.ReadLine() ?? String.Empty;

            order.ContactInformation = Ccontact;
            order.CustomerName = Cname;
            int deliver;
            Console.WriteLine("---------------------------\n");
            Console.WriteLine("Enter 1 for Delivery and 2 for Pickup");

            while (!int.TryParse(Console.ReadLine(), out deliver))
            {
                Console.WriteLine("Invalid entry. Please try again");
            }
            if (deliver == 1)
            {
                order.IsDelivery = true;
                order.TotalCost += 50;
                Console.WriteLine("Enter dilivery Address");
                order.Address = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("50 rs dilivery charge added ");

            }
            else
            {
                Console.WriteLine("You choose for pickup form store");
            }
        }

        /// <summary>
        /// get the choice of pizza from the user 
        /// </summary>
        /// <param name="incredientsBL">IncredientsBL's object</param>
        /// <param name="pizza">Pizza's object</param>
        void AskUserToSelectPizza(IncredientsBL incredientsBL, PizzaBL pizza)
        {
            //PizzaBL pizza = new PizzaBL();
            Order order = new Order();
            
            try
            {
                while (true)
                {
                    int returnVal = GetPizzaPrefrence(order, incredientsBL, pizza);
                    if (returnVal == 1)
                        continue;

                    Console.WriteLine("---------------------------\n");
                    Console.WriteLine("Congtatulations Your Pizza is added");
                    Console.WriteLine("---------------------------\n");
                    Console.WriteLine("press 1 to order ");
                    Console.WriteLine("press 2 to add mode pizza");

                    int inp;
                    while (!int.TryParse(Console.ReadLine(), out inp))
                    {
                        Console.WriteLine("Invalid entry. Please try again");
                    }

                    if (inp == 1)
                    {
                        int Oid = orderBL.AddOrder(order);
                        Console.WriteLine("Congratulations Your order is placed with order id " + Oid);
                        break;
                    }
                    else if (inp == 2)
                        continue;
                }

                GetContactDetails(order);
                

            }
            catch (PizzaDoesNotExistException de)
            {
                Console.WriteLine(de.Message);
            }
        }

        /// <summary>
        ///  to show list of all available pizza 
        /// </summary>
        /// <param name="incredientsBL"> IncredientsBL's object </param>
        /// <param name="pizzaBL"> PizzaBL's object</param>
        void ShowListOfPizza(IncredientsBL incredientsBL, PizzaBL pizzaBL)
        {
            try
            {
                List<Pizza> pizzas = pizzaBL.GetAllPizza();
                foreach(Incredients incredients in incredientsBL.GetAllIncredient())
                {
                    if (incredients.QuantityAvailable <= 0)
                    {
                        foreach(Pizza piz in pizzas)
                        {
                            if (piz.Incredients.Contains(incredients.IncId))
                                piz.IsAvailable = false;
                        }
                    }
                }
                foreach (Pizza p in pizzas)
                {
                    Console.WriteLine("**************************************");
                    Console.WriteLine("Pizza Id        : " + p.PizzaId);
                    Console.WriteLine("Pizza Name      : " + p.Name);
                    Console.WriteLine("Pizza Available : " + p.IsAvailable);
                    Console.WriteLine();
                    Console.WriteLine("Pizza Price     :");
                    foreach (var price in p.PriceAccToSize)
                    {
                        Console.WriteLine($"~ {price.Key}: {price.Value}");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Pizza Ingredients:");
                    foreach (int incredientId in p.Incredients)
                    {
                        var incredient = incredientsBL.GetIncredientsById(incredientId);
                        Console.WriteLine($"~ {incredient.Name} ({incredient.Price} per unit)");
                    }
                }
                AskUserToSelectPizza(incredientsBL, pizzaBL);

            }
            catch (PizzaDoesNotExistException pe)
            {
                Console.WriteLine(pe.Message);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            IncredientsBL incredientsBL= program.AddIncredient();
            PizzaBL pizzaBL=program.AddPizza();
            program.UserOptions(incredientsBL,pizzaBL);
        }

        /// <summary>
        /// nav bar for user 
        /// </summary>
        /// <param name="incredientsBL"></param>
        /// <param name="pizzaBL"></param>
        void UserOptions(IncredientsBL incredientsBL , PizzaBL pizzaBL)
        {
            Console.WriteLine("Hello Welcome to Pizza Store");
            Console.WriteLine("Please Select from Given Options");
            int userInput;

            while (true)
            {
                Console.WriteLine("--------------------------------------\n");
                Console.WriteLine("Enter 1 for : List of available Pizzas");
                Console.WriteLine("Enter 2 for seeing Your Order ");
                Console.WriteLine("Enter 3 for seeing inventory");
                Console.WriteLine("Enter 0 for : Exit");

                while (!int.TryParse(Console.ReadLine(), out userInput))
                {
                    Console.WriteLine("Invalid entry. Please try again");
                }
                if (userInput == 1)
                {
                    ShowListOfPizza(incredientsBL, pizzaBL);
                }
                else if (userInput == 2)
                {
                    try
                    {
                        List<Order> orders= orderBL.GetAllOrders();
                        PrintOrder(orders);
                    }
                    catch (OrderDoesNotExistException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if(userInput==3)
                {
                    showInventory(incredientsBL, pizzaBL);
                }
                else if (userInput == 0)
                    return;
                else
                    Console.WriteLine("Choose correct optionn ");
            }
        }

        /// <summary>
        /// to check the availability of incredients 
        /// </summary>
        /// <param name="incredientsBL"></param>
        /// <param name="pizzaBL"></param>
        private void showInventory(IncredientsBL incredientsBL, PizzaBL pizzaBL)
        {
            List<Incredients> incredients= incredientsBL.GetAllIncredient();
            Console.WriteLine("Ingredients avalilable are :");
            foreach (var ingredient in incredients)
            {
                Console.WriteLine($"Name: {ingredient.Name}, Quantity Available: {ingredient.QuantityAvailable}");
            }
        }

        /// <summary>
        /// Method to print the pizza orders 
        /// </summary>
        /// <param name="orders"> list of orders </param>
        private void PrintOrder(List<Order> orders)
        {
            foreach (var order in orders)
            {
                Console.WriteLine("--------------------------------\n");

                Console.WriteLine($"Order ID           : {order.OrderId}");
                Console.WriteLine($"Customer Name      : {order.CustomerName}");
                Console.WriteLine($"Contact Information: {order.ContactInformation}");
                Console.WriteLine("\n");
                Console.WriteLine("Pizzas:");
                foreach (var pizza in order.Pizzas)
                {
                    Console.WriteLine($"- Pizza ID: {pizza.PizzaId}, Name: {pizza.Name}");
                   
                }
                Console.WriteLine("\n");
                Console.WriteLine($"Address            : {order.Address}");
                Console.WriteLine($"Order Date and Time: {order.OrderDateTime}");
                Console.WriteLine($"Is Delivery        : {order.IsDelivery}");
                Console.WriteLine($"Total Cost         : {order.TotalCost}");
                Console.WriteLine();
            }
        }
    }
}
