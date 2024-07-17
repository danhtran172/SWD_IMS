using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SWD_IMS.src.Application.DTO.TrainingProgramDTOs;
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
                .Include(x => x.TrainingProgramInterns)
                .Include(x => x.Tasks)
                .Include(x => x.Feedbacks)
                .ToListAsync();
            return listTrainingPrograms;
        }

        public async Task<TrainingProgram> GetTrainingProgramById(int id)
        {
            return await _context.TrainingPrograms
                .Include(x => x.Mentor)
                .Include(x => x.TrainingProgramInterns)
                .Include(x => x.Tasks)
                .Include(x => x.Feedbacks)
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Training Program not found");
        }

        public async Task<TrainingProgramList> GetTrainingProgramsByFilter(TrainingProgramFilterDTO filter)
        {
            var query = _context.TrainingPrograms
                .Include(x => x.Mentor)
                .Include(x => x.TrainingProgramInterns)
                .Include(x => x.Tasks)
                .Include(x => x.Feedbacks)
                .AsQueryable();
            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(x => x.Name.Contains(filter.Name));
            }
            if (!string.IsNullOrEmpty(filter.Content))
            {
                query = query.Where(x => x.Content != null && x.Content.Contains(filter.Content));
            }
            if (filter.StartDate != null)
            {
                query = query.Where(x => x.StartDate >= filter.StartDate);
            }
            if (filter.Duration != null)
            {
                query = query.Where(x => x.Duration == filter.Duration);
            }
            if (filter.MentorId != null)
            {
                query = query.Where(x => x.MentorId == filter.MentorId);
            }
            var paginationList = await query
            .OrderByDescending(x => x.CreatedAt)
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();
            var trainingProgramList = new TrainingProgramList
            {
                TrainingPrograms = paginationList,
                TotalCount = await query.CountAsync()
            };
            return trainingProgramList;
        }

        public async Task<bool> UpdateTrainingProgram(TrainingProgram trainingProgram)
        {
            trainingProgram.UpdatedAt = DateTime.Now;
            _context.TrainingPrograms.Update(trainingProgram);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}