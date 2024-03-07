using AsssignmentMVC.Dtos;

namespace AsssignmentMVC.Repository.IRepository;

public interface IEmployeeSalaryRepository
{
    Task<bool> AddEmployeeSalaryAsync(EmployeeSalaryDto employeeSalaryDto);
}
