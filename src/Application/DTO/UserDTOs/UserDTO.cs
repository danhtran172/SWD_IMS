using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SWD_IMS.src.Application.DTO.Pagination;

namespace SWD_IMS.src.Application.DTO.UserDTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int RoleId { get; set; }
    }
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Domain.Entities.Models.User, UserDTO>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}