using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_IMS.src.Application.DTO
{
    public class TrainingProgramUpdateReqModel
    {
        public string? Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Content { get; set; }
    }
}