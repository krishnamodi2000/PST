using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommAppBLL.ModelViews
{
    public class OrderView
    {
      //  int? UserId { get; set; }
       // int? CartId { get; set; }
      public int? OrderId { get; set; }
      ///  string UserName { get; set; }
      public DateTime OrderDate { get; set; }
      public string ProductName { get; set; }
      public int ProductCount { get; set; }
     // public float TotalPrice { get; set; }  
        
    }
}
