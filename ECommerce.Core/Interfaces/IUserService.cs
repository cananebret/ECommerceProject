using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Interfaces
{
    public interface IUserService
    {
        ServiceResult Login(LoginModel model);
        bool IsUserActive(string email);
        bool IsPasswordCorrect(string email, string password);
    }
}
