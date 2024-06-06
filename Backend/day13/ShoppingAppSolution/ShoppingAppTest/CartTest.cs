//using ShoppingDALLibrary;
//using ShoppingModelLibrary;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ShoppingAppTest
//{
//    public  class CartTest
//    {
//        private CartRepository repository;

//        [SetUp]
//        public void Setup()
//        {
//            repository = new CartRepository();
//        }

//        [Test]
//        public void AddCartSuccess()
//        {
//            // Arrange
//            Cart cart = new Cart { Id = 1, CustomerId = 1, Customer = new Customer(), CartItems = new List<CartItem>() };

//            // Act
//            var result = repository.Add(cart);

//            // Assert
//            Assert.IsNotNull(result);
//            Assert.AreEqual(cart, result);
//        }

//        [Test]
//        public void DeleteCartSuccess()
//        {
//            // Arrange
//            Cart cart = new Cart { Id = 1, CustomerId = 1, Customer = new Customer(), CartItems = new List<CartItem>() };
//            repository.Add(cart);

//            // Act
//            var result = repository.Delete(cart.Id);

//            // Assert
//            Assert.IsNotNull(result);
//            Assert.AreEqual(cart, result);
//        }

//        [Test]
//        public void UpdateCartSuccess()
//        {
//            // Arrange
//            Cart cart = new Cart { Id = 1, CustomerId = 1, Customer = new Customer(), CartItems = new List<CartItem>() };
//            repository.Add(cart);

//            // Modify the cart
//            cart.CustomerId = 2;

//            // Act
//            var result = repository.Update(cart);

//            // Assert
//            Assert.IsNotNull(result);
//            Assert.AreEqual(cart, result);
//            Assert.IsTrue(repository.GetAll().Contains(cart));
//        }

//        [Test]
//        public void GetByKeyCartExistsSuccess()
//        {
//            // Arrange
//            Cart cart = new Cart { Id = 1, CustomerId = 1, Customer = new Customer(), CartItems = new List<CartItem>() };
//            repository.Add(cart);

//            // Act
//            var result = repository.GetByKey(cart.Id);

//            // Assert
//            Assert.IsNotNull(result);
//            Assert.AreEqual(cart, result);
//        }

//        [Test]
//        public void GetByKeyException()
//        {
//            // Arrange & Act & Assert
//            Assert.Throws<NoCartWithGivenIdException>(() => repository.GetByKey(999));
//        }

//        [Test]
//        public void UpdateCartException()
//        {
//            // Arrange
//            Cart cart = new Cart { Id = 1, CustomerId = 1, Customer = new Customer(), CartItems = new List<CartItem>() };

//            // Act & Assert
//            Assert.Throws<NoCartWithGivenIdException>(() => repository.Update(cart));
//        }

