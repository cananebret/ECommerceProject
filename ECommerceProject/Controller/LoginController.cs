using ECommerce.Core.Interfaces;
using ECommerce.Core.Services;
using ECommerce.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Post(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.Login(model);      
                return Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, OperationResult.FluentValidationError(ModelState));
            }
        }
    }
}
