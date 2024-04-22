using PizzaOrderDataAccessLibrary;
using PizzaSellingStoreApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppDataAccessLibrary
{
    public class IncredientRepository: IRepository<int,Incredients>
    {
        readonly Dictionary<int, Incredients> _incredients;
        public IncredientRepository()
        {
            _incredients=new Dictionary<int, Incredients>();    
        }
        int GenerateId()
        {
            if (_incredients.Count == 0)
                return 1;
            int id = _incredients.Keys.Max();
            return ++id;
        }
        public Incredients Add(Incredients item)
        {
            if (_incredients.ContainsKey(item.IncId))
            {
                return null;
            }
            item.IncId = GenerateId();
            _incredients.Add(item.IncId, item);
            return item;

        }

        public List<Incredients> GetAll()
        {
            if (_incredients.Count == 0)
                return null;
            return _incredients.Values.ToList();
        }

        public Incredients Get(int key)
        {
            throw new NotImplementedException();
        }

        public Incredients Update(Incredients item)
        {
            throw new NotImplementedException();
        }

        public Incredients Delete(int key)
        {
            throw new NotImplementedException();
        }
    }
}
