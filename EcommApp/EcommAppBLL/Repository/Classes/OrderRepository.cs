using EcommAppBLL.ModelViews;
using EcommAppDAL.Context;
using EcommAppDAL.Models;
using EcommAppDAL.Models.Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommAppBLL.Repository.Orders
{
    public class OrderRepository : IOrderRepository
    {
        DatabaseContext db;
        List<OrderView> view;

        public OrderRepository(DatabaseContext _db)
        {
            db = _db;
        }
        public Order AddOrder(int userId, int addressId, string mode)
        {
            Payment payment = new Payment();
            Order order = new Order();

            Cart cart = db.Cart.FirstOrDefault(cp => cp.UserId == userId);
            CartProducts cartProducts = db.CartProducts.FirstOrDefault(cp => cp.CartId == cart.CartId);

            order.OrderDate = DateTime.Now;
            order.CartId = cart.UserId;
            order.UserId = userId;
            order.AddressId = addressId;

            order.OrderPrice = cart.CartPrice;

            //db.Payments.Add(payment);
            db.Order.Add(order);
            db.SaveChanges();
            payment.OrderId = order.OrderId;
            payment.Mode = mode;
            if (mode == "COD")
            {
                payment.Status = "Pending";
                payment.Paid = 0.0;
                payment.Balance = cart.CartPrice;
            }
            else if (mode == "UPI")
            {
                payment.Status = "paid";
                payment.Balance = 0.0;
                payment.Paid = cart.CartPrice;
            }      
            db.Payments.Add(payment);
            db.SaveChanges();
            List<CartProducts> cartProducts1 = db.CartProducts.Where(cp => cp.CartId == cart.CartId).ToList();
            db.CartProducts.RemoveRange(cartProducts1);
            db.SaveChanges();

            cart.CartPrice = 0;
            db.Cart.Update(cart);
            db.SaveChanges();
            return order;
        }

        //public Order DeleteOrderByOrderId(int id)
        //{
        //    CartProducts cart = db.CartProducts.FirstOrDefault(cp => cp.ProductId == id);
        //    Order order = db.Order.FirstOrDefault(o => o.CartId == cart.CartId);
        //    if (order != null)
        //    {
        //        db.Remove(order);
        //        db.SaveChanges();
        //    }
        //    return order;
        //}

        public Order DeleteOrderByOrderId(int id)
        {
            Payment payment = db.Payments.FirstOrDefault(p => p.OrderId == id);
            Order order = db.Order.FirstOrDefault(o => o.OrderId == id);
            if (order != null)
            {
                db.Payments.Remove(payment);
                db.Order.Remove(order);
                db.SaveChanges();
            }
            return order;
        }
        public Payment GetPaymentDetailsByOrderId(int id)
        {
            Payment payment = db.Payments.FirstOrDefault(p => p.OrderId == id);
            return (payment);
        }

        public Tuple<List<OrderView>,float> GetItemsByOrderID(int id)
        {
            var order = db.Order.FirstOrDefault(c => c.OrderId == id);
            var cart = db.Cart.FirstOrDefault(c => c.CartId == order.CartId);
            float Price = cart.CartPrice;
            //var cartproduct = db.CartProducts.FirstOrDefault(cp => cp.CartId == order.CartId);
            // var product = db.Products.FirstOrDefault(p => p.ProductId == cartproduct.ProductId);
            if (order != null)
            {
                view = (from _order in db.Order
                        join _cartproduct in db.CartProducts on _order.CartId equals _cartproduct.CartId //Can remove later
                        join _product in db.Products on _cartproduct.ProductId equals _product.ProductId
                        where _order.OrderId == id
                        select new OrderView
                        {
                            OrderId = _order.OrderId,
                            OrderDate = _order.OrderDate,
                            ProductName = _product.ProductName,
                            ProductCount = _cartproduct.CartCount
                            //TODO:  totalprice=_cart.totalprice 
                        }).ToList();
            }
            return new Tuple<List<OrderView>, float>(view, Price );
        }
    }
}