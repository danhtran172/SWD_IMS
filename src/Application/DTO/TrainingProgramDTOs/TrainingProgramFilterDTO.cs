using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SWD_IMS.src.Application.DTO.Pagination;

namespace SWD_IMS.src.Application.DTO.TrainingProgramDTOs
{
    public class TrainingProgramFilterDTO : PaginationReq
    {
        public string? Name { get; set; }
        public string? Content { get; set; }
        public DateOnly? StartDate { get; set; }
        public int? Duration { get; set; }
        public int? MentorId { get; set; }
    }
}