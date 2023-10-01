using ECommerce.Core.Interfaces;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services
{
    public class LoginService : ILoginService
    {
        public LoginService()
        {
            
        }

        public ServiceResult Login(LoginModel model)
        {
            ServiceResult serviceResult = new ServiceResult { StatusCode = HttpStatusCode.OK };


            return serviceResult;
        }
    }
}
