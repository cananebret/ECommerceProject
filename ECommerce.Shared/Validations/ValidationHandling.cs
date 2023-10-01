using ECommerce.Shared.Exceptions.Concrete;
using ECommerce.Shared.Exceptions.Enums;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Validations
{
    public class ValidationHandling : IValidatorInterceptor
    {
        public ValidationResult AfterAspNetValidation(ActionContext actionContext, IValidationContext validationContext, ValidationResult result)
        {
            if (!result.IsValid)
            {
                var notFoundError = result.Errors.FirstOrDefault(x => x.ErrorCode == ErrorStatusCodes.NotFound);
                if (notFoundError != null)
                {
                    throw new NotFoundException(notFoundError.ErrorMessage);
                }

                if (result.Errors != null && result.Errors.Any())
                {
                    List<Error> errors = new List<Error>();
                    foreach (var error in result.Errors)
                    {
                        errors.Add(new Error
                        {
                            Code = (error.ErrorCode != null ? error.ErrorCode : ErrorStatusCodes.NotAcceptable),
                            Data = "",
                            Message = error.ErrorMessage
                        });
                    }
                    throw new NotAcceptableException(errors.ToArray());
                }
            }

            return result;
        }
        public IValidationContext BeforeAspNetValidation(ActionContext actionContext, IValidationContext commonContext)
        {
            return commonContext;
        }
    }
}
