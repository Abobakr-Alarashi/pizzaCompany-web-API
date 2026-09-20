using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.DTOs;
using Application.IService;
using PizzaCompant.API.Controllers;
using PizzaCompant.API.Controllers.Base;

namespace PizzaManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : BaseController
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(ILogger<PizzaController> logger, IPizzaService pizzaService)
            : base(logger)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var pizzas = _pizzaService.GetPizzas();
                return HandleResponse(pizzas);
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to retrieve pizzas.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var pizza = _pizzaService.GetPizzaById(id);
                return HandleResponse(pizza);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve pizza with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] PizzaDto pizzaDto)
        {
            try
            {
                if (pizzaDto == null)
                {
                    return BadRequest(new { message = "Invalid pizza data.", success = false });
                }
                _pizzaService.CreatePizza(pizzaDto);
                return HandleResponse(new { message = "Pizza created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create pizza.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] PizzaDto pizzaDto)
        {
            try
            {
                if (pizzaDto == null)
                {
                    return BadRequest(new { message = "Invalid pizza data.", success = false });
                }
                
                _pizzaService.UpdatePizza(pizzaDto);
                return HandleResponse(new { message = "Pizza updated successfully.", success = true });
            }
            catch (ArgumentNullException)
            {
                return NotFound(new { message = "Pizza not found to update.", success = false });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to update pizza.");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                PizzaDto pizzaDto = _pizzaService.GetPizzaById(id);
                if (pizzaDto == null)
                {
                    return BadRequest(new { message = "Invalid pizza data.", success = false });
                }

                _pizzaService.DeletePizza(id);
                return HandleResponse(new { message = "Pizza deleted successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve pizza with ID: {id}.");
            }

        }

    }
}
