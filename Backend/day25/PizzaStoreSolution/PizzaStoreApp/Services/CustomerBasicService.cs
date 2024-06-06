using EmployeeRequestTrackerApp.Exceptions;
using PizzaStoreApp.Interfaces;
using PizzaStoreApp.Models;

namespace PizzaStoreApp.Services
{
    public class CustomerBasicService : ICustomerService
    {
        private readonly IRepository<int, Customer> _repository;

        public CustomerBasicService(IRepository<int, Customer> repository)
        {
            _repository = repository;
        }

        public async Task<Customer> DeleteCustomerById(int id)
        {
            return await _repository.DeleteByKey(id);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = await _repository.GetAll();
            if (!customers.Any())
                throw new NoCustomerFoundException();
            return customers;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _repository.GetByKey(id);
            if (customer == null)
                throw new NoSuchCustomerException();
            return customer;
        }

        public async Task<Customer> UpdateCustomerAddress(int id, string address)
        {
            var customer = await _repository.GetByKey(id);
            if (customer == null)
                throw new NoSuchCustomerException();
            customer.Address = address;
            return await _repository.Update(customer);
        }
    }
}
