using ECommerce.Shared.Exceptions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Exceptions.Concrete
{
    public class NotAcceptableException : ApiExceptionBase
    {
        public NotAcceptableException()
 : base()
        {
            Errors = new Error[] { new Error { Code = ErrorStatusCodes.NotAcceptable, Message = "Geçersiz istek. Kriterlerinizi kontrol ediniz", Data = null } };
        }

        public NotAcceptableException(String message)
            : base(message)

        {
            Errors = new Error[] { new Error { Code = ErrorStatusCodes.NotAcceptable, Message = message, Data = null } };
        }
        public NotAcceptableException(Error[] errors)
            : base(errors)

        {
            Errors = errors;
        }

        public NotAcceptableException(string code, string message, object data = null) : base(code, message, data)
        {
            Errors = new Error[] { new Error { Code = code, Message = message, Data = data } };
        }

        public NotAcceptableException(String message, Exception innerException)
            : base(message, innerException)
        {

            Errors = new Error[] { new Error { Code = ErrorStatusCodes.NotAcceptable, Message = $"{message} - Inner Ex : {innerException}", Data = null } };
        }

        public NotAcceptableException(string message, object data = null) : base(message, data)
        {
            Errors = new Error[] { new Error { Code = ErrorStatusCodes.NotAcceptable, Message = message, Data = data } };
        }

        public NotAcceptableException(Error error)
        {
            Errors = new Error[] { error };
        }

        public NotAcceptableException(Error error, object data = null)
        {
            Errors = new Error[] { new Error { Code = error.Code, Message = error.Message, Data = data } };
        }

        protected override HttpStatusCode HttpStatusCode => HttpStatusCode.NotAcceptable;

    }
}
