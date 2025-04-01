using System;
using System.Collections.Generic;
using StudentManagement.DataAccess.Entities;

namespace StudentManagement.BusinessLogic.InterfaceServices
{
    public interface IFacultyService
    {
        IEnumerable<Faculty> GetAllFaculties();
        Faculty GetFacultyByFacultyCode(string facultyCode);
        bool FacultyExists(string facultyCode);
        void AddFaculty(Faculty faculty);
        void UpdateFaculty(Guid facultyId, Faculty faculty);
        void DeleteFaculty(Guid facultyId);
    }
}
