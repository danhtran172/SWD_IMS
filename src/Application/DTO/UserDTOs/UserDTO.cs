using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SWD_IMS.src.Application.DTO.Pagination;
using SWD_IMS.src.Application.DTO.RoleDTOs;
using SWD_IMS.src.Application.DTO.TrainingProgramDTOs;
using SWD_IMS.src.Domain.Entities.Models;

namespace SWD_IMS.src.Application.DTO.UserDTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public RoleDTO Role { get; set; } = null!;
    }
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UserCreateDTO, User>()
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.Role, opt => opt.Ignore())
            .ForMember(dest => dest.TrainingPrograms, opt => opt.Ignore())
            .ForMember(dest => dest.JobPositions, opt => opt.Ignore())
            .ForMember(dest => dest.RoleId, opt => opt.Ignore())
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UserUpdateDTO, User>()
            .ForMember(dest => dest.Role, opt => opt.Ignore())
            .ForMember(dest => dest.TrainingPrograms, opt => opt.Ignore())
            .ForMember(dest => dest.JobPositions, opt => opt.Ignore())
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }

    }
}