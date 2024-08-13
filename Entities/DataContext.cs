using System;
using Microsoft.EntityFrameworkCore;

namespace ExamInASP.NET_MVC.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        // Brand
        // User
    }
}

