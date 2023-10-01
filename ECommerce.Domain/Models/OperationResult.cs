using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models
{
    public class ValidationResult
    {
        public ValidationResult()
        {

        }

        public ValidationResult(string message, string data = null, int statusCode = 400, string code = null)
        {
            this.Code = code;
            this.Data = data;
            this.Message = message;
            this.StatusCode = statusCode;
        }

        public string Code { get; set; }
        public string Data { get; set; }

        public string Message { get; set; }

        public int StatusCode { get; set; }
    }

    public class OperationResult
    {
        [Key]
        public Guid Key { get; set; }

        public bool HasWarning { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public List<ValidationResult> Errors { get; set; }

        public string DataAsJson { get; set; }

        public string DataType { get; set; }

        public int StatusCode { get; set; }

        public int AffectedRowCount { get; set; }

        public bool SuccessWithoutWarning
        {
            get
            {
                return IsSuccess && !HasWarning;
            }
        }

        public OperationResult(Guid? key, bool hasWarning, bool isSuccess, string message, object data, int statusCode, int affectedRowCount, List<ValidationResult> validationResults = null)
        {
            this.Key = key == null ? Guid.Empty : (Guid)key;
            this.HasWarning = hasWarning;
            this.IsSuccess = isSuccess;
            this.Message = message;
            this.StatusCode = statusCode;
            this.AffectedRowCount = affectedRowCount;
            //this.Errors = validationResults != null ? (validationResults.Count() > 1 ? validationResults.Distinct().ToList() : new List<ValidationResult>()) : null;
            this.Errors = validationResults;

            //Test haftasında iyileştirme olarak bakılacak.
            //if (data != null)
            //{
            //    this.DataAsJson = JsonConvert.SerializeObject(data, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            //    this.DataType = data.GetType().ToString();
            //}
        }


        public static OperationResult SuccessButHasWarning(string message, Guid? key = null, object data = null, int statusCode = 400, int affectedRowCount = 0)
        {
            return new OperationResult(key, true, true, message, data, statusCode, affectedRowCount);
        }

        public static OperationResult Success(string message = "", Guid? key = null, object data = null, int affectedRowCount = 0)
        {
            return new OperationResult(key, false, true, message, data, 200, affectedRowCount);
        }

        public static OperationResult Error(string message, Guid? key = null, object data = null, int statusCode = 500, List<ValidationResult> validationResults = null)
        {
            return new OperationResult(key, false, false, message, data, statusCode, 0, validationResults: validationResults);
        }

        public static OperationResult ValidationError(List<ValidationResult> validationResults, string message = "Validation Errors", int? statusCode = null)
        {
            return Error(message, statusCode: statusCode ?? 400, validationResults: validationResults);
        }

        public static OperationResult ValidationError(string message, int statusCode, string code = null, string data = null)
        {
            return ValidationError(new List<ValidationResult>() { new ValidationResult(message, data, statusCode, code) }, statusCode: statusCode);
        }

        public static OperationResult FluentValidationError(ModelStateDictionary modelState)
        {
            List<ValidationResult> errors = modelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => new ValidationResult(x.ErrorMessage, statusCode: 406))
                                            .ToList();

            if (errors.Count == 1)
            {
                var error = errors.FirstOrDefault();
                return ValidationError(error.Message, 406);
            }
            else
            {
                return ValidationError(errors, statusCode: 406);
            }
        }
        public static OperationResult FluentValidationError(FluentValidation.Results.ValidationResult modelState)
        {
            List<ValidationResult> errors = modelState.Errors
                                            .Select(x => new ValidationResult(x.ErrorMessage))
                                            .ToList();

            return ValidationError(errors);
        }
    }

    public class ImportReturnModel
    {
        public ImportReturnModel()
        {
            Returns = new List<ServiceResult>();
        }
        public List<ServiceResult> Returns { get; set; }
        public string FileUrl { get; set; }
        public string FileName { get; set; }
    }
}
