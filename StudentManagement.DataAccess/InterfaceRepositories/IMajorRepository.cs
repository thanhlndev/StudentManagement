using System;
using System.Collections.Generic;
using StudentManagement.DataAccess.Entities;

namespace StudentManagement.DataAccess.InterfaceRepositories
{
    public interface IMajorRepository
    {
        IEnumerable<Major> GetAll();
        Major GetByMajorCode(string majorCode);
        void Add(Major major);
        void Update(Guid majorId, Major major);
        void Delete(Guid majorId);
    }
}