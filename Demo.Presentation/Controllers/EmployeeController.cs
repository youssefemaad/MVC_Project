using Demo.BusinessLogic.DataTransferObjects.DepartmentDataTransfer;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDataTransfer;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo.Presentation.Controllers
{
    public class EmployeeController(IEmployeeService employeeService
        , ILogger<DepartmentsController> _logger,
        IWebHostEnvironment environment) : Controller
    {
        public IActionResult Index()
        {
            var employees = employeeService.GetAllEmployees(true);
            return View(employees);
        }

        #region Create Employee
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateEmployeeDto employeeDto)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                try
                {
                    int Result = employeeService.CreateEmployee(employeeDto);
                    if (Result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Can't Create Employee");
                    }
                }
                catch (Exception ex)
                {

                    if (environment.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else
                        _logger.LogError(ex.Message);
                }
            }
            return View(employeeDto);
        }
        #endregion
    }
}