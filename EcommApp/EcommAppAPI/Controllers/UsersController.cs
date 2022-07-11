using Microsoft.AspNetCore.Mvc;
using EcommAppBLL.Repository.Carts;
using EcommAppDAL.Models;
using EcommAppDAL.Context;
using EcommAppBLL.Repository.CartProduct;
using EcommAppBLL.ModelViews;
using EcommAppAPI.Response;
using EcommAppBLL.Repository.Orders;
using EcommAppBLL.Repository.Comments;
using EcommAppBLL.Repository.Products;
using EcommAppBLL.Repository.Category;

namespace EcommAppAPI.Controllers
{
    [Route("api/[Controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        ICartRepository icr;
        ICartProductRepository ipr;
        IOrderRepository ior;
        ICommentRepository icommr;
        IProductRepository ipr1;
        ICategoryRepo icr1;

        private readonly ILogger<UsersController> _logger;
        public UsersController(ICartRepository _icr, ICartProductRepository _ipr, IOrderRepository _ior, ICommentRepository _icommr,IProductRepository _ipr1,ICategoryRepo _icr1, ILogger<UsersController> logger)
        {
            icr = _icr;
            ipr = _ipr;
            icommr = _icommr;
            ior = _ior;
            ipr1 = _ipr1;
            icr1 = _icr1;
            _logger = logger;
        }

        [HttpGet("CartByUserId")]
        public Tuple<List<CartProductView>, float> GetCartItemsyByUserID([FromHeader] int id)

        {
            _logger.LogInformation("CartController Excuting ....");

            return icr.GetCartItemsyByUserID(id);
        }

        [HttpPut("AddToCart")]
        public ResponseMessage AddProductInCart([FromHeader] int userid, [FromHeader] int productid, [FromHeader] int cartcount)
        {
            _logger.LogInformation("CartController Excuting ....");
            try
            {
                ipr.AddProductInCart(userid, productid, cartcount);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Product with product id " + productid + " added Successfully in cart." };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Could not add product to cart." };
            }

        }
        [HttpPut("RemoveFromCart")]
        public ResponseMessage RemoveProductInCart([FromHeader] int userid, [FromHeader] int productid, [FromHeader] int cartcount)
        {
            _logger.LogInformation("CartController Excuting ....");
            try
            {
                ipr.RemoveProductsInCart(userid, productid, cartcount);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Product with product id " + productid + " removed successfully from the cart" };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Could not remove product from to cart." };
            }
        }
        [HttpGet("OrderByOrderId")]
        public Tuple<List<OrderView>, float> GetItemsByOrderID([FromHeader] int id)
        {
            _logger.LogInformation("OrderController Excuting ....");
            return ior.GetItemsByOrderID(id);
        }
        [HttpGet("GePaymentDetailsByOrderId")]
        public Object GetPaymentDetailsByOrderId([FromHeader] int id)
        {
            return ior.GetPaymentDetailsByOrderId(id);
        }
        [HttpPost("AddOrder")]
        public ResponseMessage AddOrder([FromHeader] int userId, [FromHeader] int addressId, [FromHeader] string mode)
        {
            _logger.LogInformation("OrderController Excuting ....");
            try
            {
                ior.AddOrder(userId, addressId, mode);

                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Order placed successfully for user with user ID:" + userId };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Order could not be placed." };
            }

        }
        [HttpDelete("DeleteOrderbyOrderId")]
        public ResponseMessage DeleteOrderByOrderId([FromHeader] int id)
        {
            _logger.LogInformation("OrderController Excuting ....");
            try
            {
                ior.DeleteOrderByOrderId(id);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Order deleted successfully for order ID: " + id };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Order could not be deleted for order ID: " + id };
            }
        }
        [HttpGet("CommentsbyProductId")]
        public List<CommentView1> GetAllCommentsByProductId([FromHeader] int productid)
        {
            _logger.LogInformation("CommentController Excuting ....");
            return icommr.GetAllCommentsByProductId(productid);
        }
        [HttpGet("CommentsbyUserId")]
        public List<CommentView1> GetCommentsByUserId(int userid)
        {
            _logger.LogInformation("CommentController Excuting ....");
            return icommr.GetCommentsByUserId(userid);
        }
        [HttpGet("SearchCommentbyText")]
        public List<CommentView1> GetCommentsByText(string comment)
        {
            _logger.LogInformation("CommentController Excuting ....");
            return icommr.GetCommentsByText(comment);
        }
        [HttpPost("Comments")]
        public ResponseMessage AddComments(CommentView comments)
        {
            _logger.LogInformation("CommentController Excuting ....");
            try
            {
                icommr.AddComments(comments);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Comments Added Successfully." };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Could not add comments" };
            }
        }
        [HttpPut("Comments")]
        public ResponseMessage UpdateComments(CommentView comments)
        {
            _logger.LogInformation("CommentController Excuting ....");
            try
            {
                icommr.UpdateComments(comments);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Comments Updated Successfully." };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Could not update comments" };
            }
        }
        [HttpDelete("Commentsbycommentid")]
        public ResponseMessage RemoveCommentsByCommentId(int commentid)
        {
            _logger.LogInformation("CommentController Excuting ....");
            try
            {
                icommr.RemoveCommentsByCommentId((int)commentid);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Comments deleted Successfully." };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Could not delete comments" };
            }
        }
        [HttpGet("Products")]
        public IEnumerable<ProductView> GetAllProducts()
        {
            _logger.LogInformation("ProductController Excuting ....");
            try
            {
                return ipr1.GetAllProducts();
            }
            catch (Exception)
            {
                return Enumerable.Empty<ProductView>();
            }
        } //get all products
        [HttpGet("ProductsbyCategoryName/{categoryname}")]
        public List<ProductView> GetProductByCategoryName(string categoryname)
        {
            return ipr1.GetProductByCategoryName(categoryname);
        }//get all products by category
        [HttpGet("Category")]
        public IEnumerable<Categories> GetAllCategories()
        {
            _logger.LogInformation("CategoryController Excuting ....");
            return icr1.GetAllCategories();
        } //get all categories
    }
}
