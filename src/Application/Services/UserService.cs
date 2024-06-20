using AutoMapper;
using SWD_IMS.Entities.DTO;
using SWD_IMS.src.Domain.RepositoryContracts;
using SWD_IMS.src.Domain.ServiceContracts;
using SWD_IMS.src.Infrastructure.Repository;
using System.Security.Cryptography;

namespace SWD_IMS.src.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDTO> Login(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                return new ResponseDTO { IsSuccess = false, Message = "Invalid Username" };
            }


            if (BCrypt.Net.BCrypt.EnhancedVerify(password, BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password,12)))
            {
                return new ResponseDTO { IsSuccess = true, Message = "Valid user" };
            }
            else
            {
                return new ResponseDTO { IsSuccess = false, Message = "Invalid Password" };
            }
        }
    }
}
