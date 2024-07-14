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
    public class InternRepository : IInternRepository
    {
        private readonly SwdImsContext _context;
        public InternRepository(SwdImsContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateIntern(Intern intern)
        {
            _context.Interns.Add(intern);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteIntern(Intern intern)
        {
            _context.Interns.Remove(intern);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<IEnumerable<Intern>> GetAllInterns()
        {
            var listInterns = await _context.Interns
                .Include(x => x.Feedbacks)
                .Include(x => x.TrainingProgramInterns)
                .Include(x => x.TaskInterns)
                .ToListAsync();
            return listInterns;
        }

        public async Task<Intern> GetInternById(int id)
        {
            return await _context.Interns
                .Include(x => x.Feedbacks)
                .Include(x => x.TrainingProgramInterns)
                .Include(x => x.TaskInterns)
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Intern not found");
        }

        public async Task<bool> UpdateIntern(Intern intern)
        {
            _context.Interns.Update(intern);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}