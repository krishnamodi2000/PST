using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommAppBLL.ModelViews;
using EcommAppDAL.Models;

namespace EcommAppBLL.Repository.Carts
{/// <summary>
/// This is ICartRepository that declares all the methods for CART Table Crud operations
/// </summary>
    public interface ICartRepository
    {/// <summary>
    /// ICartRepository Declares method GetCartItemsByUserID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

        public Tuple<List<CartProductView>,float> GetCartItemsyByUserID(int id);
    }
}
