using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext() { }

        public StudentSystemContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=StudentSystem;Integrated Security=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(r => r.Url).IsUnicode(false);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.Property(h => h.Content).IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(s => s.PhoneNumber)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasMaxLength(10);
            });
        }
    }
}
