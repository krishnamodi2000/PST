using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommAppBLL.ModelViews
{/// <summary>
/// This is CartProductView that has all the columns for the cart and product view
/// </summary>
    public class CartProductView
    {
       // public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public int CartCount { get; set; }
        public string ProductDescription { get; set; }
        public float ProductPrice { get; set; }
      //  public float CartPrice { get; set; }
       // public int? CartId { get; set; }
    }
}
