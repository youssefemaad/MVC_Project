namespace Demo.DataAccess.Repositories.Interfaces;

public interface IUnitOfWork
{
    public IEmployeeRepository EmployeeRepository { get; }
    public IDepartmentRepository DepartmentRepository { get; }
    public int SaveChanges();
}
