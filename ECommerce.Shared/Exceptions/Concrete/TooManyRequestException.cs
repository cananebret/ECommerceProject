using ECommerce.Shared.Exceptions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Exceptions.Concrete
{
    public class TooManyRequestException : ApiExceptionBase
    {
        public TooManyRequestException()
       : base()
        {
            Errors = new Error[] { new Error { Code = ErrorStatusCodes.TooManyRequest, Message = "İstek Limiti Aşıldı.", Data = null } };
        }

        public TooManyRequestException(String message)
            : base(message)

        {
            Errors = new Error[] { new Error { Code = ErrorStatusCodes.TooManyRequest, Message = message, Data = null } };
        }

        public TooManyRequestException(string code, string message, object data = null) : base(code, message, data)
        {
            Errors = new Error[] { new Error { Code = code, Message = message, Data = data } };
        }

        public TooManyRequestException(String message, Exception innerException)
            : base(message, innerException)
        {

            Errors = new Error[] { new Error { Code = ErrorStatusCodes.TooManyRequest, Message = $"{message} - Inner Ex : {innerException}", Data = null } };
        }

        public TooManyRequestException(string message, object data = null) : base(message, data)
        {
            Errors = new Error[] { new Error { Code = ErrorStatusCodes.TooManyRequest, Message = message, Data = data } };
        }

        protected override HttpStatusCode HttpStatusCode => HttpStatusCode.TooManyRequests;
    }
}
