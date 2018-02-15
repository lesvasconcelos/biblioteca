using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace biblioteca.Lib.Exceptions
{
    public abstract class ClientException : Exception
    {
        public ClientException(string message) : base(message) { }
    }
}
