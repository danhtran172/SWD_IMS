using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_IMS.Entities.DTO
{
    public class ResultDTO<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int? Total { get; set; }
        public PageInfo PageInfo { get; set; }

        public ResultDTO()
        {
            Data = new List<T>();
        }
    }

    public class PageInfo
    {
        public bool? HasNextPage { get; set; }
        public bool? HasPreviousPage { get; set; }
    }
}
