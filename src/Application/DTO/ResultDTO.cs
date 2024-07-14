using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD_IMS.src.Application.DTO.Pagination;

namespace SWD_IMS.Entities.DTO
{
    public class ResultDTO
    {
        public required object Data { get; set; }
        public PageInfo? PageInfo { get; set; }
    }

    public class PageInfo : PaginationResp
    {
        public bool? HasNextPage { get; set; }
    }
}