//        [Test]
//        public void DeleteCartException()
//        {
//            // Arrange & Act & Assert
//            Assert.Throws<NoCartWithGivenIdException>(() => repository.Delete(999));
//        }
//    }
//}
using NUnit.Framework;
using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingAppTest
{
    public class CartTests
    {
        IRepository<int, Cart> repository;

        [SetUp]
        public void Setup()
        {
            repository = new CartRepository();
        }

        [Test]
        public void AddCartSuccess()
        {
            // Arrange
            Cart cart = new Cart { Id = 1, CustomerId = 101, Customer = new Customer(), CartItems = new List<CartItem>() };

            // Act
            var result = repository.Add(cart).Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cart, result);
        }

        [Test]
        public void AddDuplicateCartFail()
        {
            // Arrange
            Cart cart = new Cart { Id = 1, CustomerId = 101, Customer = new Customer(), CartItems = new List<CartItem>() };

            // Act
            repository.Add(cart);

            // Assert
            Assert.Throws<DuplicateCartException>(() => repository.Add(cart));
        }
        [Test]
        public void AddDuplicateCartFailMore()
        {
            // Arrange
            Cart cart = new Cart { Id = 1, CustomerId = 101, Customer = new Customer(), CartItems = new List<CartItem>() };
            Cart cart1 = new Cart { Id = 1, CustomerId = 101, Customer = new Customer(), CartItems = new List<CartItem>() };

            // Act
            repository.Add(cart);

            // Assert
            Assert.Throws<DuplicateCartException>(() => repository.Add(cart1));
        }

        [Test]
        public void GetByKeyCartExistsSuccess()
        {
            // Arrange
            Cart cart = new Cart { Id = 1, CustomerId = 101, Customer = new Customer(), CartItems = new List<CartItem>() };
            repository.Add(cart);

            // Act
            var result = repository.GetByKey(cart.Id).Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cart, result);
        }

        [Test]
        public void GetByKeyException()
        {
            // Act & Assert
            Assert.Throws<NoCartWithGivenIdException>(() => repository.GetByKey(999));
        }
        [Test]
        public void GetAllCartSuccess()
        {
            // Arrange
            Cart cart1 = new Cart { Id = 1, CustomerId = 101, Customer = new Customer(), CartItems = new List<CartItem>() };

            repository.Add(cart1);

            // Act
            var result = repository.GetAll().Result;

            // Assert
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetAllCartSuccessException()
        {
            // Arrange
            Cart cart1 = new Cart { Id = 1, CustomerId = 101, Customer = new Customer(), CartItems = new List<CartItem>() };
            Cart cart2 = new Cart { Id = 1, CustomerId = 101, Customer = new Customer(), CartItems = new List<CartItem>() };

            repository.Add(cart1);
            
            // Assert
            Assert.Throws<DuplicateCartException>(() => repository.Add(cart2));
            
        }

        [Test]
        public void GetAllCartFailException()
        {
            // Assert
            Assert.IsNull( repository.GetAll());
        }

        [Test]
        public void UpdateCartSuccess()
        {
            // Arrange
            Cart cart = new Cart { Id = 1, CustomerId = 101, Customer = new Customer(), CartItems = new List<CartItem>() };
            repository.Add(cart);

            // Modify the cart
            cart.CustomerId = 102;

            // Act
            var result = repository.Update(cart).Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cart, result);
        }

        [Test]
        public void UpdateCartExceptionThrown()
        {
            // Arrange
            Cart cart = new Cart { Id = 1, CustomerId = 101, Customer = new Customer(), CartItems = new List<CartItem>() };

            // Act & Assert
            Assert.Throws<NoCartWithGivenIdException>(() => repository.Update(cart));
        }

        [Test]
        public void UpdateCartException()
        {
            // Arrange
            Cart cart1 = new Cart { Id = 1, CustomerId = 101, Customer = new Customer(), CartItems = new List<CartItem>() };
            Cart cart2 = new Cart { Id = 2, CustomerId = 102, Customer = new Customer(), CartItems = new List<CartItem>() };

            repository.Add(cart1);

            // Act & Assert
            Assert.Throws<NoCartWithGivenIdException>(() => repository.Update(cart2));
        }

        [Test]
        public void DeleteCartSuccess()
        {
            // Arrange
            Cart cart = new Cart { Id = 1, CustomerId = 101, Customer = new Customer(), CartItems = new List<CartItem>() };
            repository.Add(cart);

            // Act
            var result = repository.Delete(cart.Id).Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cart, result);
        }

        [Test]
        public void DeleteCartException()
        {
            // Act & Assert
            Assert.Throws<NoCartWithGivenIdException>(() => repository.Delete(999));
        }

        [Test]
        public void DeleteCartFail()
        {
            // Arrange
            Cart cart = new Cart { Id = 1, CustomerId = 101, Customer = new Customer(), CartItems = new List<CartItem>() };

            // Act
            repository.Add(cart);

            // Assert
            Assert.Throws<NoCartWithGivenIdException>(() => repository.Delete(999));
        }
    }
}
