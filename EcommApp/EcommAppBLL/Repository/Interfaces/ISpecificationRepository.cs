using EcommAppDAL.Models;

namespace EcommAppBLL.Repository.Specification
{/// <summary>
/// This is ISpecificationRepository interface that declares all the CRUD operations for Specification Controller.
/// </summary>
    public interface ISpecificationRepository
    {/// <summary>
     /// ISpecificationRepository declares all methods for Specification table.
     /// </summary>
     /// <param name="specifications"></param>
     /// <returns></returns>
        IEnumerable<Specifications> AddSpecifications(IEnumerable<Specifications> specifications);
        Specifications DeleteSpecificationsByID(int id);
        Specifications DeleteSpecificationsByName(string name);
        IEnumerable<Specifications> GetAllSpecifications();
        Specifications GetSpecificationsByID(int id);
        Specifications GetSpecificationsName(string name);
        Specifications UpdateSpecificationsbyID(int id, Specifications specifications);
        Specifications UpdateSpecificationsbyName(string name, Specifications specifications);
    }
}