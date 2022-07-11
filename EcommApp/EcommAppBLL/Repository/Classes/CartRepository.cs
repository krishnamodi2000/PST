using EcommAppDAL.Context;
using EcommAppDAL.Models;
using EcommAppBLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommAppBLL.ModelViews;

namespace EcommAppBLL.Repository.Carts
{/// <summary>
/// This is CartRepository that defines all the CRUD operations user for Cart Table
/// </summary>
    public class CartRepository : ICartRepository
    {/// <summary>
    /// CartRepository implements ICartRepository interface
    /// </summary>
        DatabaseContext db;
        List<CartProductView> view;
        public CartRepository(DatabaseContext _db)
        {
            db = _db;
           // view = new CartProductView();
        }
        public Tuple<List<CartProductView>,float> GetCartItemsyByUserID(int id)
        {
            var user = db.Cart.FirstOrDefault(c => c.UserId == id);
            
            
            if (user != null)
            {
                view =(from _cart in db.Cart
                                         join _cartproduct in db.CartProducts on _cart.CartId equals _cartproduct.CartId
                                         join _product in db.Products on _cartproduct.ProductId equals _product.ProductId
                                         where _cart.UserId == id
                                         select new CartProductView
                                         {
                                            
                                             ProductId = _cartproduct.ProductId,
                                             CartCount = _cartproduct.CartCount,
                                             //CartPrice= _cart.CartPrice,
                                             ProductName = _product.ProductName,
                                             ProductDescription = _product.ProductDescription,
                                             ProductPrice = _product.ProductPrice * _cartproduct.CartCount
                                         }).ToList();
                
                //return query;
               // return (result);
                
            }
            return new Tuple<List<CartProductView>, float>(view,user.CartPrice);
        }


    }
}
