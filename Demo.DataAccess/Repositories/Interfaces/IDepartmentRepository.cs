﻿using Demo.DataAccess.Models.DepartmentModel;

namespace Demo.DataAccess.Repositories.Interfaces
{
	public interface IDepartmentRepository
	{
		int Add(Department department);
		IEnumerable<Department> GetAll(bool withTracking = false);
		Department? GetById(int id);
		int Remove(Department department);
		int Update(Department department);
	}
}