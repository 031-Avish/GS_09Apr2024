using ShoppingBLLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exception;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartItemRepository : AbstractRepository<int, CartItem>
    {
        public override async Task<CartItem> Delete(int key)
        {
            CartItem cartitem = await GetByKey(key);
            if (cartitem != null)
            {
                items.Remove(cartitem);
            }
            return cartitem;
        }

        public override async Task<CartItem> GetByKey(int key)
        {
            if (items.Count > 0)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].CartId == key)
                        return items[i];
                }
            }
            throw new NoCartItemWithGivenIdException();
        }

        public override async Task<CartItem> Add(CartItem item)
        {
            if (items.Count > 0)
            {
                foreach(CartItem cartitem in items)
                {
                    if (item.ProductId == cartitem.ProductId)
                    {
                        throw new DuplicateCartItemException();
                    }
                }
            }
            items.Add(item);
            return item;
        }
        //public override ICollection<CartItem> GetAll()
        //{
        //    if (items.Count > 0)
        //        return items;
        //    throw new NoCartItemWithGivenIdException();
        //}
        public override async Task<CartItem> Update(CartItem item)
        {
            if (items.Count > 0)
            {
                var index = items.FindIndex(c => c.CartId == item.CartId);
                if (index != -1)
                {
                    items[index] = item;
                    return item;
                }
            }
            throw new NoCartItemWithGivenIdException() ;
        }
    }
}
