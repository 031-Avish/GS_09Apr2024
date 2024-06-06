using PizzaStoreApp.Models;

namespace PizzaStoreApp.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerById(int id);
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> UpdateCustomerAddress(int id, string address);
        Task<Customer> DeleteCustomerById(int id);  
    }
}
