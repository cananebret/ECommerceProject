using ECommerce.Core.Interfaces;
using ECommerce.Core.Services;
using ECommerce.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("GetCart/{userId}")]
        public IActionResult Get(Guid userId)
        {
            var result = _cartService.GetCart(userId);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("EditCart")]
        public IActionResult EditCart(EditCartModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _cartService.EditCart(model);
                return Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, OperationResult.FluentValidationError(ModelState));
            }
        }

        [HttpDelete("DeleteCart")]
        public IActionResult DeleteCart(EditCartModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _cartService.Delete(model);
                return Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, OperationResult.FluentValidationError(ModelState));
            }
        }
    }
}
