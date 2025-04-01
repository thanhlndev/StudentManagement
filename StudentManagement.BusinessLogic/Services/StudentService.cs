using System;
using System.Collections.Generic;
using StudentManagement.DataAccess.Entities;
using StudentManagement.DataAccess.InterfaceRepository;
using StudentManagement.BusinessLogic.InterfaceServices;

namespace StudentManagement.BusinessLogic.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        public Student GetByStudentCode(string studentCode)
        {
            return _studentRepository.GetByStudentCode(studentCode);
        }

        public bool StudentExists(string studentCode)
        {
            return _studentRepository.GetByStudentCode(studentCode) != null;
        }

        public void AddStudent(Student student)
        {
            _studentRepository.Add(student);
        }

        public void UpdateStudent(Guid studentId, Student student)
        {
            _studentRepository.Update(studentId, student);
        }

        public void DeleteStudent(Guid studentId)
        {
            _studentRepository.Delete(studentId);
        }
    }
}