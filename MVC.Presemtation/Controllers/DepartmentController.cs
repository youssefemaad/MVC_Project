using Microsoft.AspNetCore.Mvc;
using MVC.BusinessLogic.Services;

namespace MVC.Presemtation.Controllers
{
    public class DepartmentController(IDepartmentService departmentService) : Controller
    {
        public IActionResult Index()
        {
            var departments = departmentService.GetAllDepartments();
            return View( );
        }
    }
}
