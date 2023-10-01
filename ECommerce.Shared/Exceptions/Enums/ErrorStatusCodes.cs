using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Exceptions.Enums
{
    public class ErrorStatusCodes
    {
        public const string UnAuthorized = "UnAuthorized";
        public const string BadRequest = "BadRequest";
        public const string Forbidden = "Forbidden";
        public const string NotAcceptable = "NotAcceptable";
        public const string NotFound = "NotFound";
        public const string Found = "Found";
        public const string TooManyRequest = "TooManyRequest";
        public const string InternalServerError = "InternalServerError";
    }
}
