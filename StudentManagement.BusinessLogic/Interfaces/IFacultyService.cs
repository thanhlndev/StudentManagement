using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.DataAccess.Entities;
using StudentManagement.DataAccess.Repositories;

namespace StudentManagement.BusinessLogic.Interfaces
{
    public interface IFacultyService
    {
        IEnumerable<Faculty> GetAllFaculties();
        Faculty GetFacultyById(string facultyId);
        void AddFaculty(Faculty faculty);
        void UpdateFaculty(Faculty faculty);
        void DeleteFaculty(string facultyId);
    }
}
