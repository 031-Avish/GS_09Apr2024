using PizzaStoreApp.Contexts;
using PizzaStoreApp.Interfaces;
using PizzaStoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace PizzaStoreApp.Repositories
{
    public class OrderRepository : IRepository<int, Order>
    {
        #region Context Object
        private readonly PizzaStoreContext _context;

        public OrderRepository(PizzaStoreContext context)
        {
            _context = context;
        }
        #endregion

        #region Add Order
        public async Task<Order> Add(Order item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
        #endregion

        #region Delete Order
        public async Task<Order> DeleteByKey(int key)
        {
            var order = await GetByKey(key);
            if (order != null)
            {
                _context.Remove(order);
                await _context.SaveChangesAsync();
                return order;
            }
            throw new Exception("No order with the given ID");
        }
        #endregion

        #region Get Order by Key
        public async Task<Order> GetByKey(int key)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == key)
                ?? throw new Exception("No order with the given ID");
        }
        #endregion

        #region Get All Orders
        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }
        #endregion

        #region Update Order
        public async Task<Order> Update(Order item)
        {
            var order = await GetByKey(item.Id);
            if (order != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return order;
            }
            throw new Exception("No order with the given ID");
        }
        #endregion
    }
}
