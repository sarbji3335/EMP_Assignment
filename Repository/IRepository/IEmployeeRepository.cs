using AsssignmentMVC.Dtos;
using AsssignmentMVC.Models;

namespace AsssignmentMVC.Repository.IRepository;

public interface IEmployeeRepository
{
    Task<List<EmployeeDto>> GetAll();
    Task<bool> AddEmployee(EmployeeDto employeeDto);
    Task<EmployeeDto> GetEmployeeById(int id);
    Task<bool> UpdateEmployee(EmployeeDto employeeDto);
    Task<List<EmployeeSalaryDto>> GetemployeeSalariesById(int employeeId);
}
