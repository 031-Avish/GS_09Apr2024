using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary.Exception;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppTest
{
    public class CartItemBLTest
    {
        private CartItemBL _cartItemBL;
        private IRepository<int, CartItem> _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new CartItemRepository() ;
            _cartItemBL = new CartItemBL(_repository);
        }

        [Test]
        public void AddCartItemSuccess()
        {
            // Arrange
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 1, Price = 10.0, Discount = 0.0, PriceExpiryDate = DateTime.Now };

            // Act
            var result = _cartItemBL.AddCartItem(cartItem);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cartItem, result);
        }
        [Test]
        public void AddCartItemFail()
        {
            // Arrange
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 10, Price = 10.0, Discount = 0.0, PriceExpiryDate = DateTime.Now };

            Assert.Throws<MaxQuantityExceededException>(() => _cartItemBL.AddCartItem(cartItem));
        }
        [Test]
        public void DeleteCartItemSuccess()
        {
            // Arrange
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 1, Price = 10.0, Discount = 0.0, PriceExpiryDate = DateTime.Now };
            _cartItemBL.AddCartItem(cartItem);

            // Act
            var result = _cartItemBL.DeleteCartItem(cartItem.CartId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void UpdateCartItemSuccess()
        {
            // Arrange
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 1, Price = 10.0, Discount = 0.0, PriceExpiryDate = DateTime.Now };
            _cartItemBL.AddCartItem(cartItem);

            // Modify the cart item
            cartItem.Quantity = 2;

            // Act
            var result = _cartItemBL.UpdateCartItem(cartItem);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cartItem, result);
        }
        [Test]
        public void UpdateItemFail()
        {
            // Arrange
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 1, Price = 10.0, Discount = 0.0, PriceExpiryDate = DateTime.Now };
            _cartItemBL.AddCartItem(cartItem);
            cartItem.Quantity = 10;
            Assert.Throws<MaxQuantityExceededException>(() => _cartItemBL.UpdateCartItem(cartItem));
        }
        [Test]
        public void GetCartItemByIdSuccess()
        {
            // Arrange
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 1, Price = 10.0, Discount = 0.0, PriceExpiryDate = DateTime.Now };
            _cartItemBL.AddCartItem(cartItem);

            // Act
            var result = _cartItemBL.GetCartItemById(cartItem.CartId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cartItem, result);
        }

        [Test]
        public void GetCartItemByIdException()
        {
            // Arrange & Act & Assert
            Assert.Throws<NoCartItemWithGivenIdException>(() => _cartItemBL.GetCartItemById(999));
        }

        [Test]
        public void UpdateCartItemExceptionThrown()
        {
            // Arrange
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 1, Price = 10.0, Discount = 0.0, PriceExpiryDate = DateTime.Now };

            // Act & Assert
            Assert.Throws<NoCartItemWithGivenIdException>(() => _cartItemBL.UpdateCartItem(cartItem));
        }

        [Test]
        public void DeleteCartItemException()
        {
            // Arrange & Act & Assert
            Assert.Throws<NoCartItemWithGivenIdException>(() => _cartItemBL.DeleteCartItem(999));
        }
        [Test]
        public void ValidateMaxQuantityInCartSuccess()
        {
            // Arrange

            CartItem cartItem1 = new CartItem() { CartId = 1, ProductId = 1, Quantity = 4 };
            CartItem cartItem = new CartItem() { CartId = 1, ProductId = 2, Quantity = 7 };

            // Act
            var result = _cartItemBL.ValidateMaxQuantityInCartItem(cartItem);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateMaxQuantityInCartFailure()
        {
            // Arrange
            
            CartItem cartItem1 = new CartItem() { CartId = 1, ProductId = 1, Quantity = 4 };
            CartItem cartItem = new CartItem() { CartId = 1, ProductId = 2, Quantity = 3 };

            // Act
            var result = _cartItemBL.ValidateMaxQuantityInCartItem(cartItem);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
