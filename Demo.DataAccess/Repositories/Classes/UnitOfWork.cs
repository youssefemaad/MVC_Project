using Demo.DataAccess.Data.DbContexts;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.DataAccess.Repositories.Classes;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    private readonly Lazy<IDepartmentRepository> _departmentRepository;
    private readonly Lazy<IEmployeeRepository> _employeeRepository;

    public UnitOfWork(ApplicationDbContext dbContext, IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository)
    {
        _dbContext = dbContext;
        _departmentRepository = new Lazy<IDepartmentRepository>(() => departmentRepository);
        _employeeRepository = new Lazy<IEmployeeRepository>(() => employeeRepository);
    }

    public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;
    public IDepartmentRepository DepartmentRepository => _departmentRepository.Value;

    public int SaveChanges()
    {
        return _dbContext.SaveChanges();
    }
}
