using ECommerce.Core.Interfaces;
using ECommerce.Domain.Contexts;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services
{
    public class UserService : IUserService
    {
        private readonly ECommerceContext _context;
        public UserService(ECommerceContext context)
        {
            _context = context;
        }

        public ServiceResult Login(LoginModel model)
        {
            ServiceResult serviceResult = new ServiceResult { StatusCode = HttpStatusCode.OK };

            serviceResult.Data = model.Email;

            serviceResult.Message = "Giriş yapıldı";

            return serviceResult;
        }

        public bool IsUserActive(string email)
        {
            return _context.Users.Any(u => u.Email == email && u.IsActive && !u.Deleted);
        }

        public bool IsPasswordCorrect(string email, string password)
        {
            return _context.Users.Any(u => u.Email == email && u.Password == password && u.IsActive && !u.Deleted);
        }
    }
}
