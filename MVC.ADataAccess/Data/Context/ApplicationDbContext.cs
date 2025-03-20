using System.Reflection;

namespace MVC.ADataAccess.Data.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)  //New feature C# 12
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  //before C# 12
        //{
        //}
        public DbSet<Department> Departments { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
