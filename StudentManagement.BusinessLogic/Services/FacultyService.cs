using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.DataAccess.Entities;
using StudentManagement.DataAccess.Repositories;
using StudentManagement.BusinessLogic.Interfaces;

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

        public Faculty GetFacultyById(string facultyId)
        {
            return _facultyRepository.GetById(facultyId);
        }

        public void AddFaculty(Faculty faculty)
        {
            // Add business logic/validation if needed
            _facultyRepository.Add(faculty);
        }

        public void UpdateFaculty(Faculty faculty)
        {
            // Add business logic/validation if needed
            _facultyRepository.Update(faculty);
        }

        public void DeleteFaculty(string facultyId)
        {
            // Add business logic/validation if needed
            _facultyRepository.Delete(facultyId);
        }
    }
}
