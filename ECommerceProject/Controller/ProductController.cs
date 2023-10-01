using ECommerce.Core.Interfaces;
using ECommerce.Core.Services;
using ECommerce.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts/{categoryId}")]
        public IActionResult GetAllMainCategory(Guid categoryId)
        {
            var result = _productService.GetAllProducts(categoryId);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetProductDetail/{productId}")]
        public IActionResult GetProductDetail(Guid productId)
        {
            var result = _productService.GetProductDetail(productId);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost("AddProduct")]
        public IActionResult Post(CreateProductModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _productService.AddProduct(model);
                return Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, OperationResult.FluentValidationError(ModelState));
            }
        }
    }
}
