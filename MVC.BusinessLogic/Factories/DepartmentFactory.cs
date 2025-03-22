using MVC.ADataAccess.Models;
using MVC.BusinessLogic.DataTransferObjects;

namespace MVC.BusinessLogic.Factories
{
    static class DepartmentFactory
    {
        public static DepartmentDbo ToDepartmentDbo(this Department D)
        {
            return new DepartmentDbo
            {
                DeptId = D.Id,
                Name = D.Name,
                Code = D.Code,
                Description = D.Description,
                DateOfCreation = DateOnly.FromDateTime(D.CreatedOn)
            };
        }

        public static DepartmentDetailsDbo ToDepartmentDetailsDbo(this Department D)
        {
            return new DepartmentDetailsDbo
            {
                Id = D.Id,
                Name = D.Name,
                Code = D.Code,
                Description = D.Description,
                CreatedBy = D.CreatedBy,
                CreatedOn = DateOnly.FromDateTime(D.CreatedOn),
                LastModifiedBy = D.LastModifiedBy,
                LastModifiedOn = DateOnly.FromDateTime(D.LastModifiedOn),
                IsDeleted = D.IsDeleted
            };
        }

        public static Department ToEntity(this CreatedDepartmenDbo D)
        {
            return new Department
            {
                Name = D.Name,
                Code = D.Code,
                Description = D.Description,
                CreatedOn = D.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }

        public static Department ToEntity(this UpdatedDepartmentDbo D) => new Department
        {
            Id = D.Id,
            Name = D.Name,
            Code = D.Code,
            Description = D.Description,
            CreatedOn = D.DateOfCreation.ToDateTime(new TimeOnly())
        };
    }
}
