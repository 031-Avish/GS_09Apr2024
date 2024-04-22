using PizzaAppDataAccessLibrary;
using PizzaOrderDataAccessLibrary;
using PizzaSellingStoreApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppBLLibrary
{
    public class IncredientsBL : IIncredientServices
    {
        readonly IRepository<int,Incredients> _incredientsRepository;
        public IncredientsBL()
        {
            _incredientsRepository=new IncredientRepository();  
        }
        public int AddIncredients(Incredients incredients)
        {
           var result=_incredientsRepository.Add(incredients);
           if(result!=null)
            {
                return result.IncId;
            }
            throw new DuplicateOrderException();
        }

        public List<Incredients> GetAllIncredient()
        {
            List<Incredients> incredients = _incredientsRepository.GetAll();
            if (incredients != null)
            {
                return incredients;
            }
            return incredients;
        }
    }
}
