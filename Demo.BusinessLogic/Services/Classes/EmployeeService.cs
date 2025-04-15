using System;
using System.Collections.Generic;
using AutoMapper;
using Demo.BusinessLogic.Services.AttatchementService;
using Demo.BusinessLogic.Services.Interface;
using Demo.DataAccess.Models;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.BusinessLogic.Services.Classes
{
    public class EmployeeService(IUnitOfWork _unitOfWork, IMapper _mapper, IAttatchementService _attatchementService) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(string? employeeSearchName)
        {
            var employees = string.IsNullOrWhiteSpace(employeeSearchName)
                ? _unitOfWork.EmployeeRepository.GetAll()
                : _unitOfWork.EmployeeRepository.GetAll(e => e.Name.ToLower().Contains(employeeSearchName.ToLower()));

            return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
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
            _unitOfWork.EmployeeRepository.Add(employee);
            return _unitOfWork.SaveChanges();

        }

        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            _unitOfWork.EmployeeRepository.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(employeeDto));
            return _unitOfWork.SaveChanges();
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            if (employee is null) return false;
            else
            {
                employee.IsDeleted = true;
                _unitOfWork.EmployeeRepository.Update(employee);
                return _unitOfWork.SaveChanges() > 0 ? true : false;
            } 
        }
    }
}
