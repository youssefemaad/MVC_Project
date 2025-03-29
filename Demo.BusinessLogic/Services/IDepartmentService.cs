﻿using Demo.BusinessLogic.DataTransferObjects;

namespace Demo.BusinessLogic.Services
{
	public interface IDepartmentService
	{
		int CreateDepartment(CreatedDepartmentDto departmentDto);
		bool DeleteDepartment(int id);
		IEnumerable<DepartmentDto> GetAllDepartments();
		DepartmentDetailsDto? GetDepartmentById(int id);
		int UpdateDepartment(UpdatedDepartmentDto departmentDto);
	}
}