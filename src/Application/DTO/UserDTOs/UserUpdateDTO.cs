using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SWD_IMS.src.Application.Constant;

namespace SWD_IMS.src.Application.DTO.UserDTOs
{
    public class UserUpdateDTO
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
    public class UpdatePasswordReq
    {
        [Required]
        public string? OldPassword { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Password must be at least 6 characters", MinimumLength = 6)]
        [RegularExpression(RegexConst.PASSWORD, ErrorMessage = "Password must contain at least 1 uppercase letter, 1 lowercase letter and 1 number")]
        public string? NewPassword { get; set; }
    }
}