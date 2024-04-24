using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppTest
{
    public class CartBLTest
    {
        
        private CartBL _cartBL;
        private IRepository<int, Cart> _repository;
        private IProductServices _services;

        [SetUp]
        public void Setup()
        {
            _repository = new CartRepository();
            _services = new ProductBL();

            _cartBL = new CartBL(_repository, _services);
        }

        [Test]
        public void AddCartSuccess()
        {
            // Arrange
            Cart cart = new Cart { Id = 1 };
            cart.CartItems = new List<CartItem>
            {
                new CartItem { ProductId = 1, Quantity = 1 }
            };
            // Act
            var result = _cartBL.AddCart(cart);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cart, result);
        }

        [Test]
        public void UpdateCartSuccess()
        {
            // Arrange
            Cart cart = new Cart { Id = 1 };
            _repository.Add(cart);

            // Act
            var result = _cartBL.UpdateCart(cart);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cart, result);
        }

        [Test]
        public void UpdateCartException()
        {
            // Arrange
            Cart cart = new Cart { Id = 1 };

            // Act & Assert
            Assert.Throws<NoCartWithGivenIdException>(() => _cartBL.UpdateCart(cart));
        }

        [Test]
        public void GetCartByIdSuccess()
        {
            // Arrange
            Cart cart = new Cart { Id = 1 };
            _repository.Add(cart);

            // Act
            var result = _cartBL.GetCartById(cart.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cart, result);
        }

        [Test]
        public void GetCartByIdException()
        {
            // Arrange & Act & Assert
            Assert.Throws<NoCartWithGivenIdException>(() => _cartBL.GetCartById(999));
        }

        [Test]
        public void DeleteCart_Success()
        {
            // Arrange
            Cart cart = new Cart { Id = 1 };
            _repository.Add(cart);

            // Act
            var result = _cartBL.DeleteCart(cart.Id);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void DeleteCartException()
        {
            // Arrange & Act & Assert
            Assert.Throws<NoCartWithGivenIdException>(() => _cartBL.DeleteCart(999));
        }

        [Test]
        public void IsDiscountEligibleSuccess()
        {
            // Arrange
            Cart cart = new Cart();
            cart.CartItems = new List<CartItem>
            {
                new CartItem { ProductId = 1, Quantity = 3 }
            };
            _services.AddProduct(new Product { Id = 1, Price = 500 }); 

            // Act
            var result = _cartBL.IsDiscountEligible(cart);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CalculateShippingChargeSuccess()
        {
            // Arrange
            Cart cart = new Cart();
            cart.CartItems = new List<CartItem>
            {
                new CartItem { ProductId = 1, Quantity = 1 }
            };
            _services.AddProduct(new Product { Id = 1, Price = 50 }); // Assuming price is 50 for this product

            // Act
            var result = _cartBL.CalculateShippingCharge(cart);

            // Assert
            Assert.AreEqual(100, result);
        }

        [Test]
        public void CalculateShippingCharge()
        {
            // Arrange
            Cart cart = new Cart();
            cart.CartItems = new List<CartItem>
            {
                new CartItem { ProductId = 1, Quantity = 2 }
            };
            _services.AddProduct(new Product { Id = 1, Price = 60 }); // Assuming price is 60 for this product

            // Act
            var result = _cartBL.CalculateShippingCharge(cart);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ValidateMaxQuantityInCartSuccess()
        {
            // Arrange
            Cart cart = new Cart();
            cart.CartItems = new List<CartItem>
            {
                new CartItem { Quantity = 4 },
                new CartItem { Quantity = 2 }
            };

            // Act
            var result = _cartBL.ValidateMaxQuantityInCart(cart);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateMaxQuantityInCartFailure()
        {
            // Arrange
            Cart cart = new Cart();
            cart.CartItems = new List<CartItem>
            {
                new CartItem { Quantity = 6 },
                new CartItem { Quantity = 2 }
            };

            // Act
            var result = _cartBL.ValidateMaxQuantityInCart(cart);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
