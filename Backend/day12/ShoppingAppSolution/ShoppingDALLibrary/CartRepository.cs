using ShoppingBLLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exception;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartRepository : AbstractRepository<int, Cart>
    {
        public override Cart Delete(int key)
        {
            Cart cart = GetByKey(key);
            if (cart != null)
            {
                items.Remove(cart);
            }
            return cart;
        }
        [ExcludeFromCodeCoverage ]
        public override Cart Add(Cart item)
        {
            if (items.Count > 0)
            {
                foreach (Cart cart in items)
                {
                    if (cart.Id == item.Id)
                    {
                        throw new DuplicateCartException();
                    }
                }
            }
            items.Add(item);
            return item;

        }
        public override ICollection<Cart> GetAll()
        {
            if(items.Count > 0)
            {
                return items;
            }
            throw new NoCartWithGivenIdException();
        }
        public override Cart GetByKey(int key)
        {
            for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].Id == key)
                        return items[i];
                }
            throw new NoCartWithGivenIdException();
        }

        public override Cart Update(Cart item)
        {

            if (items.Count > 0)
            {
                var index = items.FindIndex(p => p.Id == item.Id);
                if (index != -1)
                {
                    items[index] = item;
                    return item;
                }
            }
            throw new NoCartWithGivenIdException();
           
        }
    }
}
