using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommAppBLL.ModelViews;
using EcommAppDAL.Models;

namespace EcommAppBLL.Repository.Products
{/// <summary>
/// This is IProductRepository Interface that declares all the CRUD operations for Product Table.
/// </summary>
    public interface IProductRepository
    {/// <summary>
    /// IProductRepository declares methods for Product Controller.
    /// </summary>
    /// <returns></returns>
        public IEnumerable<ProductView> GetAllProducts(); //get all items
        public List<ProductView> GetProductByCategoryName(string categoryname); //get items by category name
       
        IEnumerable<ProductView> AddProducts(IEnumerable<ProductView> products); //add new items ..can add multiple in a go
        void DeleteProductsByName(string name); //delete a product by name
        void DeleteProductById(int id);//delete a product by id
        ProductView UpdateProductsById(int id, ProductView products); //update item details
    }
}
