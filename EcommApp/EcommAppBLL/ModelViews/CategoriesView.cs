using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommAppBLL.ModelViews
{/// <summary>
/// This CategoriesView that has all the columns to be viewed in Categories
/// </summary>
    public class CategoriesView
    { 
        public int CategoryId { get; set; } 
        public string CategoryName { get; set; }
        public string? CategoryDate { get; set; }
    }
}
