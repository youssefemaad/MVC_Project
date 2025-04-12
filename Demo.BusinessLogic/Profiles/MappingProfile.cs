using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Models;
namespace Demo.BusinessLogic.Profiles
{
        public class MappingProfile : Profile
        {
                public MappingProfile()
                {
                        CreateMap<Employee, EmployeeDto>()
                                .ForMember(dist => dist.Emp_Gender, Option => Option.MapFrom(src => src.Gender))
                                .ForMember(dist => dist.Emp_EmployeeType, opt => opt.MapFrom(src => src.EmployeeType))
                                .ForMember(dist => dist.Department, opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : null));
                        CreateMap<Employee, EmployeeDetailsDto>()
                                .ForMember(dist => dist.Gender, Option => Option.MapFrom(src => src.Gender))
                                .ForMember(dist => dist.EmployeeType, opt => opt.MapFrom(src => src.EmployeeType))
                                .ForMember(dist => dist.HiringDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)));
                        CreateMap<CreateEmployeeDto, Employee>()
                                .ForMember(dist => dist.HiringDate, opt => opt.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));
                        CreateMap<UpdatedEmployeeDto, Employee>()
                                .ForMember(dist => dist.HiringDate, opt => opt.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));
                }
        }
}
