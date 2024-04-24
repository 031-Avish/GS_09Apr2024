using ShoppingModelLibrary;
using ShoppingModelLibrary.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartItemRepository : AbstractRepository<int, CartItem>
    {
        public override CartItem Delete(int key)
        {
            CartItem cartitem = GetByKey(key);
            if (cartitem != null)
            {
                items.Remove(cartitem);
            }
            return cartitem;
        }

        public override CartItem GetByKey(int key)
        {
            if (items.Count > 0)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].CartId == key)
                        return items[i];
                }
            }
            throw new NoCartWithGivenIdException();
        }

        public override CartItem Update(CartItem item)
        {
            CartItem cartitem = GetByKey(item.CartId);
            if (cartitem!= null)
            {
                cartitem = item;
            }
            return cartitem;
        }
    }
}
