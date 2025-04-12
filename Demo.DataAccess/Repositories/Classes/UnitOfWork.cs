using Demo.DataAccess.Data.DbContexts;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.DataAccess.Repositories.Classes;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    private readonly Lazy<IDepartmentRepository> _departmentRepository;
    private readonly Lazy<IEmployeeRepository> _employeeRepository;
    public UnitOfWork (DepartmentRepository departmentRepository, IEmployeeRepository employeeRepository, ApplicationDbContext dbContext)
    {
        this._dbContext = dbContext;
        _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(dbContext));
        _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(dbContext));
    }

    public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;
    public IDepartmentRepository DepartmentRepository => _departmentRepository.Value;

    public int SaveChanges()
    {
        return _dbContext.SaveChanges();
    }
}
