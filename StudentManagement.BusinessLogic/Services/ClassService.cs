using System;
using System.Collections.Generic;
using StudentManagement.DataAccess.Entities;
using StudentManagement.DataAccess.InterfaceRepositories;
using StudentManagement.BusinessLogic.InterfaceServices;

namespace StudentManagement.BusinessLogic.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public IEnumerable<Class> GetAllClasses()
        {
            return _classRepository.GetAll();
        }

        public Class GetByClassCode(string classCode)
        {
            return _classRepository.GetByClassCode(classCode);
        }

        public bool ClassExists(string classCode)
        {
            return _classRepository.GetByClassCode(classCode) != null;
        }

        public void AddClass(Class classEntity)
        {
            _classRepository.Add(classEntity);
        }

        public void UpdateClass(Guid classId, Class classEntity)
        {
            _classRepository.Update(classId, classEntity);
        }

        public void DeleteClass(Guid classId)
        {
            _classRepository.Delete(classId);
        }
    }
}