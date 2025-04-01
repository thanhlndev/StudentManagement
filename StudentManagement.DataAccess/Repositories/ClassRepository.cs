using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity; // Hoặc Microsoft.EntityFrameworkCore nếu dùng EF Core
using StudentManagement.DataAccess.DbContexts;
using StudentManagement.DataAccess.Entities;
using StudentManagement.DataAccess.InterfaceRepositories;

namespace StudentManagement.DataAccess.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly StudentDbContext _context;

        public ClassRepository(StudentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Class> GetAll()
        {
            return _context.Classes
                .Include(c => c.Major)
                .ToList();
        }

        public Class GetByClassCode(string classCode)
        {
            return _context.Classes
                .Include(c => c.Major)
                .FirstOrDefault(c => c.ClassCode == classCode);
        }

        public void Add(Class classEntity)
        {
            var major = _context.Majors.FirstOrDefault(m => m.MajorCode == classEntity.MajorCode);
            if (major == null)
            {
                throw new Exception($"Major với mã {classEntity.MajorCode} không tồn tại!");
            }

            _context.Classes.Add(classEntity);
            _context.SaveChanges();
        }

        public void Update(Guid classId, Class classEntity)
        {
            var existClass = _context.Classes.Find(classId);
            if (existClass != null)
            {
                var major = _context.Majors.FirstOrDefault(m => m.MajorCode == classEntity.MajorCode);
                if (major == null)
                {
                    throw new Exception($"Major với mã {classEntity.MajorCode} không tồn tại!");
                }

                _context.Entry(existClass).CurrentValues.SetValues(classEntity);
                _context.SaveChanges();
            }
        }

        public void Delete(Guid classId)
        {
            var classEntity = _context.Classes.Find(classId);
            if (classEntity != null)
            {
                _context.Classes.Remove(classEntity);
                _context.SaveChanges();
            }
        }
    }
}