using EcommAppAPI.Response;
using EcommAppBLL.ModelViews;
using EcommAppBLL.Repository.Products;
using EcommAppBLL.Repository.ProductSpecification;
using EcommAppBLL.Repository.Users;
using EcommAppDAL.Models;
using EcommAppBLL.Repository.Specification;
using EcommAppBLL.Repository.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommAppAPI.Controllers
{
    [Route("api/[Controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IUserRepository iur;
        IProductRepository ipr;
        IProductSpecificationRepository ipsr;
        ISpecificationRepository isr;
        ICategoryRepo icr;

        private readonly ILogger<AdminController> _logger;
        public AdminController(IUserRepository _iur, IProductRepository _ipr, IProductSpecificationRepository _ipsr, ISpecificationRepository _isr, ICategoryRepo _icr, ILogger<AdminController> logger)
        {
            iur = _iur;
            ipr = _ipr;
            ipsr = _ipsr;
            isr = _isr;
            icr = _icr;
            _logger = logger;
        }
        [HttpGet("Users")]
        public IEnumerable<User> GetAllUsers()
        {
            _logger.LogInformation("UserController Excuting ....");
            try
            {
                return iur.GetAllUsers();
            }
            catch (Exception)
            {
                return Enumerable.Empty<User>();
            }

        } //get all User
        [HttpGet("UserbyUserID")]
        public User GetUserByID([FromHeader] int id)
        {
            _logger.LogInformation("UserController Excuting ....");
            try
            {
                return iur.GetUserByID(id);
            }
            catch (Exception)
            {
                return null;
            }

        } //get User by its id
        [HttpPost("User")]
        public ResponseMessage AddUsers(IEnumerable<User> users)
        {
            _logger.LogInformation("UserController Excuting ....");
            try
            {
                iur.AddUsers(users);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "User Added Successfully." };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "User could not be added." };
            }

        } //add new User ..can add multiple in a go
        [HttpDelete("UserbyUserID")]
        public ResponseMessage DeleteUserById([FromHeader] int id)
        {
            _logger.LogInformation("UserController Excuting ....");
            try
            {
                iur.DeleteUserById(id);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "user details of user id " + id + " deleted successfully." };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "user could not be deleted." };
            }


        }//delete a User by id
        [HttpPut("UserDetailsbyID")]
        public ResponseMessage UpdateUserById([FromHeader] int id, User users)
        {
            _logger.LogInformation("UserController Excuting ....");
            try
            {
                iur.UpdateUserById(id, users);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Details of user id " + id + " updated Successfully." };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "user could not be updated." };
            }
        } //update User details
        [HttpGet("ProductSpecification")]
        public IEnumerable<ProductSpecificationView> GetAll()
        {
            _logger.LogInformation("ProductController Excuting ....");
            try
            {
                return ipsr.GetAllProductSpecification();
            }
            catch (Exception)
            {
                return Enumerable.Empty<ProductSpecificationView>();
            }
        }

        [HttpGet("Products")]
        public IEnumerable<ProductView> GetAllProducts()
        {
            _logger.LogInformation("ProductController Excuting ....");
            // return ipr.GetAllProducts();
            try
            {
                return ipr.GetAllProducts();
            }
            catch (Exception)
            {
                return Enumerable.Empty<ProductView>();
            }
        } //get all products
        [HttpGet("ProductsbyCategoryName/{categoryname}")]
        public List<ProductView> GetProductByCategoryName(string categoryname)
        {
            return ipr.GetProductByCategoryName(categoryname);
        }

        [HttpPost("Product")]
        public ResponseMessage AddProducts(IEnumerable<ProductView> products)
        {

            _logger.LogInformation("ProductController Excuting ....");
            try
            {
                ipr.AddProducts(products);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Products Added Successfully." };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Products could not be Added" };
            }

        } //add new products ..can add multiple in a go


        [HttpDelete("ProductbyName/{name}")]

        public ResponseMessage DeleteProductsByName(string name)
        {
            _logger.LogInformation("ProductController Excuting ....");
            try
            {
                ipr.DeleteProductsByName(name);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Product with product name " + name + " Deleted Successfully." };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Product could not be  Deleted " };
            }

        } //delete a product by name


        [HttpDelete("ProductbyID/{id}")]

        public ResponseMessage DeleteProductById(int id)
        {
            _logger.LogInformation("ProductController Excuting ....");
            try
            {
                ipr.DeleteProductById(id);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Product with product id " + id + " Deleted Successfully." };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Product Could not be deleted." };
            }

        }//delete a product by id


        [HttpPut("ProductbyProductID/{id}")]

        public ResponseMessage UpdateProductsById(int id, ProductView products)
        {
            _logger.LogInformation("ProductController Excuting ....");
            try
            {
                ipr.UpdateProductsById(id, products);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Product with product id " + id + " Updated Successfully." };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Product could not be Updated ." };
            }

        } //update a product using its id
        [HttpPut("addProductSpecification/{specificationId}/{productId}")]
        public ResponseMessage AddSpecificationsInProduct(int specificationId, int productId)
        {
            _logger.LogInformation("ProductController Excuting ....");
            try
            {
                ipsr.AddSpecificationsInProduct(specificationId, productId);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Specification with specificationsid " + specificationId + " Added Successfully." };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Specification could not be added." };
            }
        }
        [HttpPut("removeProductSpecification/{specificationId}/{productId}")]
        public ResponseMessage RemoveSpecificationsFromProduct(int specificationId, int productId)
        {
            _logger.LogInformation("ProductController Excuting ....");
            try
            {
                ipsr.RemoveSpecificationsFromProduct(specificationId, productId);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Specification with specificationsid " + specificationId + " Removed Successfully." };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Specification could not be removed." };
            }


        }
        [HttpGet("Specifications")]
        public IEnumerable<Specifications> GetAllSpecifications()
        {
            _logger.LogInformation("SpecificationsController Excuting ....");
            try
            {
                return isr.GetAllSpecifications();
            }
            catch (Exception)
            {
                return Enumerable.Empty<Specifications>();
            }

        } //get all Specifications

        [HttpGet("SpecificationsbyID")]
        public Specifications GetSpecificationsByID([FromHeader] int id)
        {
            _logger.LogInformation("SpecificationsController Excuting ....");
            try
            {
                return isr.GetSpecificationsByID(id);
            }
            catch (Exception)
            {
                return null;
            }

        } //get Specifications by its id
        [HttpGet("SpecificationsbyName")]
        public Specifications GetSpecificationsName([FromHeader] string name)
        {
            _logger.LogInformation("SpecificationsController Excuting ....");
            try
            {
                return isr.GetSpecificationsName(name);
            }
            catch (Exception)
            {
                return null;
            }

        } //get Specifications  by its name
        [HttpPost("Specifications")]
        public ResponseMessage AddSpecifications(IEnumerable<Specifications> specifications)
        {
            _logger.LogInformation("SpecificationsController Excuting ....");
            try
            {
                isr.AddSpecifications(specifications);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Specification Added Successfully." };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Specification could not be added ." };
            }

        } //add new Specifications ..can add multiple in a go
        [HttpDelete("SpecificationsbyName")]
        public ResponseMessage DeleteSpecificationsByName([FromHeader] string name)
        {
            _logger.LogInformation("SpecificationsController Excuting ....");
            try
            {
                isr.DeleteSpecificationsByName(name);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Specification with specification name " + name + " Deleted Successfully." };

            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Specification could not be Deleted" };
            }

        } //delete a Specification by name
        [HttpDelete("SpecificationsbyID")]
        public ResponseMessage DeleteSpecificationsByID([FromHeader] int id)
        {
            _logger.LogInformation("SpecificationsController Excuting ....");
            try
            {
                isr.DeleteSpecificationsByID(id);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Specification with specification id " + id + " Deleted Successfully." };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Specification could not be Deleted" };
            }

        }//delete a Specification by id
        [HttpPut("SpecificationsbyID")]
        public ResponseMessage UpdateSpecificationsbyID([FromHeader] int id, Specifications specifications)
        {
            _logger.LogInformation("SpecificationsController Excuting ....");
            try
            {
                isr.UpdateSpecificationsbyID(id, specifications);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Specification with  id " + id + " Updated Successfully." };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Specification could not be updated" };
            }

        } //update a Specification using its id
        [HttpPut("SpecificationsbyName")]
        public ResponseMessage UpdateSpecificationsbyName([FromHeader] string name, Specifications specifications)
        {
            _logger.LogInformation("SpecificationsController Excuting ....");
            try
            {
                isr.UpdateSpecificationsbyName(name, specifications);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Specification with specification name " + name + " Updated Successfully." };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Specification could not be updated" };
            }

        } //update a Specification using its name
        [HttpGet("Category")]
        public IEnumerable<Categories> GetAllCategories()
        {
            _logger.LogInformation("CategoryController Excuting ....");
            return icr.GetAllCategories();
        } //get all categories


        [HttpGet("CategorybyID")]
        public Categories GetCategoryByID([FromHeader] int id)
        {
            _logger.LogInformation("CategoryController Excuting ....");
            return icr.GetCategoryByID(id);
        } //get category by its id


        [HttpGet("CategorybyName")]
        public Categories GetCategoryName([FromHeader] string name)
        {
            _logger.LogInformation("CategoryController Excuting ....");
            return icr.GetCategoryName(name);
        } //get category  by its name


        [HttpPost("Category")]
        public ResponseMessage AddCategories(IEnumerable<Categories> categories)
        {
            try
            {
                _logger.LogInformation("CategoryController Excuting ....");
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Category Added Successfully." };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Could not add category to cart." };
            }
        } //add new categories ..can add multiple in a go


        [HttpDelete("CategorybyName")]
        public ResponseMessage DeleteCategoryByName([FromHeader] string name)
        {
            _logger.LogInformation("CategoryController Excuting ....");
            try
            {
                icr.DeleteCategoryByName(name);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Category name " + name + " Deleted Successfully." };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Could not delete category " };
            }

        } //delete a category by name


        [HttpDelete("CategorybyID")]
        public ResponseMessage DeleteCategoryByID([FromHeader] int id)
        {
            _logger.LogInformation("CategoryController Excuting ....");
            try
            {
                icr.DeleteCategoryByID(id);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Category id " + id + " Deleted Successfully." };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Could not delete category " };
            }
        }//delete a category by id
        [HttpPut("CategorybyID")]
        public ResponseMessage UpdateCategoriesbyID([FromHeader] int id, Categories categories)
        {
            _logger.LogInformation("CategoryController Excuting ....");
            try
            {
                icr.UpdateCategoriesbyID(id, categories);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Category with id " + id + " updated Successfully." };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Could not update category " };
            }
        } //update a category using its id
        [HttpPut("CategorybyName")]
        public ResponseMessage UpdateCategoriesbyName([FromHeader] string name, Categories categories)
        {
            _logger.LogInformation("CategoryController Excuting ....");
            try
            {
                icr.UpdateCategoriesbyName(name, categories);
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Category with name " + name + " updated Successfully." };
            }
            catch (Exception)
            {
                return new ResponseMessage { StatusCode = Response.StatusCode, Message = "Could not update category " };
            }
        } //update a category using its n
    }
}
