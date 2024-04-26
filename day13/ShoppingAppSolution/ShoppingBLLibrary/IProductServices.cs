using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface IProductServices
    {
        Product AddProduct(Product product);
        Product GetProductById(int productId);
        List<Product> GetAllProducts();
        Product UpdateProduct(Product product);
        bool DeleteProduct(int productId);
    }
}
