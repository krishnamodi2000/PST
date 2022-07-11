using EcommAppDAL.Context;
using EcommAppDAL.Models;
using EcommAppBLL.Repository.ProductSpecification;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommAppBLLTester
{/// <summary>
/// This is ProductSpecificationRepositoryTest for testing ProductSpecificationRepository.
/// </summary>
    public class ProductSpecificationRepositoryTest
    {/// <summary>
     /// ProductSpecificationRepositoryTest uses NUintTesting.
     /// </summary>
        DatabaseContext db;
        List<Specifications> specifications;
        ProductSpecificationRepository productSpecificationRepository;
        List<Product> products;
        List<ProductSpecifications> productSpecifications;
        
        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
           .UseInMemoryDatabase(databaseName: "ECommDBAPI")
           .Options;
            db = new DatabaseContext(options);
            specifications = new List<Specifications>()
            {
                new Specifications(){SpecificationId=1 , SpecificationName="SPECIFICATION 1" , SpecificationDetail="SPECIFICATION DETAIL 1"},
                new Specifications(){SpecificationId=2 , SpecificationName="SPECIFICATION 2" , SpecificationDetail="SPECIFICATION DETAIL 2"},
                new Specifications(){SpecificationId=3 , SpecificationName="SPECIFICATION 3" , SpecificationDetail="SPECIFICATION DETAIL 3"}
            };
            products = new List<Product>()
            {
                new Product() { ProductId = 1, ProductName = "TEST PRODUCT 1", ProductDescription = "THIS IS TEST PRODUCT 1", ProductPrice = 100, ProductCount= 2, CategoryId = 1 },
                new Product() { ProductId = 2, ProductName = "TEST PRODUCT 2", ProductDescription = "THIS IS TEST PRODUCT 2", ProductPrice = 200, ProductCount= 4, CategoryId = 2 },
                new Product() { ProductId = 3, ProductName = "TEST PRODUCT 3", ProductDescription = "THIS IS TEST PRODUCT 3", ProductPrice = 300, ProductCount= 8, CategoryId = 3 }

            };
            productSpecifications = new List<ProductSpecifications>()
            {
                new ProductSpecifications(){ProductSpecificationId=1, ProductId=1, SpecificationId=1},
                new ProductSpecifications(){ProductSpecificationId=2, ProductId=1, SpecificationId=2},
                new ProductSpecifications(){ProductSpecificationId=3, ProductId=2, SpecificationId=3},
                new ProductSpecifications(){ProductSpecificationId=4, ProductId=3, SpecificationId=1}

            };
            db.ProductSpecification.AddRange(productSpecifications);
            db.Specifications.AddRange(specifications);
            db.Products.AddRange(products);
            db.SaveChanges();
            productSpecificationRepository = new ProductSpecificationRepository(db);
        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            db.ProductSpecification.RemoveRange(productSpecifications);
            db.Specifications.RemoveRange(specifications);
            db.Products.RemoveRange(products);
            db.SaveChanges();
            db.Dispose();
        }
        [Test]
        [Order(1)]
        public void GetAllProductSpecificationsTest()
        {
            var entity = productSpecificationRepository.GetAllProductSpecification();
            Assert.AreEqual(4, entity.Count());
        }
        [Test]
        [Order(2)]
        public void AddProductSpecificationsTest()
        {
            var entity = productSpecificationRepository.AddSpecificationsInProduct(2,2);
            var entity1= productSpecificationRepository.GetAllProductSpecification();
            Assert.AreEqual(5, entity1.Count());
        }
        [Test]
        [Order(3)]
        public void RemoveProductSpecificationsTest()
        {
            var entity = productSpecificationRepository.RemoveSpecificationsFromProduct(2, 2);
            var entity1 = productSpecificationRepository.GetAllProductSpecification();
            Assert.AreEqual(4, entity1.Count());
        }
        
    }
}
