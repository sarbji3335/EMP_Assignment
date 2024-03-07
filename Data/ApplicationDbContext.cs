using AsssignmentMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AsssignmentMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
    }
}
