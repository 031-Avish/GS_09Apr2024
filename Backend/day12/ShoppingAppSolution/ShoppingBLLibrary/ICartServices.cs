using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface ICartServices
    {
        Cart AddCart(Cart cart);
        Cart AddItemToCart(CartItem cartItem);
        Cart UpdateCart(Cart cart);
        Cart GetCartById(int cartId);
        bool DeleteCart(int cartId);
        double CalculateTotalPriceOfItemInCart(Cart cart);
    }
}
