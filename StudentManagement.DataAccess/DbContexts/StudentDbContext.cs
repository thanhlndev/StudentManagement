using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using StudentManagement.DataAccess.Entities;

namespace StudentManagement.DataAccess.DbContexts
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext() : base("StudentManagementDbContext")
        {
            this.Database.Log = Console.Write;
        }
        //entities
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<TrainingProgram> TrainingPrograms { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<StudentDbContext>());
            // Cấu hình cho bảng Faculty
            modelBuilder.Entity<Faculty>()
            .Property(f => f.FacultyCode)
            .HasMaxLength(10)
            .IsRequired();

            modelBuilder.Entity<Faculty>()
                .Property(f => f.FacultyName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode(true);
            modelBuilder.Entity<Employee>()
            .Property(e => e.EmployeeCode)
            .HasMaxLength(10)
            .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode(true);
            // Cấu hình unicode cho bảng Employee
            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeType)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(true);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Hometown)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsUnicode(true);

            // Cấu hình unicode cho bảng Major
            modelBuilder.Entity<Major>()
                .Property(m => m.MajorCode)
                .HasMaxLength(10)
                .IsRequired();

            modelBuilder.Entity<Major>()
                .Property(m => m.MajorName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode(true);

            modelBuilder.Entity<Major>()
                .Property(m => m.FacultyCode)
                .HasMaxLength(10)
                .IsRequired();

            // Cấu hình unicode cho bảng Class
            modelBuilder.Entity<Class>()
                .Property(c => c.ClassCode)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(10)
                .IsRequired()
                .IsUnicode(true);

            modelBuilder.Entity<Class>()
                .Property(c => c.ClassName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode(true);

            modelBuilder.Entity<Class>()
                .Property(c => c.EducationType)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(true);

            modelBuilder.Entity<Class>()
                .Property(c => c.ClassSection)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(5)
                .IsRequired()
                .IsUnicode(true);

            // Cấu hình unicode cho bảng TrainingProgram
            modelBuilder.Entity<TrainingProgram>()
                .Property(tp => tp.ProgramCode)
                .HasMaxLength(10)
                .IsRequired();

            modelBuilder.Entity<TrainingProgram>()
                .Property(tp => tp.ProgramType)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(true);

            // Cấu hình unicode cho bảng Student
            modelBuilder.Entity<Student>()
                .Property(s => s.StudentCode)
                .HasMaxLength(10)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(s => s.FullName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode(true);

            modelBuilder.Entity<Student>()
                .Property(s => s.Gender)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(10)
                .IsRequired()
                .IsUnicode(true);

            modelBuilder.Entity<Student>()
                .Property(s => s.Address)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200)
                .IsUnicode(true);

            modelBuilder.Entity<Student>()
                .Property(s => s.Hometown)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsUnicode(true);

            modelBuilder.Entity<Student>()
                .Property(s => s.Email)
                .HasMaxLength(100);

            modelBuilder.Entity<Student>()
                .Property(s => s.PhoneNumber)
                .HasMaxLength(15);

            modelBuilder.Entity<Student>()
                .Property(s => s.ClassCode)
                .HasMaxLength(10)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(s => s.ProgramCode)
                .HasMaxLength(10)
                .IsRequired();

            // Cấu hình unicode cho bảng Course
            modelBuilder.Entity<Course>()
                .Property(c => c.CourseCode)
                .HasMaxLength(10)
                .IsRequired();

            modelBuilder.Entity<Course>()
                .Property(c => c.CourseName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode(true);

            modelBuilder.Entity<Course>()
                .Property(c => c.Semester)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(20)
                .IsRequired()
                .IsUnicode(true);

            modelBuilder.Entity<Course>()
                .Property(c => c.CreditCount)
                .IsRequired();

            modelBuilder.Entity<Course>()
                .Property(c => c.EmployeeCode)
                .HasMaxLength(10)
                .IsRequired();

            modelBuilder.Entity<Course>()
                .Property(c => c.ProgramCode)
                .HasMaxLength(10)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
