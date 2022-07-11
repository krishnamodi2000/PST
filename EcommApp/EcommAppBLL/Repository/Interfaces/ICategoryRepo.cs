using EcommAppDAL.Models;

namespace EcommAppBLL.Repository.Category
{/// <summary>
/// This is ICategoryRepo interface that declares all the CRUD opertations for Category controller.
/// </summary>
    public interface ICategoryRepo
    {/// <summary>
    /// ICategoryRepo Declares all the CRUD methods.
    /// </summary>
    /// <param name="categories"></param>
    /// <returns></returns>
       
        IEnumerable<Categories> AddCategories(IEnumerable<Categories> categories);
        Categories DeleteCategoryByID(int id);
        Categories DeleteCategoryByName(string name);
        IEnumerable<Categories> GetAllCategories();
        Categories GetCategoryByID(int id);
        Categories GetCategoryName(string name);
        Categories UpdateCategoriesbyID(int id, Categories categories);
        Categories UpdateCategoriesbyName(string name, Categories categories);
    }
}