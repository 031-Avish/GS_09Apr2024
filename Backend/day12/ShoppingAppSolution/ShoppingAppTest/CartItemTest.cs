using NUnit.Framework;
using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exception;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingAppTest
{
    public class CartItemTests
    {
        IRepository<int, CartItem> repository;

        [SetUp]
        public void Setup()
        {
            repository = new CartItemRepository();
        }

        [Test]
        public void AddCartItemSuccess()
        {
            // Arrange
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 101, Quantity = 2, Price = 10.99, Discount = 1.50, PriceExpiryDate = DateTime.Now.AddDays(7) };

            // Act
            var result = repository.Add(cartItem);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cartItem, result);
        }

        [Test]
        public void AddDuplicateCartItemFail()
        {
            // Arrange
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 101, Quantity = 2, Price = 10.99, Discount = 1.50, PriceExpiryDate = DateTime.Now.AddDays(7) };

            // Act
            repository.Add(cartItem);

            // Assert
            Assert.Throws<DuplicateCartItemException>(() => repository.Add(cartItem));
        }

        [Test]
        public void GetByKeyCartItemExistsSuccess()
        {
            // Arrange
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 101, Quantity = 2, Price = 10.99, Discount = 1.50, PriceExpiryDate = DateTime.Now.AddDays(7) };
            repository.Add(cartItem);

            // Act
            var result = repository.GetByKey(cartItem.CartId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cartItem, result);
        }

        [Test]
        public void GetByKeyException()
        {
            // Act & Assert
            Assert.Throws<NoCartItemWithGivenIdException>(() => repository.GetByKey(999));
        }

        [Test]
        public void GetAllCartItemSuccess()
        {
            // Arrange
            CartItem cartItem1 = new CartItem { CartId = 1, ProductId = 101, Quantity = 2, Price = 10.99, Discount = 1.50, PriceExpiryDate = DateTime.Now.AddDays(7) };
            CartItem cartItem2 = new CartItem { CartId = 2, ProductId = 102, Quantity = 1, Price = 5.99, Discount = 0.75, PriceExpiryDate = DateTime.Now.AddDays(5) };

            repository.Add(cartItem1);
            repository.Add(cartItem2);

            // Act
            var result = repository.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetAllCartItemFailException()
        {
            // Assert
            Assert.Throws<NoCartItemWithGivenIdException>(() => repository.GetAll());
        }

        [Test]
        public void UpdateCartItemSuccess()
        {
            // Arrange
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 101, Quantity = 2, Price = 10.99, Discount = 1.50, PriceExpiryDate = DateTime.Now.AddDays(7) };
            repository.Add(cartItem);

            // Modify the cart item
            cartItem.Quantity = 3;

            // Act
            var result = repository.Update(cartItem);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cartItem, result);
        }

        [Test]
        public void UpdateCartItemExceptionThrown()
        {
            // Arrange
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 101, Quantity = 2, Price = 10.99, Discount = 1.50, PriceExpiryDate = DateTime.Now.AddDays(7) };

            // Act & Assert
            Assert.Throws<NoCartItemWithGivenIdException>(() => repository.Update(cartItem));
        }

        [Test]
        public void UpdateCartItemException()
        {
            // Arrange
            CartItem cartItem1 = new CartItem { CartId = 1, ProductId = 101, Quantity = 2, Price = 10.99, Discount = 1.50, PriceExpiryDate = DateTime.Now.AddDays(7) };
            CartItem cartItem2 = new CartItem { CartId = 2, ProductId = 102, Quantity = 1, Price = 5.99, Discount = 0.75, PriceExpiryDate = DateTime.Now.AddDays(5) };

            repository.Add(cartItem1);

            // Act & Assert
            Assert.Throws<NoCartItemWithGivenIdException>(() => repository.Update(cartItem2));
        }

        [Test]
        public void DeleteCartItemSuccess()
        {
            // Arrange
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 101, Quantity = 2, Price = 10.99, Discount = 1.50, PriceExpiryDate = DateTime.Now.AddDays(7) };
            repository.Add(cartItem);

            // Act
            var result = repository.Delete(cartItem.CartId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cartItem, result);
        }

        [Test]
        public void DeleteCartItemException()
        {
            // Act & Assert
            Assert.Throws<NoCartItemWithGivenIdException>(() => repository.Delete(999));
        }

        [Test]
        public void DeleteCartItemFail()
        {
            // Arrange
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 101, Quantity = 2, Price = 10.99, Discount = 1.50, PriceExpiryDate = DateTime.Now.AddDays(7) };

            // Act
            repository.Add(cartItem);

            // Assert
            Assert.Throws<NoCartItemWithGivenIdException>(() => repository.Delete(999));
        }
    }
}
