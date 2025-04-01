using System;
using System.Collections.Generic;
using System.Linq; // Thêm namespace này cho LINQ
using System.Data.Entity; // Thêm namespace này cho EF6
using StudentManagement.DataAccess.DbContexts;
using StudentManagement.DataAccess.Entities;
using StudentManagement.DataAccess.InterfaceRepositories;

namespace StudentManagement.DataAccess.Repositories
{
    public class MajorRepository : IMajorRepository
    {
        private readonly StudentDbContext _context;

        public MajorRepository(StudentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Major> GetAll()
        {
            return _context.Majors
                .Include(m => m.Faculty)
                .ToList();
        }

        public Major GetByMajorCode(string majorCode)
        {
            return _context.Majors
                .Include(m => m.Faculty)
                .FirstOrDefault(m => m.MajorCode == majorCode);
        }

        public void Add(Major major)
        {
            // Kiểm tra FacultyCode có tồn tại không
            var faculty = _context.Faculties.FirstOrDefault(f => f.FacultyCode == major.FacultyCode);
            if (faculty == null)
            {
                throw new Exception($"Faculty với mã {major.FacultyCode} không tồn tại!");
            }

            _context.Majors.Add(major);
            _context.SaveChanges();
        }

        public void Update(Guid majorId, Major major)
        {
            var existMajor = _context.Majors.Find(majorId);
            if (existMajor != null)
            {
                // Kiểm tra FacultyCode mới
                var faculty = _context.Faculties.FirstOrDefault(f => f.FacultyCode == major.FacultyCode);
                if (faculty == null)
                {
                    throw new Exception($"Faculty với mã {major.FacultyCode} không tồn tại!");
                }

                _context.Entry(existMajor).CurrentValues.SetValues(major);
                _context.SaveChanges();
            }
        }

        public void Delete(Guid majorId)
        {
            var major = _context.Majors.Find(majorId);
            if (major != null)
            {
                _context.Majors.Remove(major);
                _context.SaveChanges();
            }
        }
    }
}