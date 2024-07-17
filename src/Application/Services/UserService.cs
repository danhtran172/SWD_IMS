using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SWD_IMS.Entities.DTO;
using SWD_IMS.src.Application.Constant;
using SWD_IMS.src.Application.DTO.UserDTOs;
using SWD_IMS.src.Domain.Entities.Models;
using SWD_IMS.src.Domain.RepositoryContracts;
using SWD_IMS.src.Domain.ServiceContracts;

namespace SWD_IMS.src.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ITrainingProgramRepository _trainingProgramRepository;
        private readonly IRoleRepository _roleRepository;
        public UserService(IUserRepository userRepository, IMapper mapper, ITrainingProgramRepository trainingProgramRepository, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _trainingProgramRepository = trainingProgramRepository;
            _roleRepository = roleRepository;
        }
        public async Task<ResponseDTO> CreateUser(UserCreateDTO req)
        {
            var response = new ResponseDTO();
            try
            {
                if (await _userRepository.CheckEmailExist(req.Email))
                {
                    response.StatusCode = 400;
                    response.Message = "Email already exists";
                    response.IsSuccess = false;
                    return response;
                }
                var mappedUser = _mapper.Map<User>(req);
                mappedUser.RoleId = RoleConst.GetRoleId(RoleConst.MEMBER);
                mappedUser.Role = await _roleRepository.GetRoleById(mappedUser.RoleId);
                // mappedUser.Role = RoleConst.MEMBER;
                var result = await _userRepository.CreateUser(mappedUser);
                if (!result)
                {
                    response.StatusCode = 400;
                    response.Message = "User creation failed";
                    response.IsSuccess = false;
                    return response;
                }
                else
                {
                    response.StatusCode = 201;
                    response.Message = "User created successfully";
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch
            {
                throw;
            }

        }

        public async Task<ResponseDTO> DeleteUser(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var user = await _userRepository.GetUserById(id);
                var result = await _userRepository.DeleteUser(user);
                if (!result)
                {
                    response.StatusCode = 400;
                    response.Message = "User deletion failed";
                    response.IsSuccess = false;
                    return response;
                }
                else
                {
                    response.StatusCode = 200;
                    response.Message = "User deleted successfully";
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseDTO> GetAllUsers()
        {
            var response = new ResponseDTO();
            try
            {
                var users = await _userRepository.GetAllUsers();
                var mappedUsers = _mapper.Map<IEnumerable<UserDTO>>(users);
                if (mappedUsers != null)
                {
                    response.StatusCode = 200;
                    response.Message = "Users fetched successfully";
                    response.IsSuccess = true;
                    response.Result = new ResultDTO
                    {
                        Data = mappedUsers,
                        PageInfo = new PageInfo
                        {
                            Total = mappedUsers.Count()
                        }
                    };
                    return response;
                }
                else
                {
                    response.StatusCode = 400;
                    response.Message = "Users fetched faild";
                    response.IsSuccess = false;
                    return response;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseDTO> GetUserByEmail(string email)
        {
            var response = new ResponseDTO();
            try
            {
                var user = await _userRepository.GetUserByEmail(email);
                var mappedUser = _mapper.Map<UserDTO>(user);
                if (mappedUser != null)
                {
                    response.StatusCode = 200;
                    response.Message = "User fetched successfully";
                    response.IsSuccess = true;
                    response.Result = new ResultDTO
                    {
                        Data = mappedUser,
                        PageInfo = new PageInfo
                        {
                            Total = 1
                        }
                    };
                    return response;
                }
                else
                {
                    response.StatusCode = 400;
                    response.Message = "User fetched faild";
                    response.IsSuccess = false;
                    return response;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseDTO> GetUserById(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var user = await _userRepository.GetUserById(id);
                var mappedUser = _mapper.Map<UserDTO>(user);
                if (mappedUser != null)
                {
                    response.StatusCode = 200;
                    response.Message = "User fetched successfully";
                    response.IsSuccess = true;
                    response.Result = new ResultDTO
                    {
                        Data = mappedUser,
                        PageInfo = new PageInfo
                        {
                            Total = 1
                        }
                    };
                    return response;
                }
                else
                {
                    response.StatusCode = 400;
                    response.Message = "User fetched faild";
                    response.IsSuccess = false;
                    return response;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseDTO> GetUsersByFilter(UserFilterDTO filter)
        {
            var response = new ResponseDTO();
            try
            {
                var users = await _userRepository.GetUsersByFilter(filter);
                var mappedUsers = _mapper.Map<IEnumerable<UserDTO>>(users.Users);
                if (mappedUsers != null)
                {
                    response.StatusCode = 200;
                    response.Message = "Users fetched successfully";
                    response.IsSuccess = true;
                    response.Result = new ResultDTO
                    {
                        Data = mappedUsers,
                        PageInfo = new PageInfo
                        {
                            Total = mappedUsers.Count()
                        }
                    };
                    return response;
                }
                else
                {
                    response.StatusCode = 400;
                    response.Message = "Users fetched faild";
                    response.IsSuccess = false;
                    return response;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseDTO> UpdatePassword(int id, UpdatePasswordReq req)
        {
            var response = new ResponseDTO();
            try
            {
                var user = await _userRepository.GetUserById(id);
                if (user.Password != req.OldPassword)
                {
                    response.StatusCode = 400;
                    response.Message = "Old password is incorrect";
                    response.IsSuccess = false;
                    return response;
                }
                if (user.Password == req.NewPassword)
                {
                    response.StatusCode = 400;
                    response.Message = "New password must be different from old password";
                    response.IsSuccess = false;
                    return response;
                }
                if(req.NewPassword == null)
                {
                    response.StatusCode = 400;
                    response.Message = "New password is required";
                    response.IsSuccess = false;
                    return response;
                }
                var result = await _userRepository.UpdatePassword(user, req.NewPassword);
                if (!result)
                {
                    response.StatusCode = 400;
                    response.Message = "Password update failed";
                    response.IsSuccess = false;
                    return response;
                }
                else
                {
                    response.StatusCode = 200;
                    response.Message = "Password updated successfully";
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch
            {
                throw;
            }
        }

    public async Task<ResponseDTO> UpdateUserTrainingPrograms(int id, List<int> trainingProgramIds)
    {
        var response = new ResponseDTO();
        try
        {
            var userToUpdate = _userRepository.GetUserById(id).Result;
            List<TrainingProgram> trainingPrograms = new List<TrainingProgram>();
            if (trainingProgramIds != null && trainingProgramIds.Any())
            {
                foreach (var tId in trainingProgramIds)
                {
                    var program = _trainingProgramRepository.GetTrainingProgramById(id).Result;
                    if (program != null)
                    {
                        trainingPrograms.Add(program);
                    }
                }
            }
            var result = await _userRepository.UpdateUserTrainingPrograms(userToUpdate, trainingPrograms);
            if (!result)
            {
                response.StatusCode = 400;
                response.Message = "User training programs update failed";
                response.IsSuccess = false;
                return response;
            }
            else
            {
                response.StatusCode = 200;
                response.Message = "User training programs updated successfully";
                response.IsSuccess = true;
                return response;
            }

        }
        catch
        {
            throw;
        }
    }


    public async Task<ResponseDTO> UpdateUser(UserUpdateDTO user, int id)
    {
        var response = new ResponseDTO();
        try
        {
            var userToUpdate = await _userRepository.GetUserById(id);
            var mappedUser = _mapper.Map(user, userToUpdate);
            var result = await _userRepository.UpdateUser(mappedUser);
            if (!result)
            {
                response.StatusCode = 400;
                response.Message = "User update failed";
                response.IsSuccess = false;
                return response;
            }
            else
            {
                response.StatusCode = 200;
                response.Message = "User updated successfully";
                response.IsSuccess = true;
                return response;
            }
        }
        catch
        {
            throw;
        }
    }
}
}