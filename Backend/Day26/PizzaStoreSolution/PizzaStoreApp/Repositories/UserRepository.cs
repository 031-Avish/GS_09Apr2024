using PizzaStoreApp.Contexts;
using PizzaStoreApp.Interfaces;
using PizzaStoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace PizzaStoreApp.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        #region Context Object
        private readonly PizzaStoreContext _context;
        public UserRepository(PizzaStoreContext context)
        {
            _context = context;
        }
        #endregion

        #region Add User
        public async Task<User> Add(User item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
        #endregion

        #region Delete User
        public async Task<User> DeleteByKey(int key)
        {
            var user = await GetByKey(key);
            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new Exception("No user with the given ID");
        }
        #endregion

        #region GetByKey
        public async Task<User> GetByKey(int key)
        {
            return await _context.Users.Include(u => u.Customer).SingleOrDefaultAsync(u => u.CustomerId == key)
                ?? throw new Exception("No user with the given ID");
        }
        #endregion

        #region GetAll
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.Include(u => u.Customer).ToListAsync();
        }
        #endregion

        #region Update
        public async Task<User> Update(User item)
        {
            var user = await GetByKey(item.CustomerId);
            if (user != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new Exception("No user with the given ID");
        }
        #endregion
    }
}
