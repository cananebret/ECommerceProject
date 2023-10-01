using ECommerce.Shared.Exceptions.Concrete;
using ECommerce.Shared.Exceptions.Enums;
using ECommerce.Shared.Exceptions.Helper;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace ECommerce.WebApi
{
    public static class ConfigurationExtensions
    {
        public static IApplicationBuilder ConfigureExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            return
                app.Use(async (context, next) =>
                {
                    try
                    {
                        await next.Invoke();
                    }
                    catch (Exception ex)
                    {
                        string result = "";
                        int statusCode = 500;

                        //model labels must be lowcase
                        var serializerSettings = new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        };

                        ApiExceptionResponse error = new ApiExceptionResponse();

                        if (ex is ApiExceptionBase apiExceptionBase)
                        {
                            statusCode = apiExceptionBase.StatusCode;
                            error.Errors = apiExceptionBase.Errors;
                            result = JsonConvert.SerializeObject(error, serializerSettings);
                        }
                        else
                        {
                            //.net standart üzerinden gelen exception'ı core'da kontrol ederiz
                            if (ex.TryParseJson(out Error err))
                            {
                                error.Errors = new Error[] {
                                new Error {
                                    Code = err.Code,
                                    Message = err.Message
                                }};
                                statusCode = CheckToErrorCode(err.Code);

                                result = JsonConvert.SerializeObject(error, serializerSettings);
                            }
                            else
                            {
                                error.Errors = new Error[] {
                                new Error {
                                    Code = ErrorStatusCodes.InternalServerError,
                                    Message = ExceptionHelper.ExceptionMessage(ex)
                                }};
                                result = JsonConvert.SerializeObject(error, serializerSettings);
                            }
                        }

                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = statusCode;
                        await context.Response.WriteAsync(result);
                    }
                });
        }

        private static int CheckToErrorCode(string statusCode)
        {
            switch (statusCode)
            {
                case ErrorStatusCodes.BadRequest:
                    return 400;
                case ErrorStatusCodes.UnAuthorized:
                    return 401;
                case ErrorStatusCodes.Forbidden:
                    return 403;
                case ErrorStatusCodes.NotAcceptable:
                    return 406;
                case ErrorStatusCodes.NotFound:
                    return 404;
                case ErrorStatusCodes.Found:
                    return 302;
                case ErrorStatusCodes.TooManyRequest:
                    return 429;
                default:
                    return 500;
            }
        }

        private static bool TryParseJson<T>(this object @this, out T result)
        {
            bool success = true;
            var serializerSettings = new JsonSerializerSettings
            {
                Error = (sender, args) => { success = false; args.ErrorContext.Handled = true; },
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                MissingMemberHandling = MissingMemberHandling.Error
            };
            result = JsonConvert.DeserializeObject<T>(@this.ToString(), serializerSettings);
            return success;
        }
    }
}
