using ECommerce.Core.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.Shared.Errors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Validations
{
    public class EditCartModelValidation : AbstractValidator<EditCartModel>, IBaseValidator
    {
        private readonly ICartService _cartService;
        public EditCartModelValidation(ICartService cartService)
        {
            _cartService = cartService;

            RuleFor(x => x.UserId).NotEmpty().WithMessage(Ent_Business_ECommerce.UserIdRequired.Message).WithErrorCode(Ent_Business_ECommerce.UserIdRequired.Code)
                .NotNull().WithMessage(Ent_Business_ECommerce.UserIdRequired.Message).WithErrorCode(Ent_Business_ECommerce.UserIdRequired.Code);

            RuleFor(x => x.ProductId).NotEmpty().WithMessage(Ent_Business_ECommerce.ProductIdRequired.Message).WithErrorCode(Ent_Business_ECommerce.ProductIdRequired.Code)
                .NotNull().WithMessage(Ent_Business_ECommerce.ProductIdRequired.Message).WithErrorCode(Ent_Business_ECommerce.ProductIdRequired.Code);

            RuleFor(x => x.Qty).NotEmpty().WithMessage(Ent_Business_ECommerce.QtyRequired.Message).WithErrorCode(Ent_Business_ECommerce.QtyRequired.Code)
                .NotNull().WithMessage(Ent_Business_ECommerce.QtyRequired.Message).WithErrorCode(Ent_Business_ECommerce.QtyRequired.Code);

            RuleFor(x => x.Qty).GreaterThan(0).WithMessage(Ent_Business_ECommerce.QtyMustBeGreaterThan.Message).WithErrorCode(Ent_Business_ECommerce.QtyMustBeGreaterThan.Code);

            RuleFor(x => x).Must(CheckCartLimit).WithMessage(Ent_Business_ECommerce.WrongPassword.Message).WithErrorCode(Ent_Business_ECommerce.WrongPassword.Code);

        }

        public bool CheckCartLimit(EditCartModel model)
        {
            return !_cartService.CheckCartLimit(model.ProductId, model.Qty);
        }

    }
}
