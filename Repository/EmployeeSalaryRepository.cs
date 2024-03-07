using AsssignmentMVC.Data;
using AsssignmentMVC.Dtos;
using AsssignmentMVC.Models;
using AsssignmentMVC.Repository.IRepository;
using AutoMapper;

namespace AsssignmentMVC.Repository;

public class EmployeeSalaryRepository : IEmployeeSalaryRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public EmployeeSalaryRepository(ApplicationDbContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<bool> AddEmployeeSalaryAsync(EmployeeSalaryDto employeeSalaryDto)
    {
        var emp = _mapper.Map<EmployeeSalary>(employeeSalaryDto);
        await _context.EmployeeSalaries.AddAsync(emp);
        await _context.SaveChangesAsync();
        return true;
    }
}
