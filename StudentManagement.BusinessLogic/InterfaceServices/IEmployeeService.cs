using System;
using System.Collections.Generic;
using StudentManagement.DataAccess.Entities;

namespace StudentManagement.BusinessLogic.InterfaceServices
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetByEmployeeCode(string employeeCode);
        bool EmployeeExists(string employeeCode);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Guid employeeId, Employee employee);
        void DeleteEmployee(Guid employeeId);
    }
}
