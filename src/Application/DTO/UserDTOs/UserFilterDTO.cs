using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SWD_IMS.src.Application.DTO.Pagination;

namespace SWD_IMS.src.Application.DTO.UserDTOs
{
    public class UserFilterDTO : PaginationReq
    {
        public string? FullName { get; set; }
        public int? RoleId { get; set; }
    }
}