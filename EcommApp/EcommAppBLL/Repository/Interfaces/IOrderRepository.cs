using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommAppBLL.ModelViews;
using EcommAppDAL.Models;
using EcommAppDAL.Models.Shopping;

namespace EcommAppBLL.Repository.Orders
{
    public interface IOrderRepository
    {
        public Order AddOrder(int userId, int addressId, string mode);
        public Payment GetPaymentDetailsByOrderId(int id);
        public Order DeleteOrderByOrderId(int id);
       // public Order DeleteOrderByProductId(int id);
        public Tuple<List<OrderView>,float> GetItemsByOrderID(int id);
    }
}
