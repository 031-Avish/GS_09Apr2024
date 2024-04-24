using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppTest
{
    public class ProductTest
    {
        IRepository<int,Product> repository;

        [SetUp]
        public void Setup()
        {
            repository = new ProductRepository();
        }

        [Test]
        public void AddProductSuccess()
        {
            // Arrange
            Product product = new Product { Id = 1, Price = 10.0, Name = "Product 1", QuantityInHand = 10 };

            // Act
            var result = repository.Add(product);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(product, result);
        }

        [Test]
        public void DeleteProductSuccess()
        {
            // Arrange
            Product product = new Product { Id = 1, Price = 10.0, Name = "Product 1", QuantityInHand = 10 };
            repository.Add(product);

            // Act
            var result = repository.Delete(product.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(product, result);
            Assert.IsFalse(repository.GetAll().Contains(product));
        }

        [Test]
        public void UpdateProductSuccess()
        {
            // Arrange
            Product product = new Product { Id = 1, Price = 10.0, Name = "Product 1", QuantityInHand = 10 };
            repository.Add(product);

            // Modify the product
            product.Price = 15.0;

            // Act
            var result = repository.Update(product);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(product, result);
            Assert.IsTrue(repository.GetAll().Contains(product));
        }

        [Test]
        public void GetByKeySuccess()
        {
            // Arrange
            Product product = new Product { Id = 1, Price = 10.0, Name = "Product 1", QuantityInHand = 10 };
            repository.Add(product);

            // Act
            var result = repository.GetByKey(product.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(product, result);
        }

        [Test]
        public void GetByKeyException()
        {
            // Arrange & Act & Assert
            Assert.Throws<NoProductWithGivenIdException>(() => repository.GetByKey(999));
        }

        [Test]
        public void UpdateProduct_ProductDoesNotExist_ExceptionThrown()
        {
            // Arrange
            Product product = new Product { Id = 1, Price = 10.0, Name = "Product 1", QuantityInHand = 10 };

            // Act & Assert
            Assert.Throws<NoProductWithGivenIdException>(() => repository.Update(product));
        }

        [Test]
        public void DeleteProductException()
        {
            // Arrange & Act & Assert
            Assert.Throws<NoProductWithGivenIdException>(() => repository.Delete(999));
        }
    }
}
