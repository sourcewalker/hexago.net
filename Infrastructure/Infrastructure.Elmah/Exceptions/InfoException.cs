using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Elmah.Exceptions
{
    public class InfoException : System.ApplicationException
    {
        public InfoException(string message) : base($"Info: {message}") { }
    }
}
