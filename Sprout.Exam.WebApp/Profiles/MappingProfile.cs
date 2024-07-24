using AutoMapper;
using Sprout.Exam.Business.Commands.Employee;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.DataAccess.Entities;

namespace Sprout.Exam.WebApp.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Birthdate.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.EmployeeTypeId));
            CreateMap<EmployeeDto, Employee>()
                .ForMember(dest => dest.EmployeeTypeId, opt => opt.MapFrom(src => src.TypeId));
            CreateMap<CreateEmployeeDto, Employee>()
                .ForMember(dest => dest.EmployeeTypeId, opt => opt.MapFrom(src => src.TypeId))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));
            CreateMap<CreateEmployeeDto, CreateEmployeeCommand>().ReverseMap();
            CreateMap<CreateEmployeeCommand, Employee>()
                .ForMember(dest => dest.EmployeeTypeId, opt => opt.MapFrom(src => src.TypeId))
                .ReverseMap();
            CreateMap<EditEmployeeDto, UpdateEmployeeCommand>().ReverseMap();
        }
    }
}
