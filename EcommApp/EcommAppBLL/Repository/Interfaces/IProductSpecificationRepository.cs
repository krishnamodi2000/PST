using EcommAppBLL.ModelViews;
using EcommAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommAppBLL.Repository.ProductSpecification
{/// <summary>
/// This is IProductSpecificationRepository interface that declares all the CRUD operations for ProductSpecification Table to be implemented in Product Controller.
/// </summary>
    public interface IProductSpecificationRepository
    {/// <summary>
     ///  IProductSpecificationRepository declares CRUD operations for Product Controller 
     /// </summary>
     /// <returns></returns>
        public IEnumerable<ProductSpecificationView> GetAllProductSpecification();

        public ProductSpecificationView AddSpecificationsInProduct(int specificationId, int ProductId);
        public ProductSpecificationView RemoveSpecificationsFromProduct(int specificationId, int ProductId);

    }
}
