using EcommAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommAppBLL.Repository.Users
{/// <summary>
/// This is IUserRepository interface that declares all the CRUD operations for User Table.
/// </summary>
    public interface IUserRepository
    {/// <summary>
    /// IUserRepository declares all CRUD operations for User Controller.
    /// </summary>
    /// <returns></returns>
        public IEnumerable<User> GetAllUsers(); //get all User
        public User GetUserByID(int id); //get User by its id
        public IEnumerable<User> AddUsers(IEnumerable<User> users); //add new User ..can add multiple in a go
        public User DeleteUserById(int id);//delete a User by id
        public User UpdateUserById(int id, User users); //update User details
    }
}
