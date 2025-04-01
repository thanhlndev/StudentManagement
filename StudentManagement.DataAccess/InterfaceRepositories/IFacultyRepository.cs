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
        Faculty GetByFacultyCode(string facultyCode);
        void Add(Faculty faculty);
        void Update(Guid facultyId,Faculty faculty);
        void Delete(Guid facultyId);
    }
}