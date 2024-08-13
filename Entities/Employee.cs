using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ExamInASP.NET_MVC.Entities
{
    [Table("employee")]
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public string EmployeeCode { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [ValidateNever]
        public virtual Department Department { get; set; }


        [Required]
        public double Rank { get; set; } 
    }
}
