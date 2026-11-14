using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Blocks.Exceptions.Exceptions
{
    public  class HttpException : Exception
    {
        public HttpStatusCode httpStatusCode { get;}

        public  HttpException(int statusCode, string errorMessage) :
        base (string.IsNullOrEmpty(errorMessage) ? statusCode.ToString() : errorMessage)
        {
            this.httpStatusCode = (HttpStatusCode)statusCode;
        }
        public HttpException(int statusCode, string errorMessage, Exception innerException) :
            base(string.IsNullOrEmpty(errorMessage) ? statusCode.ToString() : errorMessage, innerException)
        {
            this.httpStatusCode = (HttpStatusCode)statusCode;
        }
    }
}
