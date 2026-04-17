using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;

using Swashbuckle.AspNetCore.SwaggerUI;


namespace AspnetCoreWebApi.Models;

public partial class StudentdbContext : DbContext
{
    public StudentdbContext()
    {
    }

    public StudentdbContext(DbContextOptions<StudentdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StudentDetail> StudentDetails { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentD__3214EC07D753C3CB");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FatherName).HasMaxLength(50);
            entity.Property(e => e.StudentGender).HasMaxLength(10);
            entity.Property(e => e.StudentName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
