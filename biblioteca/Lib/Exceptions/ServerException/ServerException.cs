using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace biblioteca.Lib.Exceptions
{
    public abstract class ServerException : Exception
    {
        public ServerException(string message, Exception e)
            : base(message, e)
        { }
    }
}
