using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.DTOs;
using Application.IService;
using PizzaCompant.API.Controllers;
using PizzaCompant.API.Controllers.Base;

namespace ItemToppingManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemToppingController : BaseController
    {
        private readonly IItemToppingService _itemToppingService;

        public ItemToppingController(ILogger<ItemToppingController> logger, IItemToppingService itemToppingService)
            : base(logger)
        {
            _itemToppingService = itemToppingService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var itemToppings = _itemToppingService.GetItemToppings();
                return HandleResponse(itemToppings);
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to retrieve itemToppings.");
            }
        }

        [HttpGet("{orderId}/{toppingId}")]
        public IActionResult GetById(int orderId,int toppingId)
        {
            try
            {
                var itemTopping = _itemToppingService.GetItemToppingById(orderId,toppingId);
                return HandleResponse(itemTopping);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve itemTopping with orderId,ToppingId: {orderId},{toppingId}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ItemToppingDto itemToppingDto)
        {
            try
            {
                if (itemToppingDto == null)
                {
                    return BadRequest(new { message = "Invalid itemTopping data.", success = false });
                }

                _itemToppingService.CreateItemTopping(itemToppingDto);
                return HandleResponse(new { message = "ItemTopping created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create itemTopping.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] ItemToppingDto itemToppingDto)
        {
            try
            {
                if (itemToppingDto == null)
                {
                    return BadRequest(new { message = "Invalid itemTopping data.", success = false });
                }

                _itemToppingService.UpdateItemTopping(itemToppingDto);
                return HandleResponse(new { message = "ItemTopping updated successfully.", success = true });
            }
            catch (ArgumentNullException)
            {
                return NotFound(new { message = "ItemTopping not found to update.", success = false });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to update itemTopping.");
            }
        }

        [HttpGet("order/{orderId}")]
        public IActionResult GetByOrderId(int orderId)
        {
            try
            {
                var itemTopping = _itemToppingService.GetItemToppingsByOrderId(orderId);
                return HandleResponse(itemTopping);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve itemTopping with orderId: {orderId}");
            }
        }
        [HttpGet("topping/{toppingId}")]
        public IActionResult getByToppingId(int toppingId)
        {
            try
            {
                var itemTopping = _itemToppingService.GetItemToppingsByToppingId(toppingId);
                return HandleResponse(itemTopping);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve itemTopping with toppingId: {toppingId}");
            }
        }
        [HttpDelete("{orderId}/{toppingId}")]
        public IActionResult Delete(int orderId,int toppingId)
        {
            try
            {
                ItemToppingDto itemToppingDto = _itemToppingService.GetItemToppingById(orderId,toppingId);
                if (itemToppingDto == null)
                {
                    return BadRequest(new { message = "Invalid itemTopping data.", success = false });
                }

                _itemToppingService.DeleteItemTopping(orderId,toppingId);
                return HandleResponse(new { message = "ItemTopping deleted successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve itemTopping with orderId: {orderId} ToppingId: {toppingId}.");
            }

        }
    }
}
