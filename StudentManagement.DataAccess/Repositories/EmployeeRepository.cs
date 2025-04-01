using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using StudentManagement.DataAccess.DbContexts;
using StudentManagement.DataAccess.Entities;
using StudentManagement.DataAccess.InterfaceRepositories;

namespace StudentManagement.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly StudentDbContext _context;

        public EmployeeRepository(StudentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetByEmployeeCode(string employeeCode)
        {
            return _context.Employees
                //.Include(f => f.Majors)
                .FirstOrDefault(f => f.EmployeeCode == employeeCode);
        }
        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Update(Guid employeeId, Employee employee)
        {
            var existEmployee = _context.Employees.Find(employeeId);
            if (existEmployee != null)
            {
                _context.Entry(employee).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void Delete(Guid employeeId)
        {
            var employee = _context.Employees.Find(employeeId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }
    }
}

