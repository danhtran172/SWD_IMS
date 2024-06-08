using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_IMS.src.Domain.Entities.Models
{
    public class Intern
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? University { get; set; }
        public string? Major { get; set; }
        public string? Experience { get; set; }

        public User Mentor { get; set; } = null!;
        public List<WorkResult> WorkResults { get; set; } = null!;
    }
}