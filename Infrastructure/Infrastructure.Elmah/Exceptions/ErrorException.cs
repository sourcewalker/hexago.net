﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Elmah.Exceptions
{
    public class ErrorException : System.ApplicationException
    {
        public ErrorException(string message) : base($"Error: {message}") { }
    }
}
