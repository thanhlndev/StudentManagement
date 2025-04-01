using System;
using System.Collections.Generic;
using StudentManagement.DataAccess.Entities;
using StudentManagement.DataAccess.Repositories;
using StudentManagement.BusinessLogic.InterfaceServices;
using StudentManagement.DataAccess.InterfaceRepositories;

namespace StudentManagement.BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAll();
        }

        public Employee GetByEmployeeCode(string employeeCode)
        {
            return _employeeRepository.GetByEmployeeCode(employeeCode);
        }

        public bool EmployeeExists(string employeeCode)
        {
            return _employeeRepository.GetByEmployeeCode(employeeCode) != null;
        }

        public void AddEmployee(Employee employee)
        {
            _employeeRepository.Add(employee);
        }

        public void UpdateEmployee(Guid employeeId, Employee employee)
        {
            _employeeRepository.Update(employeeId, employee);
        }

        public void DeleteEmployee(Guid employeeId)
        {
            _employeeRepository.Delete(employeeId);
        }
    }
}
