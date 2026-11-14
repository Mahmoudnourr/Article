using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocks.Exceptions.Exceptions
{
    public class NotFoundException : HttpException
    {
        public NotFoundException(string message) : base((int)System.Net.HttpStatusCode.NotFound, message){}
        public NotFoundException(string message, Exception innerException) : base((int)System.Net.HttpStatusCode.NotFound, message, innerException) { }
    }
}
