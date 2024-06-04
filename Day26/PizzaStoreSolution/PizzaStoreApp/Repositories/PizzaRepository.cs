using Microsoft.EntityFrameworkCore;
using PizzaStoreApp.Contexts;
using PizzaStoreApp.Interfaces;
using PizzaStoreApp.Models;

namespace PizzaStoreApp.Repositories
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        private PizzaStoreContext _context;

        #region Context 
        public PizzaRepository(PizzaStoreContext context)
        {
            _context = context;
        }
        #endregion

        #region Add
        public async Task<Pizza> Add(Pizza item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
        #endregion

        #region DeleteByKey
        public async Task<Pizza> DeleteByKey(int key)
        {
            var pizza = await GetByKey(key);
            if (pizza != null)
            {
                _context.Remove(pizza);
                await _context.SaveChangesAsync();
                return pizza;
            }
            throw new Exception("No pizza with the given ID");
        }
        #endregion

        #region GetByKey
        public async Task<Pizza> GetByKey(int key)
        {
            return (await _context.Pizzas.SingleOrDefaultAsync(p => p.Id == key)) ?? throw new Exception("No pizza with the given ID");
        }
        #endregion

        #region GetAll
        public async Task<IEnumerable<Pizza>> GetAll()
        {
            return (await _context.Pizzas.ToListAsync());
        }
        #endregion

        #region Update
        public async Task<Pizza> Update(Pizza item)
        {
            var pizza = await GetByKey(item.Id);
            if (pizza != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return pizza;
            }
            throw new Exception("No pizza with the given ID");
        }
        #endregion
    }
}
