using EcommAppBLL.ModelViews;
using EcommAppBLL.Repository.Comments;
using EcommAppDAL.Context;
using EcommAppDAL.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommAppBLLTester
{
    public class CommentRepositoryTest
    {
        DatabaseContext db;
        List<Comment> comments;
        List<User> users;
        List<Product> products;
        ICommentRepository icommr;
        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
           .UseInMemoryDatabase(databaseName: "ECommDBAPI")
           .Options;
            db = new DatabaseContext(options);

            products = new List<Product>()
            {
                new Product(){ProductId = 1, ProductName = "PRODUCT 1", ProductDescription = "THIS IS PRODUCT 1", ProductPrice=393 ,ProductCount =8 , CategoryId = 1},
                new Product(){ProductId = 2, ProductName = "PRODUCT 2", ProductDescription = "THIS IS PRODUCT 2", ProductPrice=393 ,ProductCount =8 , CategoryId = 2}

            };
            comments = new List<Comment>()
            {
                new Comment(){CommentId = 1,CommentDate = "", CommentDetails="Comment for prod 1", ProductId=1, UserId=1,ParentCommentId=0 },
                new Comment(){CommentId = 2,CommentDate = "", CommentDetails="Reply Comment for prod 1", ProductId=1, UserId=2,ParentCommentId=1 },
                new Comment(){CommentId = 3,CommentDate = "", CommentDetails="Comment for prod 2", ProductId=2, UserId=1,ParentCommentId=0 },
                new Comment(){CommentId = 4,CommentDate = "", CommentDetails="Comment for prod 1", ProductId=1, UserId=2,ParentCommentId=0 },
                new Comment(){CommentId = 5,CommentDate = "", CommentDetails="Reply Comment of parent 2 for prod 1", ProductId=1, UserId=3,ParentCommentId=2 },
            };
            users = new List<User>()
            {
                new User(){UserId=1,UserFName="Krishna", UserLName="Modi",UserContact="9876543210",UserEmail="krimodi@gmail.com"},
                new User(){UserId=2,UserFName="Rajneesh", UserLName="Yadav",UserContact="7890123456",UserEmail="rajyadav@gmail.com"},
                new User(){UserId=3,UserFName="Ishika", UserLName="Sandhu",UserContact="8976543210",UserEmail="ishsandhu@gmail.com"},
            };
           
            db.Products.AddRange(products);
            db.Users.AddRange(users);
            db.Comments.AddRange(comments);
            db.SaveChanges();

            icommr = new CommentRepository(db);
            
        }
        [OneTimeTearDown]

        public void CleanUp()
        {
            db.Users.RemoveRange(users);
            db.Products.RemoveRange(products);
            db.Comments.RemoveRange(comments);
            db.SaveChanges();
            db.Dispose();
        }
        [Test]
        [Order(1)]
        public void GetCommentsByUserID_Test()
        {
            int id = 2;
            var entity = icommr.GetCommentsByUserId(id);
            Assert.NotNull(entity);
            Assert.AreEqual(2, entity.Count);
        }
        [Test]
        [Order(2)]
        public void GetCommentsByProductID_Test()
        {
            int id = 1;
            var entity = icommr.GetAllCommentsByProductId(id);
            Assert.NotNull(entity);
            Assert.AreEqual(2, entity.Count);
        }
        [Test]
        [Order(3)]
        public void GetCommentsByText_Test()
        {
            string text1="prod 1";
            var entity = icommr.GetCommentsByText(text1);
            Assert.NotNull(entity);
            Assert.AreEqual(4, entity.Count);
        }
        [Test]
        [Order(4)]
        public void AddNewComments_Test()
        {
            CommentView comm = new CommentView() { CommentId = 6, CommentDate = "", CommentDetails = "Comment for prod 2", ProductId = 2, UserId = 3, ParentCommentId = null };
            icommr.AddComments(comm);
            var entity = icommr.GetAllCommentsByProductId(2);
            Assert.NotNull(entity);
            Assert.AreEqual(1, entity.Count);

        }
        [Test]
        [Order(5)]
        public void AddReplyComments_Test()
        {
            CommentView comm = new CommentView() { CommentId = 7, CommentDate = "", CommentDetails = "Reply Comment for prod 2", ProductId = 2, UserId = 1, ParentCommentId =6 };
            icommr.AddComments(comm);
            var entity = icommr.GetCommentsByUserId(1);
            Assert.NotNull(entity);
            Assert.AreEqual(3, entity.Count);

        }
        [Test]
        [Order(8)]
        public void RemoveComments_Test()
        {
            int id = 1;
            
            icommr.RemoveCommentsByCommentId(id);
            var entity = icommr.GetAllCommentsByProductId(1);
            Assert.NotNull(entity);
            Assert.AreEqual(1, entity.Count);
            
        }
        [Test]
        [Order(6)]
        public void UpdateCommentsWithReply_Test()
        {

            CommentView comm = new CommentView() { CommentId = 1, CommentDate = "", CommentDetails = "Comment for prod 1", ProductId = 1, UserId = 1, ParentCommentId = 0 };
            icommr.UpdateComments(comm);
            var entity = icommr.GetAllCommentsByProductId(2);
            Assert.NotNull(entity);
            Assert.AreEqual(1, entity.Count);

        }
        [Test]
        [Order(7)]
        public void UpdateCommentsWithNoReply_Test()
        {
            CommentView comm = new CommentView() { CommentId = 6, CommentDate = "", CommentDetails = "Comment for prod 2 updated", ProductId = 2, UserId = 3, ParentCommentId = null };
            icommr.UpdateComments(comm);
            var entity = icommr.GetAllCommentsByProductId(2);
            Assert.NotNull(entity);
            Assert.AreEqual(1, entity.Count);

        }
    }
}
