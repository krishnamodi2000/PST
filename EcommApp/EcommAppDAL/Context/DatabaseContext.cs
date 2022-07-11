using EcommAppDAL.Models;
using EcommAppDAL.Models.Shopping;
using log4net;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommAppDAL.Context
{/// <summary>
/// This is DataBaseContext that uses DbContext and has all the DbSets for EcommAppDAL
/// </summary>
    public class DatabaseContext: DbContext
    {
        // private readonly string _connectionString;

        // private static readonly ILog Log = LogManager.GetLogger(typeof(DatabaseContext));
        //public DatabaseContext()
        //{

        //}
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
       public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Specifications> Specifications { get; set; }
        public DbSet<ProductSpecifications> ProductSpecification { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CartProducts> CartProducts { get; set; }

    }
}
