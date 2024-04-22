using PizzaSellingStoreApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderDataAccessLibrary
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        readonly Dictionary<int, Pizza> _pizzas;
        int GenerateId()
        {
            if (_pizzas.Count == 0)
                return 1;
            int id=_pizzas.Keys.Max();
            return ++id;
        }
        public Pizza Add(Pizza item)
        {
            if(_pizzas.ContainsKey(item.PizzaId))
            {
                return null;
            }
            item.PizzaId = GenerateId();
            _pizzas.Add(item.PizzaId, item);
            return item;
            
        }

        public Pizza Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Pizza Get(int key)
        {
            throw new NotImplementedException();
        }

        public List<Pizza> GetAll()
        {
            throw new NotImplementedException();
        }

        public Pizza Update(Pizza item)
        {
            throw new NotImplementedException();
        }
    }
}
