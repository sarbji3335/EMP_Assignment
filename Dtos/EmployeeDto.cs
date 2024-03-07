using System.ComponentModel.DataAnnotations;

namespace AsssignmentMVC.Dtos;

public class EmployeeDto
{
    public int Id { get; set; }
    [StringLength(100)]
    public string FirstName { get; set; }
    [StringLength(100)]
    public string? LastName { get; set; }
    [StringLength(100)]
    public string? City { get; set; }
    [StringLength(10)]
    public string? Zip { get; set; }
    public DateTime CreatedDate { get; set; }
}
