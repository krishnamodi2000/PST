using EcommAppBLL.Repository.Specification;
using EcommAppDAL.Context;
using EcommAppDAL.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EcommAppBLLTester
{/// <summary>
///  This is testing class for Specification Repository
/// </summary>
    public class SpecificationRepositoryTest
    {/// <summary>
     /// SpecificationRepositoryTest uses Nunit Testing
     /// </summary>
        DatabaseContext db;
        public List<Specifications> specification;
        SpecificationsRepository specificationrepo;
        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
           .UseInMemoryDatabase(databaseName: "ECommDBAPI")
           .Options;
            db = new DatabaseContext(options);
            specification = new List<Specifications>()
            {
                new Specifications(){SpecificationId=1 , SpecificationName="Game" , SpecificationDetail="GTA"},
                new Specifications(){SpecificationId=2 , SpecificationName="Resolution" , SpecificationDetail="1080px"},
                new Specifications(){SpecificationId=3 , SpecificationName="Resolution" , SpecificationDetail="4k"}
            };
            db.Specifications.AddRange(specification);
            db.SaveChanges();
            specificationrepo = new SpecificationsRepository(db);
        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            db.Dispose();
        }
        [Test]
        [Order(1)]
        public void GetSpecificationsByID_Test()
        {
            int id = 2;
            var entity = specificationrepo.GetSpecificationsByID(id);

            Assert.NotNull(entity);
            Assert.AreEqual(2, entity.SpecificationId);
           
        }
        [Test]
        [Order(2)]
        public void GetAllSpecificationsTest()
        {

            var entity = specificationrepo.GetAllSpecifications();

            Assert.AreEqual(3, entity.Count());
            
        }
        [Test]
        [Order(3)]
        public void GetSpecificationsName()
        {
            string name = "Game";
            var entity = specificationrepo.GetSpecificationsName(name);

            Assert.NotNull(entity);
            Assert.AreEqual("Game", entity.SpecificationName);
            Assert.AreEqual(1, entity.SpecificationId);
            
        }
        [Test]
        [Order(4)]
        public void UpdateSpecificationsbyIDTest()
        {
            int id = 1;
            Specifications specifications= new Specifications() { SpecificationId=1 , SpecificationName="Game4" , SpecificationDetail="GTA" };
            var entity = specificationrepo.UpdateSpecificationsbyID(id, specifications);
            Assert.NotNull(entity);
            Assert.AreEqual(1, entity.SpecificationId);
            
        
        }
        [Test]
        [Order(5)]
        public void UpdateSpecificationsbyName()
        {
            string Specificationname = "Game5";
            Specifications specifications = new Specifications() { SpecificationId = 2, SpecificationName = "Game5", SpecificationDetail = "GTA" };
            var entity = specificationrepo.UpdateSpecificationsbyName(Specificationname, specifications);
            Assert.NotNull(entity);
            Assert.AreEqual(Specificationname, entity.SpecificationName);
        }
        [Test]
        [Order(6)]
        public void AddSpecificationsTest()
        {
            List<Specifications> specifications = new List<Specifications>()
            {
                new Specifications()  {SpecificationId=4 , SpecificationName="Test-4" , SpecificationDetail="GTA"},
                new Specifications()  {SpecificationId=5 , SpecificationName="Test-5" , SpecificationDetail="1080px"},
                new Specifications()  {SpecificationId=6 , SpecificationName="Test-6" , SpecificationDetail="4k"}

            };
            var entity = specificationrepo.AddSpecifications(specifications);
            var entity1 = specificationrepo.GetAllSpecifications();
            Assert.NotNull(entity);
            Assert.AreEqual(entity1.Count(), 6);
        }
        [Test]
        [Order(7)]
        public void DeleteSpecificationsByIDTest()
        {
            int id = 6;
            var entity = specificationrepo.DeleteSpecificationsByID(id);
            var entity1 = specificationrepo.GetAllSpecifications();
            Assert.AreEqual(5, entity1.Count());
            Assert.AreEqual(6, entity.SpecificationId);
            
        }
        [Test]
        [Order(8)]
        public void DeleteSpecificationsByNameTest()
        {
            string name = "Test-5";
            var entity = specificationrepo.DeleteSpecificationsByName(name);
            var entity1 = specificationrepo.GetAllSpecifications();
            Assert.AreEqual(4, entity1.Count());
            Assert.AreEqual(5, entity.SpecificationId);
            Assert.AreEqual("Test-5", entity.SpecificationName);

        }
       
    }
}
