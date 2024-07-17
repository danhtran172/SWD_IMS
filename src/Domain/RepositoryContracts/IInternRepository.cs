using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SWD_IMS.src.Application.DTO.InternDTOs;
using SWD_IMS.src.Domain.Entities.Models;

namespace SWD_IMS.src.Domain.RepositoryContracts
{
    public interface IInternRepository
    {
        public Task<Intern> GetInternById(int id);
        public Task<IEnumerable<Intern>> GetAllInterns();
        public Task<bool> CreateIntern(Intern intern);
        public Task<bool> UpdateIntern(Intern intern);
        public Task<bool> DeleteIntern(Intern intern);
        public Task<InternList> GetInternsByFilter(InternFilterDTO internFilter);
        public Task<Intern> GetInternByEmail(string email);
    }
}