using EcommAppBLL.ModelViews;
using EcommAppBLL.Repository.Products;
using EcommAppDAL.Context;
using EcommAppDAL.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EcommAppBLLTester
{/// <summary>
///This is ProductRepositoryTests for testing ProductRepository.
/// </summary>
    public class ProductRepositoryTests
    {/// <summary>
     /// ProductRepositoryTests uses NuintTesting.
     /// </summary>

        DatabaseContext db;
        List<Product> products;
        ProductRepository productRepository;
        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
           .UseInMemoryDatabase(databaseName: "ECommDBAPI")
           .Options;
            db = new DatabaseContext(options);
            products = new List<Product>()
            {
                new Product() { ProductId = 1, ProductName = "TEST PRODUCT 1", ProductDescription = "THIS IS TEST PRODUCT 1", ProductPrice = 100, ProductCount= 2, CategoryId = 1 },
                new Product() { ProductId = 2, ProductName = "TEST PRODUCT 2", ProductDescription = "THIS IS TEST PRODUCT 2", ProductPrice = 200, ProductCount= 4, CategoryId = 2 },
                new Product() { ProductId = 3, ProductName = "TEST PRODUCT 3", ProductDescription = "THIS IS TEST PRODUCT 3", ProductPrice = 300, ProductCount= 8, CategoryId = 3 }
                //new Product() { ProductId = 4, ProductName = "TEST PRODUCT 4", ProductDescription = "THIS IS TEST PRODUCT 4", ProductPrice = 400, ProductCount= 16,CategoryId = 4 },
                //new Product() { ProductId = 5, ProductName = "TEST PRODUCT 5", ProductDescription = "THIS IS TEST PRODUCT 5", ProductPrice = 500, ProductCount= 32,CategoryId = 5 }

            };
            db.Products.AddRange(products);
            db.SaveChanges();
            productRepository = new ProductRepository(db);
        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            db.Products.RemoveRange(products);
            db.SaveChanges();
            db.Dispose();
        }
        [Test]
        [Order(1)]
        public void GetAllProductsTest()
        {
            var entity = productRepository.GetAllProducts();
            Assert.AreEqual(3, entity.Count());
        }

        [Test]
        [Order(2)]
        public void AddProductsTest()
        {
            List<ProductView> products = new List<ProductView>()
            {
                new ProductView() { ProductId = 4, ProductName = "TEST PRODUCT 4", ProductDescription = "THIS IS TEST PRODUCT 4", ProductPrice = 400, ProductCount= 16, CategoryId = 4 }

            };
            var entity = productRepository.AddProducts(products);
            var entity1 = productRepository.GetAllProducts();
            Assert.NotNull(entity);
            Assert.AreEqual(entity1.Count(), 4);
        }
        [Test]
        [Order(3)]
        public void DeleteProductsByIdTest()
        {
            int id = 4;
            productRepository.DeleteProductById(id);
            var entity1 = productRepository.GetAllProducts();
            Assert.AreEqual(3, entity1.Count());
            
        }
        [Test]
        [Order(4)]
        public void DeleteProductsByNameTest()
        {
            string name = "TEST PRODUCT 3";
            productRepository.DeleteProductsByName(name);
            var entity1 = productRepository.GetAllProducts();
            Assert.AreEqual(2, entity1.Count());
            

        }
        [Test]
        [Order(5)]
        public void UpdateProductByIdTest()
        {
            int id = 1;
            ProductView products = new ProductView() { ProductId = 1, ProductName = "TEST PRODUCT 1_1", ProductDescription = "THIS IS TEST PRODUCT 1", ProductPrice = 100, ProductCount = 2, CategoryId = 1 };
            var entity=productRepository.UpdateProductsById(id, products);
            db.SaveChanges();
           // var entity = productRepository.GetAllProducts();
            Assert.NotNull(entity);
            Assert.AreEqual(1, entity.ProductId);
            Assert.AreEqual("TEST PRODUCT 1_1", entity.ProductName);
            Assert.AreEqual("THIS IS TEST PRODUCT 1", entity.ProductDescription);
            Assert.AreEqual(100, entity.ProductPrice);
            Assert.AreEqual(2, entity.ProductCount);
            Assert.AreEqual(1, entity.CategoryId);
        }
        
    }
}