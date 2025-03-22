using MVC.BusinessLogic.DataTransferObjects;

namespace MVC.BusinessLogic.Services
{
    public interface IDepartmentService
    {
        int CreateDepartment(CreatedDepartmenDbo department);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDbo> GetAllDepartments();
        DepartmentDetailsDbo? GetDepartmentById(int id);
        int UpdateDepartment(UpdatedDepartmentDbo department);
    }
}