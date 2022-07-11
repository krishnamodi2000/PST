using EcommAppDAL.Context;
using EcommAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommAppBLL.Repository.Users
{/// <summary>
/// This is UserRepository that defines all crud operations to be implemented in User Controller.
/// </summary>
    public class UserRepository : IUserRepository
    {/// <summary>
    /// UserRepository uses IUserRepository interface and defines the Crud Operations
    /// </summary>
        DatabaseContext db;
        public UserRepository(DatabaseContext _db)
        {
            db = _db;
        }
        public IEnumerable<User> AddUsers(IEnumerable<User> users)
        {
            db.Users.AddRange(users);
            db.SaveChanges();
            return users;
        }

        public User DeleteUserById(int id)
        {
            User user = db.Users.FirstOrDefault(c => c.UserId == id);
            if(user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
            return user;
            
        }

        public IEnumerable<User> GetAllUsers()
        {
            return db.Users.Select(x => x).ToList();
        }

        public User GetUserByID(int id)
        {
            return (db.Users.Find(id));
        }

        public User UpdateUserById(int id, User users)
        {
            var user = db.Users.FirstOrDefault(c => c.UserId == id); //check if id exists and only then update it
            if (user != null)
            {
                db.Entry<User>(user).CurrentValues.SetValues(users);
                db.SaveChanges();
            }
            return user;
        }
    }
}
