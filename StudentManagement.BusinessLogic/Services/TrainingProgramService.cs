using System;
using System.Collections.Generic;
using StudentManagement.DataAccess.Entities;
using StudentManagement.DataAccess.InterfaceRepositories;
using StudentManagement.BusinessLogic.InterfaceServices;
using StudentManagement.DataAccess.InterfaceRepository;

namespace StudentManagement.BusinessLogic.Services
{
    public class TrainingProgramService : ITrainingProgramService
    {
        private readonly ITrainingProgramRepository _trainingProgramRepository;

        public TrainingProgramService(ITrainingProgramRepository trainingProgramRepository)
        {
            _trainingProgramRepository = trainingProgramRepository;
        }

        public IEnumerable<TrainingProgram> GetAllTrainingPrograms()
        {
            return _trainingProgramRepository.GetAll();
        }

        public TrainingProgram GetByProgramCode(string programCode)
        {
            return _trainingProgramRepository.GetByProgramCode(programCode);
        }

        public bool TrainingProgramExists(string programCode)
        {
            return _trainingProgramRepository.GetByProgramCode(programCode) != null;
        }

        public void AddTrainingProgram(TrainingProgram program)
        {
            _trainingProgramRepository.Add(program);
        }

        public void UpdateTrainingProgram(Guid programId, TrainingProgram program)
        {
            _trainingProgramRepository.Update(programId, program);
        }

        public void DeleteTrainingProgram(Guid programId)
        {
            _trainingProgramRepository.Delete(programId);
        }
    }
}