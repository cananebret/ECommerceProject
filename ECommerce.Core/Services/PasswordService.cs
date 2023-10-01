using ECommerce.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ECommerce.Core.Services
{
    public class PasswordService : IPasswordService
    {
        public PasswordService()
        {

        }
        public bool CheckPasswordRules(string password)
        {
            var upper = new Regex("[A-Z]");
            var lower = new Regex("[a-z]");
            var number = new System.Text.RegularExpressions.Regex("[0-9]");

            if (password.Length < 10) return false;

            if (upper.Matches(password).Count < 1) return false;
            if (lower.Matches(password).Count < 1) return false;
            if (number.Matches(password).Count < 1) return false;

            return true;
        }
    }
}
