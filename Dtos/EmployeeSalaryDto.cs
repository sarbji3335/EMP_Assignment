using AsssignmentMVC.Models;

namespace AsssignmentMVC.Dtos;

public class EmployeeSalaryDto
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime SalaryDate { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedDate { get; set; }
}
