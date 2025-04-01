using System;
using System.Collections.Generic;
using StudentManagement.DataAccess.Entities;

namespace StudentManagement.BusinessLogic.InterfaceServices
{
    public interface IMajorService
    {
        IEnumerable<Major> GetAllMajors();
        Major GetByMajorCode(string majorCode);
        bool MajorExists(string majorCode);
        void AddMajor(Major major);
        void UpdateMajor(Guid majorId, Major major);
        void DeleteMajor(Guid majorId);
    }
}