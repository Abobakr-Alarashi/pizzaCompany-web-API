using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.DTOs;
using Application.IService;
using PizzaCompant.API.Controllers;
using PizzaCompant.API.Controllers.Base;

namespace PizzaToppingManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaToppingController : BaseController
    {
        private readonly IPizzaToppingService _pizzaToppingService;

        public PizzaToppingController(ILogger<PizzaToppingController> logger, IPizzaToppingService pizzaToppingService)
            : base(logger)
        {
            _pizzaToppingService = pizzaToppingService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var pizzaToppings = _pizzaToppingService.GetPizzaToppings();
                return HandleResponse(pizzaToppings);
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to retrieve pizzaToppings.");
            }
        }

        [HttpGet("{pizzaId}/{toppingId}")]
        public IActionResult GetById(int pizzaId,int toppingId)
        {
            try
            {
                var pizzaTopping = _pizzaToppingService.GetPizzaToppingById(pizzaId,toppingId);
                return HandleResponse(pizzaTopping);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve pizzaTopping with pizzaID, toppingId: {pizzaId}, {toppingId}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] PizzaToppingDto pizzaToppingDto)
        {
            try
            {
                if (pizzaToppingDto == null)
                {
                    return BadRequest(new { message = "Invalid pizzaTopping data.", success = false });
                }

                _pizzaToppingService.CreatePizzaTopping(pizzaToppingDto);
                return HandleResponse(new { message = "PizzaTopping created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create pizzaTopping.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] PizzaToppingDto pizzaToppingDto)
        {
            try
            {
                if (pizzaToppingDto == null)
                {
                    return BadRequest(new { message = "Invalid pizzaTopping data.", success = false });
                }

                _pizzaToppingService.UpdatePizzaTopping(pizzaToppingDto);
                return HandleResponse(new { message = "PizzaTopping updated successfully.", success = true });
            }
            catch (ArgumentNullException)
            {
                return NotFound(new { message = "PizzaTopping not found to update.", success = false });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to update pizzaTopping.");
            }
        }
        [HttpGet("pizza/{pizzaId}")]
        public IActionResult getByPizzaId(int pizzaId)
        {
            try
            {
                var pizzaTopping = _pizzaToppingService.GetPizzaToppingsByPizzaId(pizzaId);
                return HandleResponse(pizzaTopping);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve pizzaTopping with pizzaId: {pizzaId}");
            }
        }
        [HttpGet("topping/{toppingId}")]
        public IActionResult getByToppingId(int toppingId)
        {
            try
            {
                var pizzaTopping = _pizzaToppingService.GetPizzaToppingsByToppingId(toppingId);
                return HandleResponse(pizzaTopping);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve pizzaTopping with toppingId: {toppingId}");
            }
        }
        [HttpDelete("{pizzaId}/{toppingId}")]
        public IActionResult Delete(int pizzaId,int toppingId)
        {
            try
            {
                PizzaToppingDto pizzaToppingDto = _pizzaToppingService.GetPizzaToppingById(pizzaId,toppingId);
                if (pizzaToppingDto == null)
                {
                    return BadRequest(new { message = "Invalid pizzaTopping data.", success = false });
                }

                _pizzaToppingService.DeletePizzaTopping(pizzaId,toppingId);
                return HandleResponse(new { message = "PizzaTopping deleted successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve pizzaTopping with pizzaId: {pizzaId} ToppingId: {toppingId}.");
            }

        }

    }
}
