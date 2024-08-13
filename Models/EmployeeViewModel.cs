using ExamInASP.NET_MVC.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamInASP.NET_MVC.Models
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public SelectList Departments { get; set; }
    }
}