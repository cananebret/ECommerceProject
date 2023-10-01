using ECommerce.Core.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.Shared.Errors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ECommerce.Shared.Validations
{
    public class CreateUserModelValidation : AbstractValidator<CreateUserModel>, IBaseValidator
    {
        private readonly IEmailService _emailService;
        private readonly IRegisterService _registerService;
        private readonly IPasswordService _passwordService;
        public CreateUserModelValidation(IEmailService emailService, IRegisterService registerService, IPasswordService passwordService)
        {
            _emailService = emailService;
            _registerService = registerService;
            _passwordService = passwordService;

            RuleFor(x => x.Email).NotEmpty().WithMessage(Ent_Business_ECommerce.EmailRequired.Message).WithErrorCode(Ent_Business_ECommerce.EmailRequired.Code);
            RuleFor(x => x.Name).NotEmpty().WithMessage(Ent_Business_ECommerce.NameRequired.Message).WithErrorCode(Ent_Business_ECommerce.NameRequired.Code);
            RuleFor(x => x.Surname).NotEmpty().WithMessage(Ent_Business_ECommerce.SurnamelRequired.Message).WithErrorCode(Ent_Business_ECommerce.SurnamelRequired.Code);
            RuleFor(x => x.CityName).NotEmpty().WithMessage(Ent_Business_ECommerce.CityNameRequired.Message).WithErrorCode(Ent_Business_ECommerce.CityNameRequired.Code);
            RuleFor(x => x.Password).NotEmpty().WithMessage(Ent_Business_ECommerce.PasswordRequired.Message).WithErrorCode(Ent_Business_ECommerce.PasswordRequired.Code);
            RuleFor(x => x.RePassword).NotEmpty().WithMessage(Ent_Business_ECommerce.RePasswordRequired.Message).WithErrorCode(Ent_Business_ECommerce.RePasswordRequired.Code);

            RuleFor(x => x).Must(IsPasswordEqual).WithMessage(Ent_Business_ECommerce.PasswordNotEqual.Message).WithErrorCode(Ent_Business_ECommerce.PasswordNotEqual.Code);
            RuleFor(x => x.Email).Must(CheckEmail).WithMessage(Ent_Business_ECommerce.WrongEmail.Message).WithErrorCode(Ent_Business_ECommerce.WrongEmail.Code);
            RuleFor(x => x.Password).Must(CheckPasswordRules).WithMessage(Ent_Business_ECommerce.WrongPassword.Message).WithErrorCode(Ent_Business_ECommerce.WrongPassword.Code);
            RuleFor(x => x.Email).Must(CheckEmailExist).WithMessage(Ent_Business_ECommerce.EmailExist.Message).WithErrorCode(Ent_Business_ECommerce.EmailExist.Code);

        }

        private bool IsPasswordEqual(CreateUserModel model)
        {
            return model.Password == model.RePassword ? true : false;
        }

        private bool CheckEmail(string email)
        {
            return _emailService.ValidateUsingRegex(email);
        }

        protected bool CheckPasswordRules(string password)
        {
            return _passwordService.CheckPasswordRules(password);
        }

        private bool CheckEmailExist(string email)
        {
            return !_registerService.IsEmailExist(email);
        }
    }
}
