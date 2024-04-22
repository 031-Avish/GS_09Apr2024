using PizzaOrderDataAccessLibrary;
using PizzaSellingStoreApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppBLLibrary
{
    class PizzaBL : IPizzaServices
    {
        readonly IRepository<int, Pizza> _pizzaRepository;
        public PizzaBL()
        {
            _pizzaRepository=new PizzaRepository();
        }

        public int AddPizza(Pizza pizza)
        {
            var result=_pizzaRepository.Add(pizza);
            if(result!=null)
            {
                return result.PizzaId;
            }
            throw new DuplicateOrderException();
        }
    }
}
