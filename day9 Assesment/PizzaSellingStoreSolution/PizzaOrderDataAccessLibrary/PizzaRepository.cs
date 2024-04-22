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

        public PizzaRepository()
        {
            _pizzas = new Dictionary<int, Pizza>();
        }
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
            return _pizzas.ContainsKey(key) ? _pizzas[key] : null;
        }

        public List<Pizza> GetAll()
        {
            if (_pizzas.Count == 0)
                return null;
            return _pizzas.Values.ToList();
        }

        public Pizza Update(Pizza item)
        {
            throw new NotImplementedException();
        }
    }
}
