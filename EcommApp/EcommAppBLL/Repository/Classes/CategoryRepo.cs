using EcommAppDAL.Context;
using EcommAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommAppBLL.Repository.Category
{/// <summary>
/// This is CategoryRepo that Defines all the CRUD operations for Category Controller.
/// </summary>
    public class CategoryRepo :  ICategoryRepo
    {/// <summary>
    /// CatergoryRepo Uses ICategoryRepo Interface.
    /// </summary>
        DatabaseContext db;
        public CategoryRepo(DatabaseContext _db)
        {
            db = _db;

        }

        public IEnumerable<Categories> AddCategories(IEnumerable<Categories> categories)
        {
            db.Categories.AddRange(categories);
            db.SaveChanges();
           return categories;
        }

        public Categories DeleteCategoryByID(int id)
        {
            Categories categories = db.Categories.FirstOrDefault(c => c.CategoryId == id); //check the category id in db and delete it if it exists
            if (categories != null)
            {
                db.Remove(categories);
                db.SaveChanges();
            }
            return categories;
        }

        public Categories DeleteCategoryByName(string name)
        {
            Categories categories = db.Categories.FirstOrDefault(c => c.CategoryName == name); //check the product name in db and delete it if it exists
            if (categories != null)
            {
                db.Remove(categories);
                db.SaveChanges();
            }
            return categories;

        }

        public IEnumerable<Categories> GetAllCategories()
        {
            return db.Categories.Select(x => x).ToList();
        }

        public Categories GetCategoryByID(int id)
        {
            return (db.Categories.Find(id));
        }

        public Categories GetCategoryName(string name)
        {
            Categories categories = db.Categories.FirstOrDefault(c => c.CategoryName == name);
            return (categories);
        }

        public Categories UpdateCategoriesbyID(int id, Categories categories)
        {
            var cat = db.Categories.FirstOrDefault(c => c.CategoryId == id); //check if id exists and only then update it
            if (cat != null)
            {
                db.Entry<Categories>(cat).CurrentValues.SetValues(categories);
                db.SaveChanges();
            }
            return categories;
        }

        public Categories UpdateCategoriesbyName(string name, Categories categories)
        {
            var cat = db.Categories.FirstOrDefault(c => c.CategoryName == name); //check if name exists and only then update it
            if (cat != null)
            {
                db.Entry<Categories>(cat).CurrentValues.SetValues(categories);
                db.SaveChanges();
            }
            return categories;
        }
    }
}
