using System;
using System.Collections.Generic;
using AutoMapper;
using Demo.BusinessLogic.Services.Interface;
using Demo.DataAccess.Models;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.BusinessLogic.Services.Classes
{
    public class EmployeeService(IEmployeeRepository _employeeRepository, IMapper _mapper) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(bool WithTracking = false)
        {
            var Employees = _employeeRepository.GetAll(WithTracking);
            var employeeDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(Employees);
            return employeeDto;
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            return employee is null ? null : _mapper.Map<Employee, EmployeeDetailsDto>(employee);

            //return employee is null ? null : new EmployeeDetailsDto()  Manual Mapping
            //    Id = employee.Id,
            //    Name = employee.Name,
            //    Age = employee.Age,
            //    Address = employee.Address,
            //    Salary = employee.Salary,
            //    IsActive = employee.IsActive,
            //    Email = employee.Email,
            //    PhoneNumber = employee.PhoneNumber,
            //    HiringDate = DateOnly.FromDateTime(employee.HiringDate),
            //    EmployeeType = employee.EmployeeType.ToString(),
            //    Gender = employee.Gender.ToString(),
            //    CreatedBy = 1,
            //    CreatedOn = employee.CreatedOn,
            //    LastModifiedBy = 1,
            //    LastModifiedOn = employee.LastModifiedOn
            //};
        }


        public int CreateEmployee(CreateEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<CreateEmployeeDto, Employee>(employeeDto);
            return _employeeRepository.Add(employee);

        }

        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            return _employeeRepository.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(employeeDto));
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee is null) return false;
            else
            {
                employee.IsDeleted = true;
                return _employeeRepository.Update(employee) > 0 ? true : false;
            } 
        }
    }
}
