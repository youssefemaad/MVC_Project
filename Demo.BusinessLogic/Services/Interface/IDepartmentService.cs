using Demo.BusinessLogic.DataTransferObjects.DepartmentDataTransfer;

namespace Demo.BusinessLogic.Services.Interface
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