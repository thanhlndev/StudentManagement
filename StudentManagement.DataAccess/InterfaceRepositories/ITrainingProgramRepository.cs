using System;
using System.Collections.Generic;
using StudentManagement.DataAccess.Entities;

namespace StudentManagement.DataAccess.InterfaceRepository
{
    public interface ITrainingProgramRepository
    {
        IEnumerable<TrainingProgram> GetAll();
        TrainingProgram GetByProgramCode(string programCode);
        void Add(TrainingProgram program);
        void Update(Guid programId, TrainingProgram program);
        void Delete(Guid programId);
    }
}