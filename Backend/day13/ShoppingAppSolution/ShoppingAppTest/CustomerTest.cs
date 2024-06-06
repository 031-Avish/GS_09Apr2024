using ShoppingBLLibrary;
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
            var result = repository.Add(customer).Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(customer, result);
        }

        [Test] 
        public void AddDuplicateCustomerFail() {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 25 };

            // Act
            var result = repository.Add(customer);

            Assert.Throws<DuplicateCustomerException>(() => repository.Add(customer));
        }

        [Test]
        public void GetByKeyCustomerExistsSuccess()
        {
            // Arrange
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 25 };
            repository.Add(customer);

            // Act
            var result = repository.GetByKey(customer.Id).Result;

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

        [Test]
        public void GetByKeyExceptionNotExist()
        {
            
            // Arrange
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 25 };
            repository.Add(customer);

            // Act
            var result = repository.GetByKey(customer.Id);
            // Assert
            Assert.Throws<NoCustomerWithGiveIdException>(() => repository.GetByKey(2));
        }
        [Test]
        public void GetAllProductSuccess()
        {
            // Arrange
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 25 };
            repository.Add(customer);
            Customer customer1 = new Customer { Id = 2, Phone = "1214567890", Age = 29};
            
            // Act
            Customer result = repository.Add(customer1).Result;

            // Assert
            Assert.AreEqual(2, repository.GetAll().Result.Count)  ;
            Assert.AreEqual(customer1, repository.GetByKey(2).Result);
        }

        [Test]
        public void GetAllProductFailException()
        {
            //Assert
            Assert.Throws<NoCustomerWithGiveIdException>(() => repository.GetAll());
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
            var result = repository.Update(customer).Result;
            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(customer, result);
            Assert.IsTrue(repository.GetAll().Result.Contains(customer));
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
        public void UpdateCustomerException()
        {
            // Arrange
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 25 };
            Customer customer1 = new Customer { Id = 2, Phone = "1235567890", Age = 26 };

            // Act
            repository.Add(customer);

            //  Assert
            Assert.Throws<NoCustomerWithGiveIdException>(() => repository.Update(customer1));
        }

        [Test]
        public void DeleteCustomerSuccess()
        {
            // Arrange
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 25 };
            repository.Add(customer);

            // Act
            var result = repository.Delete(customer.Id).Result;

            // Assert
            //Assert.IsNotNull(result);
            Assert.AreEqual(customer, result);

        }
        [Test]
        public void DeleteCustomerException()
        {
            // Arrange & Act & Assert
            Assert.Throws<NoCustomerWithGiveIdException>(() => repository.Delete(999));
        }
        [Test]
        public void DeleteCustomerFail()
        {
            // Arrange
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 25 };
            //Act
            repository.Add(customer);
            // Assert
            Assert.Throws<NoCustomerWithGiveIdException>(() => repository.Delete(999));


        }

    }
}