using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SWD_IMS.src.Application.DTO.UserDTOs;
using SWD_IMS.src.Domain.Entities.Models;

namespace SWD_IMS.src.Domain.RepositoryContracts
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<bool> CreateUser(User user);
        public Task<bool> UpdateUser(User user);
        public Task<bool> DeleteUser(User user);
        public Task<User> GetUserByEmail(string email);
        public Task<User> GetUserById(int id);
        public Task<IEnumerable<User>> GetUsersByFilter(UserFilterDTO filter);
        
    }
}