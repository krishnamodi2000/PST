using EcommAppBLL.ModelViews;
using EcommAppBLL.Utility;
using EcommAppDAL.Context;
using EcommAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommAppBLL.Repository.ProductSpecification
{/// <summary>
/// This is ProductSpecificationRepository that defines CRUD operations for ProductSpecification Table to be implemented in Product controller.
/// </summary>
    public class ProductSpecificationRepository : IProductSpecificationRepository
    {/// <summary>
    /// ProductSpecificationRepository uses IProductSpecificationRepository to define CRUD operations for ProductSpecifications.
    /// </summary>
        DatabaseContext db;
        ProductSpecifications psdata;
        public ProductSpecificationRepository(DatabaseContext _db)
        {
            db = _db;
            psdata = new ProductSpecifications();
        }
        public IEnumerable<ProductSpecificationView> GetAllProductSpecification()
        {
            
            return db.ProductSpecification.Select(ps =>

               new ProductSpecificationView
               {
                   ProductId= ps.ProductId,
                   SpecificationId = ps.SpecificationId,
                   ProductName=db.Products.FirstOrDefault(p=>p.ProductId==ps.ProductId).ProductName,
                   SpecificationName = db.Specifications.FirstOrDefault(p => p.SpecificationId == ps.SpecificationId).SpecificationName,
                   SpecificationDetail = db.Specifications.FirstOrDefault(p => p.SpecificationId == ps.SpecificationId).SpecificationDetail,
               }
           ).ToList();
        }

        public ProductSpecificationView AddSpecificationsInProduct(int specificationId, int productId)
        {

            ProductSpecifications product = db.ProductSpecification.FirstOrDefault(p => p.ProductId == productId && p.SpecificationId == specificationId);
            ProductSpecificationView ps = new ProductSpecificationView();
            if (product != null)
            {
                    Console.WriteLine("Specification already exists");
                    
            }
            else
            {
                //ProductSpecificationView ps = new ProductSpecificationView();
               
                ps.SpecificationId = specificationId;
                ps.ProductId = productId;
                PropertyCopy<ProductSpecificationView, ProductSpecifications>.Copy(ps, psdata);
                ps.ProductName = db.Products.FirstOrDefault(p => p.ProductId == ps.ProductId).ProductName;
                ps.SpecificationName = db.Specifications.FirstOrDefault(p => p.SpecificationId == ps.SpecificationId).SpecificationName;
                ps.SpecificationDetail = db.Specifications.FirstOrDefault(p => p.SpecificationId == ps.SpecificationId).SpecificationDetail;
                db.ProductSpecification.Add(psdata);
                db.SaveChanges();
               // PropertyCopy<BookView, Book>.Copy(book, bookData);

            }
            return ps;
        }

        public ProductSpecificationView RemoveSpecificationsFromProduct(int specificationId, int productId)
        {
            ProductSpecifications product = db.ProductSpecification.FirstOrDefault(p => p.ProductId == productId && p.SpecificationId == specificationId);
            ProductSpecificationView ps = new ProductSpecificationView();
            if (product != null)
            {
                
                ps.ProductName = db.Products.FirstOrDefault(p => p.ProductId == product.ProductId).ProductName;
                ps.SpecificationName = db.Specifications.FirstOrDefault(p => p.SpecificationId == product.SpecificationId).SpecificationName;
                ps.SpecificationDetail = db.Specifications.FirstOrDefault(p => p.SpecificationId == product.SpecificationId).SpecificationDetail;
                PropertyCopy<ProductSpecificationView, ProductSpecifications>.Copy(ps, product);
                db.ProductSpecification.Remove(product);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Specification does not exist");
            }
            return ps;
           
        }
    }
}
