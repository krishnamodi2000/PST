using EcommAppBLL.Repository.Category;
using EcommAppDAL.Context;
using EcommAppDAL.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EcommAppBLLTester
{/// <summary>
/// This is CategoryRepositoryTest for testing CategoryRepository
/// </summary>
    public class CategoryRepositoryTests
    {/// <summary>
    /// CategoryRepositoryTests uses NUintTesting.
    /// </summary>
        
        DatabaseContext db;
        List<Categories> categories;
        CategoryRepo categoryRepo;
        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
           .UseInMemoryDatabase(databaseName: "ECommDBAPI")
           .Options;
            db = new DatabaseContext(options);
            categories = new List<Categories>()
            {
                new Categories() { CategoryId = 1, CategoryName = "TEST NAME1", CategoryDate = "2022-03-03T08:17:37.554Z" },
                new Categories() { CategoryId = 2, CategoryName = "TEST NAME2", CategoryDate = "2022-03-04T08:17:37.554Z" },
                new Categories() { CategoryId = 3, CategoryName = "TEST NAME3", CategoryDate = "2022-03-05T08:17:37.554Z" }

            };
            db.Categories.AddRange(categories);
            db.SaveChanges();
            categoryRepo = new CategoryRepo(db);
        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            db.Dispose();
        }

        [Test]
        [Order(1)]
        public void GetCategoryByIDTest()
        {
            
            int id = 1;
            var entity = categoryRepo.GetCategoryByID(id);

            Assert.NotNull(entity);
            Assert.AreEqual(1, entity.CategoryId);
            Assert.AreEqual("TEST NAME1", entity.CategoryName);
            Assert.AreEqual("2022-03-03T08:17:37.554Z", entity.CategoryDate);
        }
        [Test]
        [Order(2)]
        public void GetAllCategoryTest()
        {
           
            var entity = categoryRepo.GetAllCategories();
            Assert.AreEqual(3,entity.Count());
        }
        [Test]
        [Order(3)]
        public void GetCategoryByNameTest()
        {
            string name = "TEST NAME1";
            var entity = categoryRepo.GetCategoryName(name);

            Assert.NotNull(entity);
            Assert.AreEqual("TEST NAME1", entity.CategoryName);
            Assert.AreEqual(1, entity.CategoryId);
            Assert.AreEqual("2022-03-03T08:17:37.554Z", entity.CategoryDate);
        }
        [Test]
        [Order(4)]
        public void UpdateCategoryByIDTest()
        {
            int id = 1;
            Categories category = new Categories() { CategoryId = 1, CategoryName = "TEST NAME11", CategoryDate = "2022-03-03T08:17:37.554Z" };
            var entity = categoryRepo.UpdateCategoriesbyID(id,category);
            Assert.NotNull(entity);
            Assert.AreEqual(1, entity.CategoryId);
            Assert.AreEqual("TEST NAME11", entity.CategoryName);
            Assert.AreEqual("2022-03-03T08:17:37.554Z", entity.CategoryDate);
        }
        [Test]
        [Order(5)]
        public void UpdateCategoryByNameTest()
        {
            string categoryName = "TEST NAME11";
            Categories category = new Categories() { CategoryId = 1, CategoryName = "TEST NAME1", CategoryDate = "2022-03-03T08:17:37.554Z" };
            var entity = categoryRepo.UpdateCategoriesbyName(categoryName, category);
            Assert.NotNull(entity);
            Assert.AreEqual(1, entity.CategoryId);
            Assert.AreEqual("TEST NAME1", entity.CategoryName);
            Assert.AreEqual("2022-03-03T08:17:37.554Z", entity.CategoryDate);
        }
        [Test]
        [Order(6)]
        public void AddCategoriesTest()
        {
            List<Categories> category = new List<Categories>()
            {
                new Categories() { CategoryId = 4, CategoryName = "TEST NAMEADD1", CategoryDate = "2022-03-03T08:17:37.554Z" },
                new Categories() { CategoryId = 5, CategoryName = "TEST NAMEADD2", CategoryDate = "2022-03-04T08:17:37.554Z" },
                new Categories() { CategoryId = 6, CategoryName = "TEST NAMEADD3", CategoryDate = "2022-03-05T08:17:37.554Z" }

            };
            var entity = categoryRepo.AddCategories(category);
            var entity1 = categoryRepo.GetAllCategories();
            Assert.NotNull(entity);
            Assert.AreEqual(entity1.Count(),6);
        }
        [Test]
        [Order(7)]
        public void DeleteCategoryByIDTest()
        {
            int id = 6;
            var entity = categoryRepo.DeleteCategoryByID(id);
            var entity1 = categoryRepo.GetAllCategories();
            Assert. AreEqual(5, entity1.Count());
            Assert.AreEqual(6, entity.CategoryId);
            Assert.AreEqual("TEST NAMEADD3", entity.CategoryName);
        }
        [Test]
        [Order(8)]
        public void DeleteCategoryByNameTest()
        {
            string name="TEST NAMEADD2";
            var entity = categoryRepo.DeleteCategoryByName(name);
            var entity1 = categoryRepo.GetAllCategories();
            Assert.AreEqual(4, entity1.Count());
            Assert.AreEqual(5, entity.CategoryId);
            Assert.AreEqual("TEST NAMEADD2", entity.CategoryName);            
        }
    }
}