using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.DTOs;
using Application.IService;
using PizzaCompant.API.Controllers;
using PizzaCompant.API.Controllers.Base;

namespace OrderItemManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : BaseController
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(ILogger<OrderItemController> logger, IOrderItemService orderItemService)
            : base(logger)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var orderItems = _orderItemService.GetOrderItems();
                return HandleResponse(orderItems);
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to retrieve orderItems.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var orderItem = _orderItemService.GetOrderItemById(id);
                return HandleResponse(orderItem);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve orderItem with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrderItemDto orderItemDto)
        {
            try
            {
                if (orderItemDto == null)
                {
                    return BadRequest(new { message = "Invalid orderItem data.", success = false });
                }

                _orderItemService.CreateOrderItem(orderItemDto);
                return HandleResponse(new { message = "OrderItem created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create orderItem.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] OrderItemDto orderItemDto)
        {
            try
            {
                if (orderItemDto == null)
                {
                    return BadRequest(new { message = "Invalid orderItem data.", success = false });
                }

                _orderItemService.UpdateOrderItem(orderItemDto);
                return HandleResponse(new { message = "OrderItem updated successfully.", success = true });
            }
            catch (ArgumentNullException)
            {
                return NotFound(new { message = "OrderItem not found to update.", success = false });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to update orderItem.");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                OrderItemDto orderItemDto = _orderItemService.GetOrderItemById(id);
                if (orderItemDto == null)
                {
                    return BadRequest(new { message = "Invalid orderItem data.", success = false });
                }

                _orderItemService.DeleteOrderItem(id);
                return HandleResponse(new { message = "OrderItem deleted successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve orderItem with ID: {id}.");
            }

        }

    }
}
