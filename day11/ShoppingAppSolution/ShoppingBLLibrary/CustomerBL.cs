using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace ShoppingBLLibrary
{
    public class CustomerBL:ICustomerServices
    {
        private readonly IRepository<int, Customer> _customerRepository;

        [ExcludeFromCodeCoverage]
        public CustomerBL()
        {
            _customerRepository = new CustomerRepository();
        }

        public CustomerBL(IRepository<int, Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer AddCustomer(Customer customer)
        {
            var addedCustomer = _customerRepository.Add(customer);
            if (addedCustomer != null)
            {
                return addedCustomer;
            }
            throw new DuplicateCustomerException();
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var updatedCustomer = _customerRepository.Update(customer);
            if (updatedCustomer != null)
            {
                return updatedCustomer;
            }
            throw new NoCustomerWithGiveIdException();
        }

        public Customer GetCustomerById(int customerId)
        {
            var customer = _customerRepository.GetByKey(customerId);
            if (customer != null)
            {
                return customer;
            }
            throw new NoCustomerWithGiveIdException();
        }

        [ExcludeFromCodeCoverage]
        public List<Customer> GetAllCustomers()
        {
            var customers = _customerRepository.GetAll()?.ToList();
            if (customers != null)
            {
                return customers;
            }
            throw new NoCustomerWithGiveIdException();
        }

        public bool DeleteCustomer(int customerId)
        {
            var deletedCustomer = _customerRepository.Delete(customerId);
            if (deletedCustomer != null)
            {
                return true;
            }
            throw new NoCustomerWithGiveIdException();
        }
    }
}
