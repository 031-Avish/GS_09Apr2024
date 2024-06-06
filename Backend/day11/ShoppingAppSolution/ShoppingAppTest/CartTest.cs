using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppTest
{
    public  class CartTest
    {
        private CartRepository repository;

        [SetUp]
        public void Setup()
        {
            repository = new CartRepository();
        }

        [Test]
        public void AddCartSuccess()
        {
            // Arrange
            Cart cart = new Cart { Id = 1, CustomerId = 1, Customer = new Customer(), CartItems = new List<CartItem>() };

            // Act
            var result = repository.Add(cart);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cart, result);
        }

        [Test]
        public void DeleteCartSuccess()
        {
            // Arrange
            Cart cart = new Cart { Id = 1, CustomerId = 1, Customer = new Customer(), CartItems = new List<CartItem>() };
            repository.Add(cart);

            // Act
            var result = repository.Delete(cart.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cart, result);
            Assert.IsFalse(repository.GetAll().Contains(cart));
        }

        [Test]
        public void UpdateCartSuccess()
        {
            // Arrange
            Cart cart = new Cart { Id = 1, CustomerId = 1, Customer = new Customer(), CartItems = new List<CartItem>() };
            repository.Add(cart);

            // Modify the cart
            cart.CustomerId = 2;

            // Act
            var result = repository.Update(cart);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cart, result);
            Assert.IsTrue(repository.GetAll().Contains(cart));
        }

        [Test]
        public void GetByKeyCartExistsSuccess()
        {
            // Arrange
            Cart cart = new Cart { Id = 1, CustomerId = 1, Customer = new Customer(), CartItems = new List<CartItem>() };
            repository.Add(cart);

            // Act
            var result = repository.GetByKey(cart.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cart, result);
        }

        [Test]
        public void GetByKeyException()
        {
            // Arrange & Act & Assert
            Assert.Throws<NoCartWithGivenIdException>(() => repository.GetByKey(999));
        }

        [Test]
        public void UpdateCartException()
        {
            // Arrange
            Cart cart = new Cart { Id = 1, CustomerId = 1, Customer = new Customer(), CartItems = new List<CartItem>() };

            // Act & Assert
            Assert.Throws<NoCartWithGivenIdException>(() => repository.Update(cart));
        }

        [Test]
        public void DeleteCartException()
        {
            // Arrange & Act & Assert
            Assert.Throws<NoCartWithGivenIdException>(() => repository.Delete(999));
        }
    }
}
