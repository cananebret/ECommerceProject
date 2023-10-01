using ECommerce.Shared.Exceptions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Exceptions.Concrete
{
    public class BadRequestException : ApiExceptionBase
    {
        public BadRequestException()
      : base()
        {
            Errors = new Error[] { new Error { Code = ErrorStatusCodes.BadRequest, Message = "Geçersiz istek. Kriterlerinizi kontrol ediniz", Data = null } };
        }

        public BadRequestException(String message)
            : base(message)

        {
            Errors = new Error[] { new Error { Code = ErrorStatusCodes.BadRequest, Message = message, Data = null } };
        }

        public BadRequestException(string code, string message, object data = null) : base(code, message, data)
        {
            Errors = new Error[] { new Error { Code = code, Message = message, Data = data } };
        }


        public BadRequestException(String message, Exception innerException)
            : base(message, innerException)
        {

            Errors = new Error[] { new Error { Code = ErrorStatusCodes.BadRequest, Message = $"{message} - Inner Ex : {innerException}", Data = null } };
        }

        public BadRequestException(string message, object data = null) : base(message, data)
        {
            Errors = new Error[] { new Error { Code = ErrorStatusCodes.BadRequest, Message = message, Data = data } };
        }

        public BadRequestException(Error error)
        {
            Errors = new Error[] { error };
        }

        public BadRequestException(Error error, object data = null)
        {
            Errors = new Error[] { new Error { Code = error.Code, Message = error.Message, Data = data } };
        }

        public BadRequestException(Error error, String extraMessage)
        {
            Errors = new Error[] { error, new Error { Code = ErrorStatusCodes.BadRequest, Message = extraMessage } };
        }


        protected override HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;
    }
}
