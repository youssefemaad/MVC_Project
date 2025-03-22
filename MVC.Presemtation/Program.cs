using Microsoft.EntityFrameworkCore;
using MVC.ADataAccess.Data.Context;
using MVC.ADataAccess.Repositories;
using MVC.BusinessLogic.Services;

namespace MVC.Presemtation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                //options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);    option 1
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); // option 2
            });
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>(); //New feature C# 12
            builder.Services.AddScoped<IDepartmentService, DepartmentService>(); //New feature C# 12
            #endregion

            var app = builder.Build();

            #region Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            #endregion

            app.Run();
        }
    }
}
