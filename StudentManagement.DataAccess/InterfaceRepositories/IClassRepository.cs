using System;
using System.Collections.Generic;
using StudentManagement.DataAccess.Entities;

namespace StudentManagement.DataAccess.InterfaceRepositories
{
    public interface IClassRepository
    {
        IEnumerable<Class> GetAll();
        Class GetByClassCode(string classCode);
        void Add(Class classEntity);
        void Update(Guid classId, Class classEntity);
        void Delete(Guid classId);
    }
}