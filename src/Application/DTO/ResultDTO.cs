using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_IMS.Entities.DTO
{
    public class ResultDTO
    {
        public required object Data { get; set; }
        public int? Total { get; set; }
        public PageInfo? PageInfo { get; set; }
    }

    public class PageInfo
    {
        public bool? HasNextPage { get; set; }
        public bool? HasPreviousPage { get; set; }
    }
}
