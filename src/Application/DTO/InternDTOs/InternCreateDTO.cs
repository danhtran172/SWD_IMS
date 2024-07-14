using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_IMS.src.Application.DTO.InternDTOs
{
    public class InternCreateDTO
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? University { get; set; }
        public string? Major { get; set; }
        public string? Experience { get; set; }
    }
}