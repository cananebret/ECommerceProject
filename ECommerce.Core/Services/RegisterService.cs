using ECommerce.Core.Interfaces;
using ECommerce.Domain.Contexts;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly ECommerceContext _context;

        public RegisterService(ECommerceContext context)
        {
            _context = context;
        }

        public ServiceResult AddUser(CreateUserModel model)
        {
            ServiceResult serviceResult = new ServiceResult { StatusCode = HttpStatusCode.OK };

            var register = new User
            {
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                CityName = model.CityName,
                Password = model.Password,
                RePassword = model.RePassword,
                Deleted = false,
                IsActive = true,
            };

            _context.Users.Add(register);
            _context.SaveChanges();

            serviceResult.Message = "Kaydedildi";

            return serviceResult;
        }

        public bool IsEmailExist(string email)
        {
            return _context.Users.Any(i => i.Email == email && !i.Deleted && i.IsActive);
        }
    }
}
