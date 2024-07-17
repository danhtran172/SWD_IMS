using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using SWD_IMS.Entities.DTO;
using SWD_IMS.src.Application.DTO.UserDTOs;

namespace SWD_IMS.src.Domain.ServiceContracts
{
    public interface IUserService
    {
        public Task<ResponseDTO> GetAllUsers();
        public Task<ResponseDTO> GetUserById(int id);
        public Task<ResponseDTO> CreateUser(UserCreateDTO user);
        public Task<ResponseDTO> UpdateUser(UserUpdateDTO user, int id);
        public Task<ResponseDTO> DeleteUser(int id);
        public Task<ResponseDTO> GetUsersByFilter(UserFilterDTO filter);
        public Task<ResponseDTO> UpdatePassword(int id, UpdatePasswordReq req);
        public Task<ResponseDTO> GetUserByEmail(string email);
        public Task<ResponseDTO> UpdateUserTrainingPrograms(int id, List<int> trainingProgramIds);
    }
}