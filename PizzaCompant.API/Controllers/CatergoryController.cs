using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.DTOs;
using Application.IService;
using PizzaCompant.API.Controllers;
using PizzaCompant.API.Controllers.Base;

namespace CategoryManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
            : base(logger)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var categorys = _categoryService.GetCategories();
                return HandleResponse(categorys);
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to retrieve categorys.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var category = _categoryService.GetCategoryById(id);
                return HandleResponse(category);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve category with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryDto categoryDto)
        {
            try
            {
                if (categoryDto == null)
                {
                    return BadRequest(new { message = "Invalid category data.", success = false });
                }

                _categoryService.CreateCategory(categoryDto);
                return HandleResponse(new { message = "Category created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create category.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] CategoryDto categoryDto)
        {
            try
            {
                if (categoryDto == null)
                {
                    return BadRequest(new { message = "Invalid category data.", success = false });
                }

                _categoryService.UpdateCategory(categoryDto);
                return HandleResponse(new { message = "Category updated successfully.", success = true });
            }
            catch (ArgumentNullException)
            {
                return NotFound(new { message = "Category not found to update.", success = false });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to update category.");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                CategoryDto categoryDto = _categoryService.GetCategoryById(id);
                if (categoryDto == null)
                {
                    return BadRequest(new { message = "Invalid category data.", success = false });
                }

                _categoryService.DeleteCategory(id);
                return HandleResponse(new { message = "Category deleted successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve category with ID: {id}.");
            }

        }
    }
}