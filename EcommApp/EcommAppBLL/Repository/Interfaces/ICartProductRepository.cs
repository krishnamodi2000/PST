using EcommAppBLL.ModelViews;
using EcommAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommAppBLL.Repository.CartProduct
{/// <summary>
/// This is ICartRepoditory interface that declares all the CRUD operations for CART PRODUCT table
/// </summary>
    public interface ICartProductRepository

    {
        /// <summary>
        /// ICartRepository Declares all the CRUD operations.
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="productid"></param>
        /// <param name="cartcount"></param>
        /// <returns></returns>
       // public IEnumerable<CartProductView> GetAllCartProducts();
    
        public Tuple<List<CartProductView>,float> AddProductInCart(int userid, int productid, int cartcount);//from user id we will get to know the cart id
        //once the cart id is known add products in that particular cart
        //don't allow user to make changes in the cart id..should be supplied by us by backend mapping
        //adding and mapping accordingly
        public Tuple<List<CartProductView>, float> RemoveProductsInCart(int userid,int productid, int cartcount);//from user id we will get to know the cart id
        //once the cart id is known remove products in that particular cart//compare the count in the logic and check,
        //If the original and input count are same removethe whole row, or reduce the count by subtracting 
        //public void UpdateProductsInCart(int userid, int productid, int cartcount);////from user id we will get to know the cart id
        //once the cart id is known update products in that particular cart
        //only the count can be changed
        //don't allow user make changes in prouduct id and cart id
        //adding and mapping accordingly
    }
}
