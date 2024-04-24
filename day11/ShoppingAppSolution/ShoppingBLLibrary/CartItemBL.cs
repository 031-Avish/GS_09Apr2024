using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exception;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ShoppingBLLibrary
{
    public class CartItemBL:ICartItemServices
    {
        private readonly IRepository<int, CartItem> _cartItemRepository;

        [ExcludeFromCodeCoverage]
        public CartItemBL()
        {
            _cartItemRepository = new CartItemRepository();
        }

        public CartItemBL(IRepository<int, CartItem> cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public CartItem AddCartItem(CartItem cartItem)
        {
            var addedCartItem = _cartItemRepository.Add(cartItem);
            if (addedCartItem != null)
            {
                return addedCartItem;
            }
            throw new DuplicateCartItemException();
        }

        public CartItem UpdateCartItem(CartItem cartItem)
        {
            var updatedCartItem = _cartItemRepository.Update(cartItem);
            if (updatedCartItem != null)
            {
                return updatedCartItem;
            }
            throw new NoCartItemWithGivenIdException();
        }

        public CartItem GetCartItemById(int cartItemId)
        {
            var cartItem = _cartItemRepository.GetByKey(cartItemId);
            if (cartItem != null)
            {
                return cartItem;
            }
            throw new NoCartItemWithGivenIdException();
        }

        [ExcludeFromCodeCoverage]
        public List<CartItem> GetAllCartItems()
        {
            var cartItems = _cartItemRepository.GetAll()?.ToList();
            if (cartItems != null)
            {
                return cartItems;
            }
            throw new NoCartItemWithGivenIdException();
        }

        public bool DeleteCartItem(int cartItemId)
        {
            var deletedCartItem = _cartItemRepository.Delete(cartItemId);
            if (deletedCartItem != null)
            {
                return true;
            }
            throw new NoCartItemWithGivenIdException();
        }
    }
}
