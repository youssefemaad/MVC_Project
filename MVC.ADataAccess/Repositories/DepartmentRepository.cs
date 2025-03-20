using MVC.ADataAccess.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ADataAccess.Repositories
{
    public class DepartmentRepository(ApplicationDbContext _dbContext)
    {
        //private readonly ApplicationDbContext _dbContext;             //before C# 12
        //public DepartmentRepository(ApplicationDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //CRUD operations
        //Get All

        //Get By Id
        public Department? GetById(int id)
        {
            var department = _dbContext.Departments.Find(id);
            return department;
        }
        //Update
        //Delete
        //Insert
    }
}
