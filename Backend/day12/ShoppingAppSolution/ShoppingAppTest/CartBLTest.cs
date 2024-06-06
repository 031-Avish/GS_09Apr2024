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
        public void AddItemToCartSuccess()
        {
            // Arrange
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 101, Quantity = 2, Price = 10.99, Discount = 1.50, PriceExpiryDate = DateTime.Now.AddDays(7) };
            Cart cart = new Cart { Id = 1, CustomerId = 101, Customer = new Customer(), CartItems = new List<CartItem>() };
            _cartBL.AddCart(cart);

            // Act
            var result = _cartBL.AddItemToCart(cartItem);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.CartItems.Count);
            Assert.AreEqual(cartItem, result.CartItems[0]);
        }
        [Test]
        public void AddCartMaxQuantityExceededException()
        {
            // Arrange

            Cart cart = new Cart { Id = 1, CustomerId = 101, Customer = new Customer(),
                CartItems = new List<CartItem>() {
            new CartItem { CartId = 1, ProductId = 101, Quantity = 6, Price = 10.99, Discount = 1.50,
                PriceExpiryDate = DateTime.Now.AddDays(7) },
            new CartItem { CartId = 1, ProductId = 101, Quantity = 6, Price = 10.99,
                Discount = 1.50, PriceExpiryDate = DateTime.Now.AddDays(7)}
        }
    };
            

            // Act & Assert
            Assert.Throws<MaxQuantityExceededException>(() => _cartBL.AddCart(cart));
        }

        [Test]
        public void AddItemToCartMaxQuantityExceededException()
        {
            // Arrange
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 101, Quantity = 6, Price = 10.99, Discount = 1.50, PriceExpiryDate = DateTime.Now.AddDays(7) };
            Cart cart = new Cart { Id = 1, CustomerId = 101, Customer = new Customer(), CartItems = new List<CartItem>() };
            _cartBL.AddCart(cart);

            // Act & Assert
            Assert.Throws<MaxQuantityExceededException>(() => _cartBL.AddItemToCart(cartItem));
        }

        [Test]
        public void AddItemToCartDuplicateCartItemException()
        {
            // Arrange
            CartItem cartItem1 = new CartItem { CartId = 1, ProductId = 101, Quantity = 2, Price = 10.99, Discount = 1.50, PriceExpiryDate = DateTime.Now.AddDays(7) };
            CartItem cartItem2 = new CartItem { CartId = 1, ProductId = 101, Quantity = 1, Price = 5.99, Discount = 0.75, PriceExpiryDate = DateTime.Now.AddDays(5) };
            Cart cart = new Cart { Id = 1, CustomerId = 101, Customer = new Customer(), CartItems = new List<CartItem>() };
            _cartBL.AddCart(cart);
            _cartBL.AddItemToCart(cartItem1);

            // Act & Assert
            Assert.Throws<DuplicateCartItemException>(() => _cartBL.AddItemToCart(cartItem2));
        }

        [Test]
        public void AddItemToCartCustomerIdNotPresentException()
        {
            // Arrange
            CartItem cartItem = new CartItem { CartId = 0, ProductId = 101, Quantity = 2, Price = 10.99, Discount = 1.50, PriceExpiryDate = DateTime.Now.AddDays(7) };

            // Act & Assert
            Assert.Throws<CustomerIdNotPresentException>(() => _cartBL.AddItemToCart(cartItem));
        }

        [Test]
        public void AddCartSuccess()
        {
            // Arrange
            Cart cart = new Cart { Id = 1,CustomerId=101 };
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
        public void AddCartFail()
        {
            // Arrange
            Cart cart = new Cart { Id = 1 };
            cart.CartItems = new List<CartItem>
            {
                new CartItem { ProductId = 1, Quantity = 1 }
            };
            
            Assert.Throws<CustomerIdNotPresentException>(()=> _cartBL.AddCart(cart));
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
        public void IsDiscountEligibleFail()
        {
            // Arrange
            Cart cart = new Cart();
            cart.CartItems = new List<CartItem>
            {
                new CartItem { ProductId = 1, Quantity = 5 }
            };
            _services.AddProduct(new Product { Id = 1, Price = 100 });

            // Act
            var result = _cartBL.IsDiscountEligible(cart);

            // Assert
            Assert.IsFalse(result);
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
            Cart cart = new Cart() { Id=1,CustomerId=101 , CartItems=new List<CartItem>() };
            
            Cart cart1= _cartBL.AddCart(cart);
            CartItem cartItem1 = new CartItem() { CartId = cart1.Id, ProductId = 1, Quantity = 4 };
            CartItem cartItem = new CartItem() { CartId = cart1.Id, ProductId = 2, Quantity = 7 };

            // Act
            var result = _cartBL.ValidateMaxQuantityInCartItem(cartItem);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateMaxQuantityInCartFailure()
        {
            // Arrange
            Cart cart = new Cart() { Id = 1, CustomerId = 101, CartItems = new List<CartItem>() };

            Cart cart1 = _cartBL.AddCart(cart);
            CartItem cartItem1 = new CartItem() { CartId = cart1.Id, ProductId = 1, Quantity = 4 };
            CartItem cartItem = new CartItem() { CartId = cart1.Id, ProductId = 2, Quantity = 3 };

            // Act
            var result = _cartBL.ValidateMaxQuantityInCartItem(cartItem);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
