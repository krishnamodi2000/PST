using EcommAppDAL.Context;
using EcommAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommAppBLL.Repository.Specification
{/// <summary>
/// This is SpecificationRepository that defines all the CRUD operations for Specification controller.
/// </summary>
    public class SpecificationsRepository : ISpecificationRepository
    {/// <summary>
     /// SpecificationsRepository uses ISpecificationsRepository interface and contains all the defnition for CRUD operations for Specification Table.
     /// </summary>
        DatabaseContext db;
        public SpecificationsRepository(DatabaseContext _db)
        {
            db = _db;
        }

        public IEnumerable<Specifications> AddSpecifications(IEnumerable<Specifications> specifications)
        {
            db.Specifications.AddRange(specifications);
            db.SaveChanges();
            return (specifications);
        }

        public Specifications DeleteSpecificationsByID(int id)
        {
            Specifications specifications = db.Specifications.FirstOrDefault(c => c.SpecificationId == id); //check the Specification id in db and delete it if it exists
            if (specifications != null)
            {
                db.Remove(specifications);
                db.SaveChanges();
                
            }
            return (specifications);
        }

        public Specifications DeleteSpecificationsByName(string name)
        {
            Specifications specifications = db.Specifications.FirstOrDefault(c => c.SpecificationName == name); //check the Specification name in db and delete it if it exists
            if (specifications != null)
            {
                db.Remove(specifications);
                db.SaveChanges();
            }
            return (specifications);
        }

        public IEnumerable<Specifications> GetAllSpecifications()
        {
            return db.Specifications.Select(x => x).ToList();
        }

        public Specifications GetSpecificationsByID(int id)
        {
            return (db.Specifications.Find(id));
        }

        public Specifications GetSpecificationsName(string name)
        {
            Specifications specifications = db.Specifications.FirstOrDefault(c => c.SpecificationName == name);
            return (specifications);
        }

        public Specifications UpdateSpecificationsbyID(int id, Specifications specifications)
        {
            var specs = db.Specifications.FirstOrDefault(c => c.SpecificationId == id); //check if id exists and only then update it
            if (specs != null)
            {
                db.Entry<Specifications>(specs).CurrentValues.SetValues(specifications);
                db.SaveChanges();
            }
            return (specifications);
        }

        public Specifications UpdateSpecificationsbyName(string name, Specifications specifications)
        {

            var specs = db.Specifications.FirstOrDefault(c => c.SpecificationName == name); //check if name exists and only then update it
            if (specs != null)
            {
                db.Entry<Specifications>(specs).CurrentValues.SetValues(specifications);
                db.SaveChanges();
            }
            return (specifications);
        }
    }
}
