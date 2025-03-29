using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.DataAccess.Entities;

namespace StudentManagement.DataAccess.Repositories
{
    public interface IFacultyRepository
    {
        IEnumerable<Faculty> GetAll();
        Faculty GetById(string facultyId);
        void Add(Faculty faculty);
        void Update(Faculty faculty);
        void Delete(string facultyId);
    }
}