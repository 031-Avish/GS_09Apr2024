using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System.Numerics;

namespace ShoppingAppTest
{
    public class Tests
    {
        IRepository<int, Customer> repository;
        [SetUp]
        public void Setup()
        {
            repository=new CustomerRepository();
        }


        [Test]
        public void AddCustomerSuccess()
        {
            // Arrange
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 25 };

            // Act
            var result = repository.Add(customer);

            // Assert
            Assert.AreEqual(customer, result);
        }
        [Test]
        public void DeleteCustomerSuccess()
        {
            // Arrange
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 25 };
            repository.Add(customer);

            // Act
            var result = repository.Delete(customer.Id);

            // Assert
            //Assert.IsNotNull(result);
            Assert.AreEqual(customer, result);
            Assert.IsFalse(repository.GetAll().Contains(customer));
        }
        [Test]
        public void DeleteCustomerException()
        {
            // Arrange & Act & Assert
            Assert.Throws<NoCustomerWithGiveIdException>(() => repository.Delete(999));
        }

        [Test]
        public void UpdateCustomerSuccess()
        {
            // Arrange
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 25 };
            repository.Add(customer);

            // Modify the customer
            customer.Phone = "0987654321";

            // Act
            var result = repository.Update(customer);
            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(customer, result);
            Assert.IsTrue(repository.GetAll().Contains(customer));
        }
        [Test]
        public void UpdateCustomerExceptionThrown()
        {
            // Arrange
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 25 };

            // Act & Assert
            Assert.Throws<NoCustomerWithGiveIdException>(() => repository.Update(customer));
        }


        [Test]
        public void GetByKeyCustomerExistsSuccess()
        {
            // Arrange
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 25 };
            repository.Add(customer);

            // Act
            var result = repository.GetByKey(customer.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(customer, result);
        }

        [Test]
        public void GetByKeyException()
        {
            // Arrange & Act & Assert
            Assert.Throws<NoCustomerWithGiveIdException>(() => repository.GetByKey(999));
        }
    }
}