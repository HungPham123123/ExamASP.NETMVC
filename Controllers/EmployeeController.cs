using ExamInASP.NET_MVC.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using ExamInASP.NET_MVC.Models;

namespace ExamInASP.NET_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        // Show the form to add a new employee
        public async Task<IActionResult> Create()
        {
            // Fetch the departments to populate the dropdown
            ViewBag.Departments = new SelectList(await _context.Departments.ToListAsync(), "DepartmentId", "DepartmentName");

            // Pass a new Employee instance to the view
            return View(new Employee());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeName,EmployeeCode,DepartmentId,Rank")] Employee employee)
        {
            Console.WriteLine($"Posted Employee: Name = {employee.EmployeeName}, Code = {employee.EmployeeCode}, DepartmentId = {employee.DepartmentId}, Rank = {employee.Rank}");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Employees.Add(employee);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the employee. Please try again later.");
                }
            }
            else
            {
                // Log validation errors
                foreach (var modelState in ModelState)
                {
                    var key = modelState.Key;
                    var errors = modelState.Value.Errors;
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"Key: {key}, Error: {error.ErrorMessage}");
                    }
                }
            }

            var departments = await _context.Departments.ToListAsync();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName");
            return View(employee);
        }













        // Display the list of employees
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees.Include(e => e.Department).ToListAsync();
            return View(employees);
        }
    }
}
