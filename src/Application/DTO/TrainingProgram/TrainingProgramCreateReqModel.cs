using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SWD_IMS.src.Domain.Entities.Models;

namespace SWD_IMS.src.Application.DTO
{
    public class TrainingProgramCreateReqModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Content { get; set; }
        public int? MentorId { get; set; }

        public List<Domain.Entities.Models.Task>? Tasks { get; set; }
    }
}