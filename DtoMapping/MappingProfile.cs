using AsssignmentMVC.Dtos;
using AsssignmentMVC.Models;
using AutoMapper;

namespace AsssignmentMVC.DtoMapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<EmployeeSalaryDto, EmployeeSalary>().ReverseMap();
    }
}
