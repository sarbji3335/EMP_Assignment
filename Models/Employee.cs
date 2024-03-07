using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace AsssignmentMVC.Models;

public class Employee
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
