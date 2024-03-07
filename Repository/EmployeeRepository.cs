using AsssignmentMVC.Data;
using AsssignmentMVC.Dtos;
using AsssignmentMVC.Models;
using AsssignmentMVC.Repository.IRepository;
using AutoMapper;

using Microsoft.EntityFrameworkCore;

namespace AsssignmentMVC.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public EmployeeRepository(ApplicationDbContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> AddEmployee(EmployeeDto employeeDto)
    {
        employeeDto.CreatedDate = DateTime.Now;
        await _context.Employees.AddAsync(_mapper.Map<Employee>(employeeDto));
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<EmployeeDto>> GetAll()
    {
        var employees = await _context.Employees.ToListAsync();
        return _mapper.Map<List<EmployeeDto>>(employees);
    }

    public async Task<EmployeeDto> GetEmployeeById(int id)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(a=>a.Id == id);
        return _mapper.Map<EmployeeDto>(employee);
    }

    public async Task<List<EmployeeSalaryDto>> GetemployeeSalariesById(int employeeId)
    {
        var employee = await _context.EmployeeSalaries.Where(e => e.EmployeeId == employeeId).ToListAsync();
        return _mapper.Map<List<EmployeeSalaryDto>>(employee);
    }

    public async Task<bool> UpdateEmployee(EmployeeDto employeeDto)
    {
         _context.Employees.Update(_mapper.Map<Employee>(employeeDto));
        await _context.SaveChangesAsync();
        return true;
    }
}
