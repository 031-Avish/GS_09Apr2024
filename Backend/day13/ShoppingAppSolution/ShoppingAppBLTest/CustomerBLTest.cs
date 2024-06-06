using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary.Exceptions;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppTest
{
    public class CustomerBLTest
    {
        private CustomerBL _customerBL;
        private IRepository<int, Customer> _customerRepository;

        [SetUp]
        public void Setup()
        {
            _customerRepository = new CustomerRepository();
            _customerBL = new CustomerBL(_customerRepository);
        }

        [Test]
        public void AddCustomerSuccess()
        {
            // Arrange
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 30 };

            // Act
            var result = _customerBL.AddCustomer(customer);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(customer, result);
        }

        [Test]
        public void DeleteCustomerSuccess()
        {
            // Arrange
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 30 };
            _customerBL.AddCustomer(customer);

            // Act
            var result = _customerBL.DeleteCustomer(customer.Id);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void UpdateCustomerSuccess()
        {
            // Arrange
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 30 };
            _customerBL.AddCustomer(customer);

            // Modify the customer
            customer.Age = 35;

            // Act
            var result = _customerBL.UpdateCustomer(customer);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(customer, result);
        }

        [Test]
        public void GetCustomerByIdSuccess()
        {
            // Arrange
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 30 };
            _customerBL.AddCustomer(customer);

            // Act
            var result = _customerBL.GetCustomerById(customer.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(customer, result);
        }

        [Test]
        public void GetCustomerByIdException()
        {
            // Arrange & Act & Assert
            Assert.Throws<NoCustomerWithGiveIdException>(() => _customerBL.GetCustomerById(999));
        }

        [Test]
        public void UpdateCustomer_CustomerDoesNotExist_ExceptionThrown()
        {
            // Arrange
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 30 };

            // Act & Assert
            Assert.Throws<NoCustomerWithGiveIdException>(() => _customerBL.UpdateCustomer(customer));
        }

        [Test]
        public void DeleteCustomerException()
        {
            // Arrange & Act & Assert
            Assert.Throws<NoCustomerWithGiveIdException>(() => _customerBL.DeleteCustomer(999));
        }
    }
}
