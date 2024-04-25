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
    public class CartBL : ICartServices
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
                return true;
            }
            return false;
        }

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
        public bool ValidateMaxQuantityInCartItem(CartItem cartitem)
        {
            if(cartitem.Quantity > 5 ) {
                return false; 
            }
            return true;
        }
        public bool ValidateMaxQuantityInCart(Cart cart)
        {
            foreach(var cartItem in cart.CartItems)
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
            if (cart.CustomerId == 0)
                throw new CustomerIdNotPresentException();
            if(!ValidateMaxQuantityInCart(cart))
            {
                throw new MaxQuantityExceededException();
            }
            Cart addedCart = _cartRepository.Add(cart);
            return addedCart;
        }
        public Cart AddItemToCart(CartItem cartItem)
        {
            if (cartItem.CartId != 0)
            {
                Cart cart = GetCartById(cartItem.CartId);
                if (!ValidateMaxQuantityInCartItem(cartItem))
                {
                    throw new MaxQuantityExceededException();
                }
                foreach (CartItem ci in cart.CartItems)
                {
                    if (ci.ProductId == cartItem.ProductId)
                    {
                        throw new DuplicateCartItemException();
                    }
                }
                cart.CartItems.Add(cartItem);
                Cart updatedCart = UpdateCart(cart);
                return updatedCart;
            }
            throw new CustomerIdNotPresentException();
        }

        public Cart UpdateCart(Cart cart)
        {
            var updatedCart = _cartRepository.Update(cart);
            return updatedCart;
        }

        public Cart GetCartById(int cartId)
        {
            var cart = _cartRepository.GetByKey(cartId);
            return cart;
        }

        public bool DeleteCart(int cartId)
        {
            var deletedCart = _cartRepository.Delete(cartId);
            return true;
        }

        public double CalculateTotalPriceOfItemInCart(Cart cart)
        {
            if (cart.CartItems.Count <= 0)
                throw new CartIsEmptyException();
            double totalPrice = 0;
            foreach (var cartItem in cart.CartItems)
            {
                Product product = _productServices.GetProductById(cartItem.ProductId);
                totalPrice += (cartItem.Quantity * product.Price);
            }
            totalPrice += CalculateShippingCharge(cart);
            if (IsDiscountEligible(cart))
                totalPrice = (0.95 * totalPrice);
            return totalPrice;
        }

        //public Cart AddCart(Cart cart)
        //{
        //    if (cart.CustomerId == 0)
        //        throw new CustomerIdNotPresentException();
        //    Cart addedCart=_cartRepository.Add(cart);
        //    if (addedCart != null)
        //    {
        //        return addedCart;
        //    }
        //    throw new DuplicateCartException();
        //}
        //public Cart AddItemToCart(CartItem cartItem)
        //{
        //    if (cartItem.CartId != 0) {
        //        Cart cart = GetCartById(cartItem.CartId);
        //        if (!ValidateMaxQuantityInCart(cart))
        //        {
        //            throw new MaxQuantityExceededException();
        //        }
        //        foreach( CartItem ci in cart.CartItems)
        //        {
        //            if(ci.ProductId == cartItem.ProductId)
        //            {
        //                throw new DuplicateCartItemException();
        //            }
        //        }
        //        cart.CartItems.Add(cartItem);
        //        Cart updatedCart=UpdateCart(cart);
        //        return updatedCart;
        //    }
        //    throw new CustomerIdNotPresentException();
        //}

        //public Cart UpdateCart(Cart cart)
        //{
        //    var updatedCart = _cartRepository.Update(cart);
        //    if (updatedCart != null)
        //    {
        //        return updatedCart;
        //    }
        //    throw new NoCartWithGivenIdException();
        //}

        //public Cart GetCartById(int cartId)
        //{
        //    var cart = _cartRepository.GetByKey(cartId);
        //    if (cart != null)
        //    {
        //        return cart;
        //    }
        //    throw new NoCartWithGivenIdException();
        //}

        //public bool DeleteCart(int cartId)
        //{
        //    var deletedCart = _cartRepository.Delete(cartId);
        //    if (deletedCart != null)
        //    {
        //        return true;
        //    }
        //    throw new NoCartWithGivenIdException();
        //}

        //public double CalculateTotalPriceOfItemInCart(Cart cart)
        //{
        //    if (cart.CartItems.Count <= 0)
        //        throw new CartIsEmptyException();
        //    double totalPrice = 0;
        //    foreach(var cartItem in cart.CartItems)
        //    {
        //        Product product = _productServices.GetProductById(cartItem.ProductId);
        //        totalPrice += (cartItem.Quantity * product.Price);
        //    }
        //    totalPrice += CalculateShippingCharge(cart);
        //    if (IsDiscountEligible(cart))
        //        totalPrice = (0.95 * totalPrice);
        //    return totalPrice;
        //}
    }
}
