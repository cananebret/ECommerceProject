using ECommerce.Core.Interfaces;
using ECommerce.Core.Services;
using ECommerce.Domain.Models;
using ECommerce.Shared.Errors;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Validations
{
    public class LoginModelValidation : AbstractValidator<LoginModel>, IBaseValidator
    {
        private readonly IEmailService _emailService;
        private readonly IPasswordService _passwordService;
        private readonly IUserService _userService;
        public LoginModelValidation(IEmailService emailService, IPasswordService passwordService, IUserService userService)
        {
            _emailService = emailService;
            _passwordService = passwordService;
            _userService = userService;

            RuleFor(x => x.Email).NotEmpty().WithMessage(Ent_Business_ECommerce.EmailRequired.Message).WithErrorCode(Ent_Business_ECommerce.EmailRequired.Code);
            RuleFor(x => x.Password).NotEmpty().WithMessage(Ent_Business_ECommerce.PasswordRequired.Message).WithErrorCode(Ent_Business_ECommerce.PasswordRequired.Code);

            RuleFor(x => x.Email).Must(CheckEmail).WithMessage(Ent_Business_ECommerce.WrongEmail.Message).WithErrorCode(Ent_Business_ECommerce.WrongEmail.Code);
            RuleFor(x => x.Password).Must(CheckPasswordRules).WithMessage(Ent_Business_ECommerce.WrongPassword.Message).WithErrorCode(Ent_Business_ECommerce.WrongPassword.Code);
            RuleFor(x => x.Email).Must(IsUserActive).WithMessage(Ent_Business_ECommerce.UserNotActive.Message).WithErrorCode(Ent_Business_ECommerce.UserNotActive.Code);
            RuleFor(x => x).Must(IsPasswordCorrect).WithMessage(Ent_Business_ECommerce.PasswordNotAcceptable.Message).WithErrorCode(Ent_Business_ECommerce.PasswordNotAcceptable.Code);

        }

        private bool CheckEmail(string email)
        {
            return _emailService.ValidateUsingRegex(email);
        }

        protected bool CheckPasswordRules(string password)
        {
            return _passwordService.CheckPasswordRules(password);
        }

        public bool IsUserActive(string email)
        {
            return _userService.IsUserActive(email);
        }

        public bool IsPasswordCorrect(LoginModel model)
        {
            return _userService.IsPasswordCorrect(model.Email, model.Password);
        }

    }
}
