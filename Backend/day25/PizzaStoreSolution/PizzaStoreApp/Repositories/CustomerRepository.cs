using Microsoft.EntityFrameworkCore;
using PizzaStoreApp.Contexts;
using PizzaStoreApp.Interfaces;
using PizzaStoreApp.Models;

namespace PizzaStoreApp.Repositories
{
    public class CustomerRepository : IRepository<int, Customer>
    {
        #region Context Object
        private readonly PizzaStoreContext _context;

        public CustomerRepository(PizzaStoreContext context)
        {
            _context = context;
        }
        #endregion

        #region Add Customer
        public async Task<Customer> Add(Customer item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
        #endregion

        #region Delete Customer
        public async Task<Customer> DeleteByKey(int key)
        {
            var customer = await GetByKey(key);
            if (customer != null)
            {
                _context.Remove(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
            throw new Exception("No such customer is Present");
        }
        #endregion

        #region Get Customer by Key
        public async Task<Customer> GetByKey(int key)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == key);
        }
        #endregion

        #region Get All Customers
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }
        #endregion

        #region Update Customer
        public async Task<Customer> Update(Customer item)
        {
            var customer = await GetByKey(item.Id);
            if (customer != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return customer;
            }
            throw new Exception("No such customer is Present");
        }
        #endregion
    }
}
