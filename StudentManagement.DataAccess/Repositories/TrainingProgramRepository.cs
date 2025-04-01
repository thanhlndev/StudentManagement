using System;
using System.Linq;
using System.Data.Entity;
using StudentManagement.DataAccess.DbContexts;
using StudentManagement.DataAccess.Entities;
using StudentManagement.DataAccess.InterfaceRepositories;
using StudentManagement.DataAccess.InterfaceRepository;
using System.Collections.Generic;

namespace StudentManagement.DataAccess.Repositories
{
    public class TrainingProgramRepository : ITrainingProgramRepository
    {
        private readonly StudentDbContext _context;

        public TrainingProgramRepository(StudentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TrainingProgram> GetAll()
        {
            return _context.TrainingPrograms.ToList();
        }

        public TrainingProgram GetByProgramCode(string programCode)
        {
            return _context.TrainingPrograms.FirstOrDefault(p => p.ProgramCode == programCode);
        }

        public void Add(TrainingProgram program)
        {
            _context.TrainingPrograms.Add(program);
            _context.SaveChanges();
        }

        public void Update(Guid programId, TrainingProgram program)
        {
            var existProgram = _context.TrainingPrograms.Find(programId);
            if (existProgram != null)
            {
                _context.Entry(existProgram).CurrentValues.SetValues(program);
                _context.SaveChanges();
            }
        }

        public void Delete(Guid programId)
        {
            var program = _context.TrainingPrograms.Find(programId);
            if (program != null)
            {
                _context.TrainingPrograms.Remove(program);
                _context.SaveChanges();
            }
        }
    }
}