using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SWD_IMS.src.Domain.Entities.Models;

namespace SWD_IMS.src.Application.DTO.RoleDTOs
{
    public class RoleDTO
    {
        public int RoleId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDTO>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}