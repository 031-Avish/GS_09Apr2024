using PizzaStoreApp.Models;

namespace PizzaStoreApp.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(Customer customer);
    }
}
