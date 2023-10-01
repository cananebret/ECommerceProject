using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Interfaces
{
    public interface IRegisterService
    {
        ServiceResult AddUser(CreateUserModel model);
        bool IsEmailExist(string email);
    }
}
