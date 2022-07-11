using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommAppBLL.ModelViews
{/// <summary>
/// This is ProductSpecificationView that has all the columns for Products and Specifictions 
/// </summary>
    public class ProductSpecificationView
    {
        public int? ProductId { get; set; }
        public int? SpecificationId { get; set; }
        public string ProductName { get; set; }
        public string SpecificationName { get; set; }
        public string SpecificationDetail { get; set; }
    }
}
