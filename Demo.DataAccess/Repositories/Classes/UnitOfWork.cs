using Demo.DataAccess.Data.DbContexts;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.DataAccess.Repositories.Classes;

public class UnitOfWork : IUnitOfWork
{
    private IDepartmentRepository _departmentRepository;
    private IEmployeeRepository _employeeRepository;
    private readonly ApplicationDbContext _dbContext;
    public UnitOfWork (DepartmentRepository departmentRepository, IEmployeeRepository employeeRepository, ApplicationDbContext dbContext)
    {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
        this._dbContext = dbContext;
    }

    public IEmployeeRepository EmployeeRepository => throw new NotImplementedException();
    public IDepartmentRepository DepartmentRepository => throw new NotImplementedException();

    public int SaveChanges()
    {
        return _dbContext.SaveChanges();
    }
}
