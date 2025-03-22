using MVC.ADataAccess.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ADataAccess.Repositories
{
    public class DepartmentRepository(ApplicationDbContext _dbContext) : IDepartmentRepository
    //New feature C# 12
    {
        //private readonly ApplicationDbContext _dbContext;             //before C# 12
        //public DepartmentRepository(ApplicationDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //Get All

        public IEnumerable<Department> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
                return _dbContext.Departments.ToList();

            else
                return _dbContext.Departments.AsNoTracking().ToList();
        }

        //Get By Id
        public Department? GetById(int id)
        {
            var department = _dbContext.Departments.Find(id);
            return department;
        }

        //Update
        public int Update(Department department)
        {
            _dbContext.Departments.Update(department); //Update Locally
            return _dbContext.SaveChanges();
        }

        //Delete
        public int Remove(Department department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }

        //Insert
        public int Add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }
    }
}
