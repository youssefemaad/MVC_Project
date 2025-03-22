using MVC.ADataAccess.Repositories;
using MVC.BusinessLogic.DataTransferObjects;
using MVC.BusinessLogic.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BusinessLogic.Services
{
    public class DepartmentService(IDepartmentRepository departmentRepository) : IDepartmentService
    {
        //Get All Departments
        public IEnumerable<DepartmentDbo> GetAllDepartments()
        {
            var departments = departmentRepository.GetAll();
            return departments.Select(D => D.ToDepartmentDbo());
        }

        //Get Department By Id
        public DepartmentDetailsDbo? GetDepartmentById(int id)
        {
            var department = departmentRepository.GetById(id);
            return department is null ? null : department.ToDepartmentDetailsDbo();
        }

        //Create Department
        public int CreateDepartment(CreatedDepartmenDbo department)
        {
            var departmentEntity = department.ToEntity();
            return departmentRepository.Add(departmentEntity);
        }

        //Update Department
        public int UpdateDepartment(UpdatedDepartmentDbo department)
        {
            return departmentRepository.Update(department.ToEntity());
        }

        //Delete Department
        public bool DeleteDepartment(int id)
        {
            var department = departmentRepository.GetById(id);
            if (department is null) return false;
            else
            {
                int result = departmentRepository.Remove(department);
                return result > 0 ? true : false;
            }
        }
    }
}
