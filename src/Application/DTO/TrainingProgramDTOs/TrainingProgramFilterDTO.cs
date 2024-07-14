using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_IMS.src.Application.DTO.TrainingProgramDTOs
{
    public class TrainingProgramFilterDTO
    {
        public string? Name { get; set; }
        public string? Content { get; set; }
        public DateOnly? StartDate { get; set; }
        public int? Duration { get; set; }
    }
}