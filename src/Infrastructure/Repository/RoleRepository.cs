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
    public class RoleRepository : IRoleRepository
    {
        private readonly SwdImsContext _context;
        public RoleRepository(SwdImsContext context)
        {
            _context = context;
        }
        public async Task<Role> GetRoleById(int id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(x => x.RoleId == id) ?? throw new Exception("Role not found");
            return role ;
        }
    }
}