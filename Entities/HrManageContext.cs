using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExamInASP.NET_MVC.Entities;

public partial class HrManageContext : DbContext
{
    public HrManageContext()
    {
    }

    public HrManageContext(DbContextOptions<HrManageContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost,1433;Database=HR_MANAGE;User Id=sa;Password=Password789;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
