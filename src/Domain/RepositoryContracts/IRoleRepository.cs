using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SWD_IMS.src.Domain.Entities.Models;

namespace SWD_IMS.src.Domain.RepositoryContracts
{
    public interface IRoleRepository
    {
        public Task<Role> GetRoleById(int id);
    }
}