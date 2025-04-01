using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.DataAccess.Entities;

namespace StudentManagement.DataAccess.InterfaceRepositories
{
    public interface IEmployeeRepository
    {

        IEnumerable<Employee> GetAll();
        Employee GetByEmployeeCode(string employeeCode);
        void Add(Employee employee);
        void Update(Guid employeeId, Employee employee);
        void Delete(Guid employeeId);
    }
}

