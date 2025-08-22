using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DesignUI.Models;

public partial class DBEntities : DbContext
{
    public DBEntities()
    {
    }

    public DBEntities(DbContextOptions<DBEntities> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentTeacher> StudentTeachers { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\DARABEE;Database=AapCourse;User Id=sa;Password=sqlserver1256;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.CountryId).ValueGeneratedNever();
            entity.Property(e => e.CountryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");

            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.DataOfbirth).HasColumnName("DataOFBirth");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Mobile).HasMaxLength(50);

            entity.HasOne(d => d.Country).WithMany(p => p.Students)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Students_Country");
        });

        modelBuilder.Entity<StudentTeacher>(entity =>
        {
            entity.ToTable("StudentTeacher");

            entity.Property(e => e.StudentTeacherId)
                .ValueGeneratedNever()
                .HasColumnName("StudentTeacherID");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentTeachers)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_StudentTeacher_Students");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.ToTable("Teacher");

            entity.Property(e => e.TeacherId)
                .ValueGeneratedNever()
                .HasColumnName("TeacherID");
            entity.Property(e => e.TeacherName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
