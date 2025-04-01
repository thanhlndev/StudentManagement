using System;
using System.Collections.Generic;
using StudentManagement.DataAccess.Entities;

namespace StudentManagement.BusinessLogic.InterfaceServices
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();
        Student GetByStudentCode(string studentCode);
        bool StudentExists(string studentCode);
        void AddStudent(Student student);
        void UpdateStudent(Guid studentId, Student student);
        void DeleteStudent(Guid studentId);
    }
}