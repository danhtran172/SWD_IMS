using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SWD_IMS.src.Application.DTO.UserDTOs;
using SWD_IMS.src.Domain.Entities.Models;
using SWD_IMS.src.Domain.RepositoryContracts;
using SWD_IMS.src.Infrastructure.Context;

namespace SWD_IMS.src.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SwdImsContext _context;
        public UserRepository(SwdImsContext context)
        {
            _context = context;
        }

        public Task<bool> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserId == id) ?? throw new Exception("User not found");
        }

        public Task<IEnumerable<User>> GetUsersByFilter(UserFilterDTO filter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}