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
    public class ProductRepository : AbstractRepository<int, Product>
    {
        public override Product Delete(int key)
        {
            Product product = GetByKey(key);
            if (product != null)
            {
                items.Remove(product);
            }
            return product;
        }

        public override Product Add(Product item)
        {
            if(items.Count>0)
            {
                foreach(Product product in items)
                {
                    if(product.Id==item.Id)
                    {
                        throw new DuplicateProductException();
                    }
                }
            }
            items.Add(item);
            return item;
        }
        public override ICollection<Product> GetAll()
        {
            if (items.Count > 0)
                return items;
            throw new NoProductWithGivenIdException();
        }
        public override Product GetByKey(int key)
        {
            if (items.Count > 0)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].Id == key)
                        return items[i];
                }
            }
            throw new NoProductWithGivenIdException();
        }

        public override Product Update(Product item)
        {
            if (items.Count > 0)
            {
                var index = items.FindIndex(p => p.Id == item.Id);
                if (index == -1)
                {
                    throw new NoProductWithGivenIdException();
                }
                items[index] = item;
                return item;
            }
            throw new NoProductWithGivenIdException();
        }
    }
}
