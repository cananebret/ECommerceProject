using ECommerce.Core.Interfaces;
using ECommerce.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost("AddUser")]
        public IActionResult Post(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _registerService.AddUser(model);
                return Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, OperationResult.FluentValidationError(ModelState));
            }
        }
    }
}
