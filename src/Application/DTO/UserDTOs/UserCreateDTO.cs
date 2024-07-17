using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_IMS.src.Application.DTO.UserDTOs
{
    public class UserCreateDTO
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}