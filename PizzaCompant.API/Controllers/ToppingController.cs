using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.DTOs;
using Application.IService;
using PizzaCompant.API.Controllers;
using PizzaCompant.API.Controllers.Base;

namespace ToppingManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToppingController : BaseController
    {
        private readonly IToppingService _toppingService;

        public ToppingController(ILogger<ToppingController> logger, IToppingService toppingService)
            : base(logger)
        {
            _toppingService = toppingService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var toppings = _toppingService.GetToppings();
                return HandleResponse(toppings);
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to retrieve toppings.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var topping = _toppingService.GetToppingById(id);
                return HandleResponse(topping);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve topping with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ToppingDto toppingDto)
        {
            try
            {
                if (toppingDto == null)
                {
                    return BadRequest(new { message = "Invalid topping data.", success = false });
                }

                _toppingService.CreateTopping(toppingDto);
                return HandleResponse(new { message = "Topping created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create topping.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] ToppingDto toppingDto)
        {
            try
            {
                if (toppingDto == null)
                {
                    return BadRequest(new { message = "Invalid topping data.", success = false });
                }

                _toppingService.UpdateTopping(toppingDto);
                return HandleResponse(new { message = "Topping updated successfully.", success = true });
            }
            catch (ArgumentNullException)
            {
                return NotFound(new { message = "Topping not found to update.", success = false });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to update topping.");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ToppingDto toppingDto = _toppingService.GetToppingById(id);
                if (toppingDto == null)
                {
                    return BadRequest(new { message = "Invalid topping data.", success = false });
                }

                _toppingService.DeleteTopping(id);
                return HandleResponse(new { message = "Topping deleted successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve topping with ID: {id}.");
            }

        }

    }
}
