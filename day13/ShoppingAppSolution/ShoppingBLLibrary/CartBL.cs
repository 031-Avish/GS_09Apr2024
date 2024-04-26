using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exception;
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
        private readonly ICustomerServices _customerServices;

        [ExcludeFromCodeCoverage]
        public CartBL()
        {
            _cartRepository = new CartRepository();
            _productServices = new ProductBL();
            _customerServices = new CustomerBL();
        }
        public CartBL(IRepository<int, Cart> cartRepository, IProductServices productServices, ICustomerServices customerServices)
        {
            _cartRepository = cartRepository;
            _productServices = productServices;
            _customerServices = customerServices;
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
                throw new CartIdNotPresentException();
            if(!ValidateMaxQuantityInCart(cart))
            {
                throw new MaxQuantityExceededException();
            }
            Cart addedCart = _cartRepository.Add(cart);
            return addedCart;
        }
        public Cart AddItemToCart(CartItem cartItem, int customerId)
        {
            List<Cart> carts = (List<Cart>)_cartRepository.GetAll();
            Cart cart = null;
            if (carts!=null)
                cart = carts.FirstOrDefault(c => c.CustomerId == customerId);
            if (cart == null)
            {
                Customer customer = _customerServices.GetCustomerById(customerId);
                Cart cart1 =  new Cart {CustomerId = customerId, Customer=customer,CartItems=new List<CartItem>()}; 
                cart= AddCart(cart1);
            }
            cartItem.CartId = cart.Id;
            
            //Cart cart = GetCartById(cartItem.CartId);
            if (!ValidateMaxQuantityInCartItem(cartItem))
            {
                throw new MaxQuantityExceededException();
            }
            int productQuantity= (int)(_productServices.GetProductById(cartItem.ProductId)?.QuantityInHand);
            if(productQuantity < cartItem.Quantity)
                throw new ProductNotAvailableException();

            foreach (CartItem ci in cart.CartItems)
            {
                if (ci.ProductId == cartItem.ProductId)
                {
                    throw new DuplicateCartItemException();
                }
            }
           

            cart.CartItems.Add(cartItem);
            if (IsDiscountEligible(cart))
            {
                foreach (var cartitem in cart.CartItems)
                {
                    cartitem.Discount = 5;

                }
            }
            Cart updatedCart = UpdateCart(cart);
            return updatedCart;
        }

        public Cart RemoveItemFromCart(int cartId, int productId)
        {
            Cart cart = _cartRepository.GetByKey(cartId);

            if (cart == null)
            {
                throw new NoCartWithGivenIdException();
            }

            CartItem cartItemToRemove = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (cartItemToRemove == null)
            {
                throw new NoCartItemWithGivenIdException();
            }

            cart.CartItems.Remove(cartItemToRemove);

            if (IsDiscountEligible(cart))
            {
                foreach (var cartitem in cart.CartItems)
                {
                    cartitem.Discount = 5;

                }
            }
            Cart updatedCart = UpdateCart(cart);

            return updatedCart;
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
            {
                
                totalPrice = (0.95 * totalPrice);
            }

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
