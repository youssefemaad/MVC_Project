using Demo.BusinessLogic.DataTransferObjects.DepartmentDataTransfer;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDataTransfer;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interface;
using Demo.DataAccess.Models;
using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Models.Shared.Enums;
using Demo.Presentation.ViewModels;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo.Presentation.Controllers
{
    public class EmployeeController(IEmployeeService employeeService
        , ILogger<DepartmentsController> _logger,
        IWebHostEnvironment environment) : Controller
    {
        public IActionResult Index(string? EmployeeSearchName)
        {
            var employees = employeeService.GetAllEmployees(EmployeeSearchName);
            return View(employees);
        }

        #region Create Employee
        public IActionResult Create()
        {
            var model = new EmployeeEditViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(EmployeeEditViewModel employeeEditView)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                try
                {
                    var employeeDto = new CreateEmployeeDto()
                    {
                        Age = employeeEditView.Age,
                        Name = employeeEditView.Name,
                        Email = employeeEditView.Email,
                        Image = employeeEditView.Image,
                        Salary = employeeEditView.Salary,
                        DeptId = employeeEditView.DeptId,
                        Address = employeeEditView.Address,
                        IsActive = employeeEditView.IsActive,
                        HiringDate = employeeEditView.HiringDate,
                        PhoneNumber = employeeEditView.PhoneNumber,
                        Gender = Enum.Parse<Gender>(employeeEditView.Gender.ToString()),
                        EmployeeType = Enum.Parse<EmployeeType>(employeeEditView.EmployeeType.ToString()),
                    };
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
                return View(employeeEditView);
            }
    
        #endregion

        #region Details Of Employee
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest(); // 400
            var employee = employeeService.GetEmployeeById(id.Value);
            if (employee == null) return NotFound(); // 404
            return View(employee);
        }
        #endregion

        #region Edit Employee
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest(); // 400
            var employee = employeeService.GetEmployeeById(id.Value);
            if (employee == null) return NotFound(); // 404

            var employeeEditViewModel = new EmployeeEditViewModel()
            {
                Id = employee.Id,
                Age = employee.Age,
                Name = employee.Name,
                Email = employee.Email,
                Salary = employee.Salary,
                DeptId = employee.DeptId,
                Address = employee.Address,
                IsActive = employee.IsActive,
                HiringDate = employee.HiringDate,
                PhoneNumber = employee.PhoneNumber,
                Gender = Enum.Parse<Gender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType)
            };
            return View(employeeEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, EmployeeEditViewModel employeeEditView)
        {
            if (!id.HasValue) return BadRequest();
            if (!ModelState.IsValid) return View(employeeEditView);
            try
            {
                var employeeDto = new UpdatedEmployeeDto()
                {
                    Id = id.Value,
                    Age = employeeEditView.Age,
                    Name = employeeEditView.Name,
                    Email = employeeEditView.Email,
                    DeptId = employeeEditView.DeptId,
                    Salary = employeeEditView.Salary,
                    Address = employeeEditView.Address,
                    IsActive = employeeEditView.IsActive,
                    HiringDate = employeeEditView.HiringDate,
                    PhoneNumber = employeeEditView.PhoneNumber,
                    Gender = employeeEditView.Gender,
                    EmployeeType = employeeEditView.EmployeeType

                };
                int Result = employeeService.UpdateEmployee(employeeDto);
                if (Result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Can't Update Employee");
                }
            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    _logger.LogError(ex.Message);
            }
            return View(employeeEditView);
        }

        #endregion

        #region Delete Employee
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                var Deleted = employeeService.DeleteEmployee(id);
                if (Deleted)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee not Deleted");
                    return RedirectToAction(nameof(Delete), new { id = id });
                }
            }
            catch (Exception ex)
            {

                if (environment.IsDevelopment())
                {
                    return RedirectToAction(nameof(Index));
                    // With Message That Department Not Deleted  
                }
                else
                {
                    _logger.LogError(ex.Message);
                    return View("Error", ex);
                }
            }
        }

        #endregion
    }
}