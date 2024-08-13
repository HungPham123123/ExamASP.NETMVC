using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamInASP.NET_MVC.Entities
{
    [Table("department")]
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        public string DepartmentCode { get; set; }
        public string Location { get; set; }

        [Range(0, int.MaxValue)]
        public int NumberOfPersonals { get; set; }

        // Navigation property
        public ICollection<Employee> Employees { get; set; } = new List<Employee>(); // Initialize to avoid null issues
    }
}
