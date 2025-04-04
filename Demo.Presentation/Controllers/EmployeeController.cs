using Demo.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class EmployeeController(IEmployeeService employeeService) : Controller
    {
        public IActionResult Index()
        {
            var employees = employeeService.GetAllEmployees(true);
            return View(employees);
        }

        #region Create Employee

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

       

        #endregion
    }
}