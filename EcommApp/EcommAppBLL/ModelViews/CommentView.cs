using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommAppBLL.ModelViews
{
    public class CommentView
    {
       
        public int CommentId { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public string CommentDetails { get; set; }
        public string? CommentDate { get; set; }
        public int? ParentCommentId { get; set; }
    }
}
