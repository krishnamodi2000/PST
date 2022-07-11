using EcommAppBLL.ModelViews;
using EcommAppBLL.Repository.Carts;
using EcommAppDAL.Context;
using EcommAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommAppBLL.Repository.CartProduct
{/// <summary>
/// This is Cart Product Repository that uses ICartProduct interface 
/// </summary>
    public class CartProductRepository : ICartProductRepository
    {/// <summary>
    /// CartProductRepository has definitions for all the CRUD operations.
    /// </summary>
        DatabaseContext db;
        ICartRepository icr;
        public CartProductRepository(DatabaseContext _db, ICartRepository _icr)
        {
            db = _db;
            icr = _icr;

        }
        public Tuple<List<CartProductView>,float> AddProductInCart(int userid, int productid, int cartcount)
        {
            Cart cart = db.Cart.FirstOrDefault(c => c.UserId == userid);
            Product product = db.Products.FirstOrDefault(p => p.ProductId == productid);
            if (cart != null && product.ProductCount >= cartcount)
            {
                CartProducts prod = db.CartProducts.FirstOrDefault(cp => cp.ProductId == productid && cp.CartId == cart.CartId);
                if (prod != null)
                {

                    prod.CartCount = prod.CartCount + cartcount;
                    product.ProductCount = product.ProductCount - cartcount;
                    cart.CartPrice += cartcount * product.ProductPrice;
                    prod.CartId = prod.CartId;
                    prod.ProductId = productid;
                    db.Update(prod);
                    db.Update(product);
                    db.Update(cart);
                   
                    db.SaveChanges();

                }
                else if (prod == null)
                {
                    CartProducts prod1 = new CartProducts();
                    prod1.CartCount = cartcount;
                    product.ProductCount = product.ProductCount - cartcount;
                    cart.CartPrice += cartcount * product.ProductPrice;
                    prod1.CartId = cart.CartId;
                    prod1.ProductId = productid;
                    db.Add(prod1);
                    db.Update(product);
                    db.Update(cart);
                    db.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("Only " + product.ProductCount + "items in inventory");
            }
            return icr.GetCartItemsyByUserID(userid);

        }

        public Tuple<List<CartProductView>,float> RemoveProductsInCart(int userid, int productid, int cartcount)
        {
            Cart cart = db.Cart.FirstOrDefault(c => c.UserId == userid);
            Product product = db.Products.FirstOrDefault(p => p.ProductId == productid);
            if (cart != null)
            {
                CartProducts prod = db.CartProducts.FirstOrDefault(cp => cp.ProductId == productid && cp.CartId == cart.CartId);
                if (prod != null && prod.CartCount >= cartcount)
                {
                    prod.CartCount = prod.CartCount - cartcount;
                    cart.CartPrice -= cartcount * product.ProductPrice;
                    product.ProductCount = product.ProductCount + cartcount;
                    if (prod.CartCount >= 1)
                    {
                        //prod.CartPrice = prod.CartCount * product.ProductPrice;
                        prod.CartId = prod.CartId;
                        prod.ProductId = productid;
                      //  cart.CartPrice -= prod.CartCount * product.ProductPrice;
                        db.Update(prod);
                        db.Update(product);
                        db.Update(cart);
                        db.SaveChanges();
                    }
                    else if (prod.CartCount == cartcount || prod.CartCount == null)
                    {
                        db.Update(cart);
                        db.Update(product);
                        db.Remove(prod);
                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Only " + prod.CartCount + "items in CART");
                    }
                }

                    
                }
            return icr.GetCartItemsyByUserID(userid);
        }
    }
}
   