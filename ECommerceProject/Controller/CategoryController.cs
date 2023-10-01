using ECommerce.Core.Interfaces;
using ECommerce.Core.Services;
using ECommerce.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAllMainCategories")]
        public IActionResult GetAllMainCategory()
        {
            var result = _categoryService.GetAllMainCategories();
            return StatusCode(StatusCodes.Status200OK, result);
        }


        [HttpGet("GetAllCategories")]
        public IActionResult GetAllCategory()
        {
            var result = _categoryService.GetAllCategories();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetAllSubCategories")]
        public IActionResult GetAllSubCategory()
        {
            var result = _categoryService.GetAllSubCategories();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost("AddMainCategory")]
        public IActionResult Post(CreateMainCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _categoryService.AddMainCategory(model);
                return Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, OperationResult.FluentValidationError(ModelState));
            }
        }

        [HttpPost("AddCategory")]
        public IActionResult AddCategory(CreateCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _categoryService.AddCategory(model);
                return Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, OperationResult.FluentValidationError(ModelState));
            }
        }
    }
}
