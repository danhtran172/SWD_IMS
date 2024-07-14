using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SWD_IMS.src.Application.DTO.Pagination;

namespace SWD_IMS.src.Application.DTO.InternDTOs
{
    public class InternFilterDTO : PaginationReq
    {
        public string? University { get; set; }
        public string? Major { get; set; }
        public string? Experience { get; set; }
    }
}