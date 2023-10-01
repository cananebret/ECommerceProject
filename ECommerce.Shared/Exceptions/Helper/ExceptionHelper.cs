using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Exceptions.Helper
{
    public static class ExceptionHelper
    {
        public static string GetException(Exception ex, string newLine = "<br/>")
        {
            string returnValue = "";
            if (ex != null)
            {
                returnValue += newLine + "Message : " + ex.Message.ToString();
                returnValue += newLine + "Source : " + ex.Source;
                returnValue += newLine + "StackTrace : " + ex.StackTrace;
                if (ex.InnerException != null)
                {
                    returnValue += newLine + "InnerException Message : " + ex.InnerException.Message;
                    returnValue += newLine + "InnerException Source : " + ex.InnerException.Source;
                    returnValue += newLine + "InnerException StackTrace : " + ex.InnerException.StackTrace;
                }
            }
            return returnValue;
        }
        public static ServiceReturnModel CreateReturnModel(this ServiceResult serviceResult)
        {
            return new ServiceReturnModel
            {
                Data = serviceResult.Data,
                Exceptions = serviceResult.Exceptions,
                Message = serviceResult.Message
            };
        }

        public static string ExceptionMessage(Exception ex)
        {
            if (ex.InnerException != null)
            {
                return ex.Message.ToString() + " -> " + ExceptionMessage(ex.InnerException);
            }
            return ex.Message.ToString();
        }
    }
}
