using System;
using System.Collections.Generic;
using StudentManagement.DataAccess.Entities;

namespace StudentManagement.BusinessLogic.InterfaceServices
{
    public interface ITrainingProgramService
    {
        IEnumerable<TrainingProgram> GetAllTrainingPrograms();
        TrainingProgram GetByProgramCode(string programCode);
        bool TrainingProgramExists(string programCode);
        void AddTrainingProgram(TrainingProgram program);
        void UpdateTrainingProgram(Guid programId, TrainingProgram program);
        void DeleteTrainingProgram(Guid programId);
    }
}