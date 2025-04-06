using Demo.DataAccess.Models.DepartmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        int Add(Employee employee);
        IEnumerable<Employee> GetAll(bool withTracking = false);
        Employee? GetById(int id);
        int Remove(Employee employee);
        int Update(Employee employee);
    }
}
