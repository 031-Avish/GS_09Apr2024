using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CartBL
    {
        private readonly IRepository<int, Cart> _cartRepository;
        private readonly IProductServices _productServices;

        [ExcludeFromCodeCoverage]
        public CartBL()
        {
            _cartRepository = new CartRepository();
            _productServices = new ProductBL();
        }
        public CartBL(IRepository<int, Cart> cartRepository, IProductServices productServices)
        {
            _cartRepository = cartRepository;
            _productServices = productServices;
        }

        // to check if the cart is eligible for discount
        public bool IsDiscountEligible(Cart cart)
        {
            double totalOrderValue = 0;
            int itemCount = 0;

            foreach (var cartItem in cart.CartItems)
            {
                Product product = _productServices.GetProductById(cartItem.ProductId);
                totalOrderValue += (cartItem.Quantity * product.Price);
                itemCount += cartItem.Quantity;
            }

            if (itemCount == 3 && totalOrderValue >= 1500)
            {
                // true means eligible for discount of 5%
                return true;
            }
            return false;
        }

        // Method to calculate shipping charge based on total order value
        public double CalculateShippingCharge(Cart cart)
        {
            double totalOrderValue = 0;

            foreach (var cartItem in cart.CartItems)
            {
                Product product = _productServices.GetProductById(cartItem.ProductId);
                totalOrderValue += (cartItem.Quantity * product.Price);
            }
            if (totalOrderValue < 100)
            {
                return 100;
            }
            return 0;
        }
        public bool ValidateMaxQuantityInCart(Cart cart)
        {
            foreach (var cartItem in cart.CartItems)
            {
                if (cartItem.Quantity > 5)
                {
                    return false;
                }
            }
            return true;
        }

        public Cart AddCart(Cart cart)
        {
            if (!ValidateMaxQuantityInCart(cart))
            {
                throw new MaxQuantityExceededException();
            }

            var addedCart = _cartRepository.Add(cart);
            if (addedCart != null)
            {
                return addedCart;
            }
            throw new DuplicateCartException();
        }


        public Cart UpdateCart(Cart cart)
        {
            var updatedCart = _cartRepository.Update(cart);
            if (updatedCart != null)
            {
                return updatedCart;
            }
            throw new NoCartWithGivenIdException();
        }

        public Cart GetCartById(int cartId)
        {
            var cart = _cartRepository.GetByKey(cartId);
            if (cart != null)
            {
                return cart;
            }
            throw new NoCartWithGivenIdException();
        }

        public bool DeleteCart(int cartId)
        {
            var deletedCart = _cartRepository.Delete(cartId);
            if (deletedCart != null)
            {
                return true;
            }
            throw new NoCartWithGivenIdException();
        }
    }
}
