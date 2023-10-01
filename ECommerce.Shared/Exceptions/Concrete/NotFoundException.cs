using ECommerce.Shared.Exceptions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Exceptions.Concrete
{
    public class NotFoundException : ApiExceptionBase
    {
        public NotFoundException()
      : base()
        {
            Errors = new Error[] { new Error { Code = ErrorStatusCodes.NotFound, Message = "Kayıt Bulunamadı", Data = null } };
        }

        public NotFoundException(String message)
            : base(message)

        {
            Errors = new Error[] { new Error { Code = ErrorStatusCodes.NotFound, Message = message, Data = null } };
        }

        public NotFoundException(string code, string message, object data = null) : base(code, message, data)
        {
            Errors = new Error[] { new Error { Code = code, Message = message, Data = data } };
        }


        public NotFoundException(String message, Exception innerException)
            : base(message, innerException)
        {

            Errors = new Error[] { new Error { Code = ErrorStatusCodes.NotFound, Message = $"{message} - Inner Ex : {innerException}", Data = null } };
        }

        public NotFoundException(string message, object data = null) : base(message, data)
        {
            Errors = new Error[] { new Error { Code = ErrorStatusCodes.NotFound, Message = message, Data = data } };
        }

        public NotFoundException(Error error)
        {
            Errors = new Error[] { error };
        }

        public NotFoundException(Error error, object data = null)
        {
            Errors = new Error[] { new Error { Code = error.Code, Message = error.Message, Data = data } };
        }

        public NotFoundException(Error error, String extraMessage)
        {
            Errors = new Error[] { error, new Error { Code = ErrorStatusCodes.NotFound, Message = extraMessage } };
        }


        protected override HttpStatusCode HttpStatusCode => HttpStatusCode.NotFound;
    }
}
