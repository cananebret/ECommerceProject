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
    public class CreateProductModelValidation : AbstractValidator<CreateProductModel>, IBaseValidator
    {
        private readonly ICategoryService _categoryService;
        public CreateProductModelValidation(ICategoryService categoryService)
        {
            _categoryService = categoryService;

            RuleFor(x => x.Name).NotEmpty().WithMessage(Ent_Business_ECommerce.CategoryRequired.Message).WithErrorCode(Ent_Business_ECommerce.CategoryRequired.Code)
                .NotNull().WithMessage(Ent_Business_ECommerce.CategoryRequired.Message).WithErrorCode(Ent_Business_ECommerce.CategoryRequired.Code);

            RuleFor(x => x.Amount).NotEmpty().WithMessage(Ent_Business_ECommerce.AmountRequired.Message).WithErrorCode(Ent_Business_ECommerce.AmountRequired.Code)
            .NotNull().WithMessage(Ent_Business_ECommerce.AmountRequired.Message).WithErrorCode(Ent_Business_ECommerce.AmountRequired.Code);

            RuleFor(x => x.Stock).NotEmpty().WithMessage(Ent_Business_ECommerce.StockRequired.Message).WithErrorCode(Ent_Business_ECommerce.StockRequired.Code)
            .NotNull().WithMessage(Ent_Business_ECommerce.StockRequired.Message).WithErrorCode(Ent_Business_ECommerce.StockRequired.Code);

            RuleFor(x => x.CategoryId).Must(IsCategoryExist).WithMessage(Ent_Business_ECommerce.CategoryExist.Message).WithErrorCode(Ent_Business_ECommerce.CategoryExist.Code);

        }

        public bool IsCategoryExist(Guid categoryId)
        {
            return !_categoryService.IsCategoryExist(categoryId);
        }
    }
}
