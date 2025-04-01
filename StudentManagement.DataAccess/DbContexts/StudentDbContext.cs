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
        public StudentDbContext() : base("StudentDbContext")
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
