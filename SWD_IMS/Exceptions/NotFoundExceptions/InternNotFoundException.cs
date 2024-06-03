using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_IMS.Exceptions.NotFoundExceptions
{
    public sealed class InternNotFoundException : Exception
    {
        public InternNotFoundException(string internName) : base($"Intern with name: {internName} cannot be found") { }
    }
}
