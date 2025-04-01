using System;
using System.Collections.Generic;
using StudentManagement.DataAccess.Entities;
using StudentManagement.DataAccess.Repositories;
using StudentManagement.BusinessLogic.InterfaceServices;

namespace StudentManagement.BusinessLogic.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly IFacultyRepository _facultyRepository;

        public FacultyService(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }

        public IEnumerable<Faculty> GetAllFaculties()
        {
            return _facultyRepository.GetAll();
        }

        public Faculty GetFacultyByFacultyCode(string facultyCode)
        {
            return _facultyRepository.GetByFacultyCode(facultyCode);
        }
        public bool FacultyExists(string facultyCode)
        {
            return _facultyRepository.GetByFacultyCode(facultyCode) != null;
        }

        public void AddFaculty(Faculty faculty)
        {
            // Add business logic/validation if needed
            _facultyRepository.Add(faculty);
        }

        public void UpdateFaculty(Guid facultyId, Faculty faculty)
        {
            // Add business logic/validation if needed
            _facultyRepository.Update(facultyId, faculty);
        }

        public void DeleteFaculty(Guid facultyId)
        {
            // Add business logic/validation if needed
            _facultyRepository.Delete(facultyId);
        }
    }
}
