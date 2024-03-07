using AsssignmentMVC.Dtos;
using AsssignmentMVC.Models;
using AsssignmentMVC.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AsssignmentMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeSalaryRepository _employeeSalaryRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, IEmployeeSalaryRepository employeeSalaryRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeSalaryRepository = employeeSalaryRepository;
        }

        #region Actions

        /// <summary>
        /// Displays all employees.
        /// </summary>
        /// <returns>The view containing all employees.</returns>
        public async Task<IActionResult> Index()
        {
            try
            {
                var employees = await _employeeRepository.GetAll();
                return View(employees);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Displays form to add a new employee.
        /// </summary>
        /// <returns>The view for adding a new employee.</returns>
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="employeeDto">Data for the new employee.</param>
        /// <returns>Redirects to the index page after successful addition.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeDto employeeDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _employeeRepository.AddEmployee(employeeDto);
                    return RedirectToAction("Index", "Employee");
                }
                return View(employeeDto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Displays form to add salary for an employee.
        /// </summary>
        /// <returns>The view for adding salary.</returns>
        public async Task<IActionResult> AddSalary()
        {
            ViewBag.Employees = await _employeeRepository.GetAll();
            return View();
        }

        /// <summary>
        /// Adds salary for an employee.
        /// </summary>
        /// <param name="employeeSalaryDto">Data for the salary.</param>
        /// <returns>Redirects to the index page after successful addition.</returns>
        [HttpPost]
        public async Task<IActionResult> AddSalary(EmployeeSalaryDto employeeSalaryDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _employeeSalaryRepository.AddEmployeeSalaryAsync(employeeSalaryDto);
                    return RedirectToAction("Index", "Employee");
                }
                return View(employeeSalaryDto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Displays details of an employee.
        /// </summary>
        /// <param name="id">ID of the employee.</param>
        /// <returns>Partial view containing employee details.</returns>
        public async Task<ActionResult> Details(int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);
            return PartialView("_employee", employee);
        }

        /// <summary>
        /// Edits employee information.
        /// </summary>
        /// <param name="employee">Updated data for the employee.</param>
        /// <returns>Redirects to the index page after successful update.</returns>
        [HttpPost]
        public async Task<ActionResult> Edit(EmployeeDto employee)
        {
            try
            {
                // Update the employee details in your data source (e.g., database)
                await _employeeRepository.UpdateEmployee(employee);

                // Redirect to the original page or any other page as needed
                return RedirectToAction("Index", "Employee");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieves the salary records of an employee.
        /// </summary>
        /// <param name="employeeId">ID of the employee.</param>
        /// <returns>Partial view containing employee salary records.</returns>
        public async Task<IActionResult> GetSalaryRecords(int employeeId)
        {
            try
            {
                var employeeSalary = await _employeeRepository.GetemployeeSalariesById(employeeId);
                return PartialView("_EmployeeSalary", employeeSalary);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
    }
}