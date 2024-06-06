using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exception;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            Product product = new Product { Id = 1, Price = 10.0, Name = "Product 1",
                QuantityInHand = 10 };

            // Act
            var result = repository.Add(product).Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(product, result);
        }
        [Test]
        public void AddProductDuplicateException()
        {
            // Arrange
            Product product = new Product { Id = 1, Price = 10.0, Name = "Product 1",
                QuantityInHand = 10 };
            // Act
            repository.Add(product);
            // Assert

            Assert.Throws<DuplicateProductException>(()=> repository.Add(product));
        }

        [Test]
        public void GetAllProductSuccess()
        {
            // Arrange
            Product product = new Product { Id = 1, Price = 10.0, Name = "Product 1",
                QuantityInHand = 10 };
            Product product1=new Product { Id = 2, Price =20.0 , Name ="Product 2" ,
               QuantityInHand=12};
            // Act
            repository.Add(product);
            Product result = repository.Add(product1).Result;

            // Assert
            Assert.AreEqual(2, repository.GetAll().Result.Count);
            Assert.AreEqual(product1, repository.GetByKey(2).Result);
        }

        [Test]
        public void GetAllProductFailException()
        {
            //Assert
            Assert.Throws<NoProductWithGivenIdException>(() => repository.GetAll());
        }

        [Test]
        public void GetByKeySuccess()
        {
            // Arrange
            Product product = new Product { Id = 1, Price = 10.0, Name = "Product 1", QuantityInHand = 10 };
            repository.Add(product);

            // Act
            var result = repository.GetByKey(product.Id).Result;

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

        public void GetByKeyExceptionWithEntry()
        {
            // Arrange
            Product product = new Product { Id = 1, Price = 10.0, Name = "Product 1", QuantityInHand = 10 };
            repository.Add(product);

            // Act
            var result = repository.GetByKey(product.Id);

            // Assert
            Assert.Throws<NoProductWithGivenIdException>(() => repository.GetByKey(2));


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
            var result = repository.Update(product).Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(product, result);
            Assert.IsTrue(repository.GetAll().Result.Contains(product));
        }


        
        [Test]
        public void UpdateProductException()
        {
            // Arrange
            Product product = new Product { Id = 1, Price = 10.0, Name = "Product 1", QuantityInHand = 10 };

            // Act & Assert
            Assert.Throws<NoProductWithGivenIdException>(() => repository.Update(product));
        }
        [Test]
        public void UpdateProductExceptionNotFound() {
            // Arrange
            Product product = new Product { Id = 1, Price = 10.0, Name = "Product 1", QuantityInHand = 10 };
            repository.Add(product);

            Product product1=new Product { Id = 2, Price = 12.0, Name = "Product 2", QuantityInHand = 12 };
        // Act & Assert
            Assert.Throws<NoProductWithGivenIdException>(() => repository.Update(product1));
        }

        [Test]
        public void DeleteProductException()
        {
            // Arrange & Act & Assert
            Assert.Throws<NoProductWithGivenIdException>(() => repository.Delete(999));
        }
        [Test]
        public void DeleteProductSuccess()
        {
            // Arrange
            Product product = new Product { Id = 1, Price = 10.0, Name = "Product 1", QuantityInHand = 10 };
            repository.Add(product);

            // Act
            var result = repository.Delete(product.Id).Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(product, result);

        }
    }
}
