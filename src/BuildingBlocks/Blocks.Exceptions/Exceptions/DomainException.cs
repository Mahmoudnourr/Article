using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocks.Exceptions.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message, Exception? innerException=null) : base(message, innerException)
        {

        }
    }
}
