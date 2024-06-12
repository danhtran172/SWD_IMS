using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SWD_IMS.src.Domain.Entities.Models;
using SWD_IMS.src.Domain.RepositoryContracts;
using SWD_IMS.src.Infrastructure.Context;

namespace SWD_IMS.src.Infrastructure.Repository
{
    public class TrainingProgramRepository : ITrainingProgramRepository
    {
        private readonly SwdImsContext _context;
        public TrainingProgramRepository(SwdImsContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateTrainingProgram(TrainingProgram trainingProgram)
        {
            _context.TrainingPrograms.Add(trainingProgram);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteTrainingProgram(TrainingProgram trainingProgram)
        {
            _context.TrainingPrograms.Remove(trainingProgram);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<IEnumerable<TrainingProgram>> GetAllTrainingPrograms()
        {
            var listTrainingPrograms = await _context.TrainingPrograms
                .Include(x => x.Mentor)
                .Include(x => x.WorkResults)
                .Include(x => x.Tasks)
                .Include(x => x.Feedbacks)
                .ToListAsync();
            return listTrainingPrograms;
        }

        public async Task<TrainingProgram> GetTrainingProgramById(int id)
        {
            return await _context.TrainingPrograms.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Training Program not found");
        }

        public async Task<bool> UpdateTrainingProgram(TrainingProgram trainingProgram)
        {
            _context.TrainingPrograms.Update(trainingProgram);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}