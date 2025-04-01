using System;
using System.Collections.Generic;
using StudentManagement.DataAccess.Entities;

namespace StudentManagement.BusinessLogic.InterfaceServices
{
    public interface IClassService
    {
        IEnumerable<Class> GetAllClasses();
        Class GetByClassCode(string classCode);
        bool ClassExists(string classCode);
        void AddClass(Class classEntity);
        void UpdateClass(Guid classId, Class classEntity);
        void DeleteClass(Guid classId);
    }
}