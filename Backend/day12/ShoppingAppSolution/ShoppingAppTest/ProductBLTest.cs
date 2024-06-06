using ShoppingDALLibrary;
using ShoppingModelLibrary.Exception;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingBLLibrary;

namespace ShoppingAppTest
{
    public class ProductBLTest
    {
        private ProductBL _productBL;
        private IRepository<int, Product> _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new ProductRepository();
            _productBL = new ProductBL(_repository);
        }

        [Test]
        public void AddProductSuccess()
        {
            // Arrange
            Product product = new Product { Id = 1, Price = 10.0, Name = "Product 1",
                QuantityInHand = 10 };

            // Act
            var result = _productBL.AddProduct(product);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(product, result);
        }
        [Test]
        public void GetAllProductSuccess() {
            Product product = new Product { Id = 1, Price = 10.0, Name = "Product 1",
                QuantityInHand = 10 };
            Product product2 = new Product { Id = 2, Price = 11.0, Name = "Product 1",
                QuantityInHand=11};
            // Act
            _productBL.AddProduct(product);
            var result = _productBL.AddProduct(product2);

            // Assert
            
            Assert.AreEqual(2,_productBL.GetAllProducts().Count );
        }

        [Test]
        public void DeleteProductSuccess()
        {
            // Arrange
            Product product = new Product { Id = 1, Price = 10.0,
                Name = "Product 1", QuantityInHand = 10 };
            _productBL.AddProduct(product);

            // Act
            var result = _productBL.DeleteProduct(product.Id);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void UpdateProductSuccess()
        {
            // Arrange
            Product product = new Product { Id = 1, Price = 10.0, Name = "Product 1",
                QuantityInHand = 10 };
            _productBL.AddProduct(product);

            // Modify the product
            product.Price = 15.0;

            // Act
            var result = _productBL.UpdateProduct(product);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(product, result);
        }

        [Test]
        public void GetProductByIdSuccess()
        {
            // Arrange
            Product product = new Product { Id = 1, Price = 10.0, Name = "Product 1", 
                QuantityInHand = 10 };
            _productBL.AddProduct(product);

            // Act
            var result = _productBL.GetProductById(product.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(product, result);
        }

        [Test]
        public void GetProductByIdException()
        {
            // Arrange & Act & Assert
            Assert.Throws<NoProductWithGivenIdException>(() => _productBL.GetProductById(999));
        }
        [Test]
        public void GetAllProductException()
        {
            // Arrange & Act & Assert
            Assert.Throws<NoProductWithGivenIdException>(() => _productBL.GetAllProducts());
        }


        [Test]
        public void UpdateProductException()
        {
            // Arrange
            Product product = new Product { Id = 1, Price = 10.0, Name = "Product 1",
                QuantityInHand = 10 };

            // Act & Assert
            Assert.Throws<NoProductWithGivenIdException>(() => _productBL.UpdateProduct(product));
        }

        [Test]
        public void DeleteProductException()
        {
            // Arrange & Act & Assert
            Assert.Throws<NoProductWithGivenIdException>(() => _productBL.DeleteProduct(999));
        }
    }
}
