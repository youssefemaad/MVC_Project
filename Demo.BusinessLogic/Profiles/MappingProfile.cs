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
                    .ForMember(dest => dest.Emp_Gender, Option => Option.MapFrom(src => src.Gender))
                    .ForMember(dest => dest.Emp_EmployeeType, opt =>opt.MapFrom(src => src.EmployeeType));
            CreateMap<Employee, EmployeeDetailsDto>()
                    .ForMember(dest => dest.Gender, Option => Option.MapFrom(src => src.Gender))
                    .ForMember(dest => dest.EmployeeType, opt =>opt.MapFrom(src => src.EmployeeType))
                    .ForMember(dest => dest.HiringDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)));
            CreateMap<CreateEmployeeDto, Employee>()
                    .ForMember(dest => dest.HiringDate, opt => opt.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));
            CreateMap<UpdatedEmployeeDto, Employee>()
                    .ForMember(dest => dest.HiringDate, opt => opt.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));
        }
    }
}
