using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SWD_IMS.Entities.DTO
{
    public class ResponseDTO<T>
    {
        public int StatusCode { get; set; } = 200;
        public string? Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } = true;
        public ResultDTO<T>? Result { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
