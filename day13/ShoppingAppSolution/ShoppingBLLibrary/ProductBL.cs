using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class ProductBL : IProductServices
    {
        private readonly IRepository<int, Product> _productRepository;

        public ProductBL()
        {
            _productRepository = new ProductRepository();
        }

        public ProductBL(IRepository<int, Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public Product AddProduct(Product product)
        {
            var addedProduct = _productRepository.Add(product);
            return addedProduct;

        }

        public Product UpdateProduct(Product product)
        {
            var updatedProduct = _productRepository.Update(product);
            return updatedProduct;
        }


        public Product GetProductById(int productId)
        {
            var product = _productRepository.GetByKey(productId);
            return product;
        }

        public List<Product> GetAllProducts()
        {
            var products = _productRepository.GetAll()?.ToList();
            return products;
        }

        public bool DeleteProduct(int productId)
        {
            var deletedProduct = _productRepository.Delete(productId);
            return true;
        }

        //public Product GetProductById(int productId)
        //{
        //    var product = _productRepository.GetByKey(productId);
        //    if (product != null)
        //    {
        //        return product;
        //    }
        //    throw new NoProductWithGivenIdException();
        //}

        //public List<Product> GetAllProducts()
        //{
        //    var products = _productRepository.GetAll()?.ToList();
        //    if (products != null)
        //    {
        //        return products;
        //    }
        //    throw new NoProductWithGivenIdException();
        //}

        //public bool DeleteProduct(int productId)
        //{
        //    var deletedProduct = _productRepository.Delete(productId);
        //    if (deletedProduct != null)
        //    {
        //        return true;
        //    }
        //    throw new NoProductWithGivenIdException();
        //}


        //public Product AddProduct(Product product)
        //{
        //    var addedProduct = _productRepository.Add(product);
        //    if (addedProduct != null)
        //    {
        //        return addedProduct;
        //    }
        //    throw new DuplicateProductException();
        //}

        //public Product UpdateProduct(Product product)
        //{
        //    var updatedProduct = _productRepository.Update(product);
        //    if (updatedProduct != null)
        //    {
        //        return updatedProduct;
        //    }
        //    throw new NoProductWithGivenIdException();
        //}
    }
}
