using System;
using System.Collections.Generic;
using StudentManagement.DataAccess.Entities;

namespace StudentManagement.DataAccess.InterfaceRepository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student GetByStudentCode(string studentCode);
        void Add(Student student);
        void Update(Guid studentId, Student student);
        void Delete(Guid studentId);
    }
}