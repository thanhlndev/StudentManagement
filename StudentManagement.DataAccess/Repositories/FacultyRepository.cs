using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.DataAccess.DbContexts;
using StudentManagement.DataAccess.Entities;

namespace StudentManagement.DataAccess.Repositories
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly StudentDbContext _context;

        public FacultyRepository(StudentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Faculty> GetAll()
        {
            return _context.Faculties.Include(f => f.Majors).ToList();
        }

        public Faculty GetById(string facultyId)
        {
            return _context.Faculties.Include(f => f.Majors)
                .FirstOrDefault(f => f.FacultyID == facultyId);
        }

        public void Add(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
            _context.SaveChanges();
        }

        public void Update(Faculty faculty)
        {
            _context.Entry(faculty).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(string facultyId)
        {
            var faculty = _context.Faculties.Find(facultyId);
            if (faculty != null)
            {
                _context.Faculties.Remove(faculty);
                _context.SaveChanges();
            }
        }
    }
}
