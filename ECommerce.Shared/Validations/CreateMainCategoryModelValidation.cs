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
    public class CreateMainCategoryModelValidation : AbstractValidator<CreateMainCategoryModel>, IBaseValidator
    {
        private readonly ICategoryService _categoryService;
        public CreateMainCategoryModelValidation(ICategoryService categoryService)
        {
            _categoryService = categoryService;

            RuleFor(x => x.Name).NotEmpty().WithMessage(Ent_Business_ECommerce.CategoryRequired.Message).WithErrorCode(Ent_Business_ECommerce.CategoryRequired.Code)
                .NotNull().WithMessage(Ent_Business_ECommerce.CategoryRequired.Message).WithErrorCode(Ent_Business_ECommerce.CategoryRequired.Code);

            RuleFor(x => x.Name).Must(IsMainCategoryExist).WithMessage(Ent_Business_ECommerce.CategoryExist.Message).WithErrorCode(Ent_Business_ECommerce.CategoryExist.Code);

        }

        public bool IsMainCategoryExist(string name)
        {
            return !_categoryService.IsMainCategoryExist(name);
        }
    }
}
