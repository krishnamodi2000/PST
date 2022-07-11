
using EcommAppBLL.Repository.Users;
using EcommAppDAL.Context;
using EcommAppDAL.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
namespace EcommAppBLLTester
{/// <summary>
/// This is UserRepositoryTests for testing UserRepository.
/// </summary>
    public class UserRepositoryTests
    {/// <summary>
     /// UserRepositoryTests uses NUintTesting.
     /// </summary>
        DatabaseContext db;
        List<User> users;
        UserRepository userRepo;
        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
           .UseInMemoryDatabase(databaseName: "ECommDBAPI")
           .Options;
            db = new DatabaseContext(options);
            users = new List<User>()
            {
                new User(){UserId=1,UserFName="Krishna", UserLName="Modi",UserContact="9876543210",UserEmail="krimodi@gmail.com"},
                new User(){UserId=2,UserFName="Rajneesh", UserLName="Yadav",UserContact="7890123456",UserEmail="rajyadav@gmail.com"},
                new User(){UserId=3,UserFName="Ishika", UserLName="Sandhu",UserContact="8976543210",UserEmail="ishsandhu@gmail.com"},

            };
            db.Users.AddRange(users);
            db.SaveChanges();
            userRepo = new UserRepository(db);
        }
        [Test]
        [Order(1)]
        public void GetUserByIDTest()
        {

            int id = 1;
            var entity = userRepo.GetUserByID(id);

            Assert.NotNull(entity);
            Assert.AreEqual(1, entity.UserId);
            Assert.AreEqual("Krishna", entity.UserFName);
            Assert.AreEqual("Modi", entity.UserLName);
            Assert.AreEqual("9876543210",entity.UserContact);
            Assert.AreEqual("krimodi@gmail.com", entity.UserEmail);

        }
        [Test]
        [Order(2)]
        public void GetAllUsersTest()
        {
            var entity = userRepo.GetAllUsers();

            Assert.NotNull(entity);
            Assert.AreEqual(3, entity.Count());

        }
        [Test]
        [Order(3)]
        public void UpdateUserByIDTest()
        {
            int id = 1;
            User user = new User() { UserId = 1, UserFName = "Krishna", UserLName = "Modi", UserContact = "9876543211", UserEmail = "krimodi@gmail.com" };
            var entity = userRepo.UpdateUserById(id, user);
            Assert.NotNull(entity);
            
            Assert.AreEqual("9876543211", entity.UserContact);
            
        }
        [Test]
        [Order(4)]
        public void AddCategoriesTest()
        {
            List<User> users = new List<User>()
            {
                new User(){UserId=4,UserFName="Krishna1", UserLName="Modi1",UserContact="9876543211",UserEmail="krimodi1@gmail.com"},
                new User(){UserId=5,UserFName="Rajneesh1", UserLName="Yadav1",UserContact="7890123451",UserEmail="rajyadav1@gmail.com"},
                new User(){UserId=6,UserFName="Ishika1", UserLName="Sandhu1",UserContact="8976543211",UserEmail="ishsandhu1@gmail.com"},

            };
            var entity =  userRepo.AddUsers(users);
            var entity1 = userRepo.GetAllUsers();
            Assert.NotNull(entity);
            Assert.AreEqual(entity1.Count(), 6);
        }
        [Test]
        [Order(5)]
        public void DeleteCategoryByIDTest()
        {
            int id = 6;
            var entity = userRepo.DeleteUserById(id);
            var entity1 = userRepo.GetAllUsers();
            Assert.AreEqual(5, entity1.Count());
            Assert.AreEqual(6, entity.UserId);
            
        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            db.Dispose();
        }
    }
}