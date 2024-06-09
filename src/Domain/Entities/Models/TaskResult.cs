using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_IMS.src.Domain.Entities.Models
{
    public class TaskResult
    {
        public int Id { get; set; }
        public bool IsDone { get; set; }
        public Intern Intern { get; set; } = null!;
        public Task Task { get; set; } = null!;
    }
}