using System.Collections.Generic;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDataTransfer;

namespace Demo.BusinessLogic.Services.Interface
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees(bool WithTracking);
        EmployeeDetailsDto GetEmployeeById(int id);
        int CreateEmployee(CreateEmployeeDto employeeDto);
        int UpdateEmployee(UpdatedEmployeeDto employeeDto);
        bool DeleteEmployee(int id);
    }
}
