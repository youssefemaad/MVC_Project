using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDataTransfer;

namespace Demo.BusinessLogic.Services.Interface
{
    public class IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees(bool WithTracking);
        EmployeeDetailsDto GetEmployeeById(int id);
        int CreateEmployee(CreateEmployeeDto employeeDto);
        int UpdateEmployee(UpdatedEmployeeDto employeeDto);
        bool DeleteEmployee(int id);
    }
}
