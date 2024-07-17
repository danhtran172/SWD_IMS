using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.Query.Internal;
using SWD_IMS.src.Application.DTO.UserDTOs;
using SWD_IMS.src.Domain.Entities.Models;
using SWD_IMS.src.Domain.RepositoryContracts;
using SWD_IMS.src.Infrastructure.Context;

namespace SWD_IMS.src.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ITrainingProgramRepository _trainingProgramRepository;
        private readonly SwdImsContext _context;
        public UserRepository(SwdImsContext context, ITrainingProgramRepository trainingProgramRepository)
        {
            _context = context;
            _trainingProgramRepository = trainingProgramRepository;
        }

        public async Task<bool> CheckEmailExist(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user != null;
        }

        public async Task<bool> CreateUser(User user)
        {
            _context.Users.Add(user);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteUser(User user)
        {
            _context.Users.Remove(user);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var listUsers = await _context.Users
                .Include(x => x.Role)
                .Include(x => x.TrainingPrograms)
                .Include(x => x.JobPositions)
                .ToListAsync();
            return listUsers;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email) ?? throw new Exception("User not found");
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserId == id) ?? throw new Exception("User not found");
        }

        public async Task<UserList> GetUsersByFilter(UserFilterDTO filter)
        {
            var query = _context.Users
                .Include(x => x.Role)
                .Include(x => x.TrainingPrograms)
                .Include(x => x.JobPositions)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter.FullName))
            {
                query = query.Where(x => x.FullName.Contains(filter.FullName));
            }

            if (filter.RoleId != null)
            {
                query = query.Where(x => x.RoleId == filter.RoleId);
            }

            var paginationList = await query
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            var userList = new UserList
            {
                Users = paginationList,
                TotalCount = await query.CountAsync()
            };

            return userList;
        }

        public async Task<bool> UpdatePassword(User user, string newPassword)
        {
            var userUpdate = await _context.Users.FindAsync(user.UserId) ?? throw new Exception("User not found");
            userUpdate.Password = newPassword;
            _context.Users.Update(userUpdate);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateUserTrainingPrograms(User user, List<TrainingProgram> trainingPrograms)
        {
            user.TrainingPrograms = trainingPrograms;
            _context.Users.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateUser(User user)
        {
            _context.Users.Update(user);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}