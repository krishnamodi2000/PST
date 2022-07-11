using EcommAppBLL.ModelViews;
using EcommAppBLL.Utility;
using EcommAppDAL.Context;
using EcommAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommAppBLL.Repository.Products
{/// <summary>
/// This is ProductRepository that defines CRUD operations for Product Table to be implmented in Product Controller.
/// </summary>
    public class ProductRepository : IProductRepository
    {/// <summary>
     /// ProductRepository uses IProductRepository interface.
     /// </summary>
        DatabaseContext db;
        Product prod;
        Categories cat;
        public ProductRepository(DatabaseContext _db)
        {
            db = _db;
            prod = new Product();
            cat = new Categories();
        }
        public IEnumerable<ProductView> AddProducts(IEnumerable<ProductView> products)
        {
            foreach (ProductView p in products)
            {
                PropertyCopy<ProductView, Product>.Copy(p, prod);
            }
            db.Products.AddRange(prod);
            db.SaveChanges();
            return products;
        }

        public void DeleteProductById(int id)
        {
            Product products = db.Products.FirstOrDefault(c => c.ProductId == id); //check the product id in db and delete it if it exists

            if (products != null)
            {

                db.Remove(products);
                db.SaveChanges();
            }

        }
        public void DeleteProductsByName(string name)
        {
            Product products = db.Products.FirstOrDefault(c => c.ProductName == name); //check the product name in db and delete it if it exists
            if (products != null)
            {

                db.Remove(products);
                db.SaveChanges();
            }

        }
        public IEnumerable<ProductView> GetAllProducts()
        {
            return db.Products.Select(products =>

                new ProductView
                {
                    ProductId = products.ProductId,
                    ProductName = products.ProductName,
                    ProductDescription = products.ProductDescription,
                    ProductCount = products.ProductCount,
                    ProductPrice = products.ProductPrice,
                    CategoryId = products.CategoryId
                }
            ).ToList();
        }
        public List<ProductView> GetProductByCategoryName(string categoryname)
        {
            var category = db.Categories.Where(c => c.CategoryName == categoryname).FirstOrDefault();
           // var product = db.Products.Where(p => p.CategoryId == category.CategoryId).ToList();
            return db.Products.Where(p => p.CategoryId == category.CategoryId).Select(product => 
                new ProductView
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductCount = product.ProductCount,
                    ProductPrice = product.ProductPrice,
                    CategoryId = product.CategoryId
                }
            ).ToList();
            
        }
        public ProductView UpdateProductsById(int id, ProductView products)
        {
            var newitem = db.Products.FirstOrDefault(c => c.ProductId == id); //check if id exists and only then update it
            if (newitem != null)
            {
                
                PropertyCopy<ProductView, Product>.Copy(products, prod);
                db.Entry<Product>(newitem).CurrentValues.SetValues(prod);
                //db.Update(newitem);
                db.SaveChanges();
            }
            return products;
           
        }
    }
}
