using PizzaSellingStoreApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppBLLibrary
{
    public interface IPizzaServices
    {
        int AddPizza(Pizza pizza);
        List<Pizza> GetAllPizza();
        Pizza GetPizzaById(int id);
    }
}
