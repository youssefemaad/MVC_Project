using Demo.BusinessLogic.DataTransferObjects.DepartmentDataTransfer;
using Demo.BusinessLogic.Factories;
using Demo.BusinessLogic.Services.Interface;
using Demo.DataAccess.Models;
using Demo.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.Classes
{
	public class DepartmentService(IUnitOfWork _UnitOfWork) : IDepartmentService
	{

		// Get All Departments 
		public IEnumerable<DepartmentDto> GetAllDepartments()
		{
			var Departments = _UnitOfWork.DepartmentRepository.GetAll();

			return Departments.Select(D => D.ToDto());
		}


		// Get Department By Id 
		public DepartmentDetailsDto? GetDepartmentById(int id)
		{
			var department = _UnitOfWork.DepartmentRepository.GetById(id);

			// Manual Mapping 
			return department?.ToDetailsDto();
		}

		// Create New Department 
		public int CreateDepartment(CreatedDepartmentDto departmentDto)
		{
			var department = departmentDto.ToEntity();
			_UnitOfWork.DepartmentRepository.Add(department);
			return _UnitOfWork.SaveChanges();
		}

		// Updated Department 
		public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
		{
			var department = departmentDto.ToEntity();
			_UnitOfWork.DepartmentRepository.Update(department);
			return _UnitOfWork.SaveChanges();
		}

		// Delete Department 

		public bool DeleteDepartment(int id)
		{
			var department = _UnitOfWork.DepartmentRepository.GetById(id);
			if (department is null) return false;
			else
			{
				_UnitOfWork.DepartmentRepository.Remove(department);
				int result = _UnitOfWork.SaveChanges();
				return result > 0 ? true : false;
			}
		}
	}
}
