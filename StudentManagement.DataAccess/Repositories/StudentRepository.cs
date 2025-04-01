using System;
using System.Linq;
using System.Data.Entity; // hoặc Microsoft.EntityFrameworkCore nếu dùng EF Core
using StudentManagement.DataAccess.DbContexts;
using StudentManagement.DataAccess.Entities;
using StudentManagement.DataAccess.InterfaceRepository;
using System.Collections.Generic;

namespace StudentManagement.DataAccess.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;

        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students
                .Include(s => s.Class)
                .Include(s => s.Program)
                .ToList();
        }

        public Student GetByStudentCode(string studentCode)
        {
            return _context.Students
                .Include(s => s.Class)
                .Include(s => s.Program)
                .FirstOrDefault(s => s.StudentCode == studentCode);
        }

        public void Add(Student student)
        {
            var classEntity = _context.Classes.FirstOrDefault(c => c.ClassCode == student.ClassCode);
            if (classEntity == null)
            {
                throw new Exception($"Class with code {student.ClassCode} does not exist.");
            }

            var programEntity = _context.TrainingPrograms.FirstOrDefault(p => p.ProgramCode == student.ProgramCode);
            if (programEntity == null)
            {
                throw new Exception($"Training program with code {student.ProgramCode} does not exist.");
            }

            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Update(Guid studentId, Student student)
        {
            var existStudent = _context.Students.Find(studentId);
            if (existStudent != null)
            {
                var classEntity = _context.Classes.FirstOrDefault(c => c.ClassCode == student.ClassCode);
                if (classEntity == null)
                {
                    throw new Exception($"Class with code {student.ClassCode} does not exist.");
                }

                var programEntity = _context.TrainingPrograms.FirstOrDefault(p => p.ProgramCode == student.ProgramCode);
                if (programEntity == null)
                {
                    throw new Exception($"Training program with code {student.ProgramCode} does not exist.");
                }

                _context.Entry(existStudent).CurrentValues.SetValues(student);
                _context.SaveChanges();
            }
        }

        public void Delete(Guid studentId)
        {
            var student = _context.Students.Find(studentId);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}