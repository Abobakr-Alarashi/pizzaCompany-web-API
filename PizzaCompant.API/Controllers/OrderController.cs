using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.DTOs;
using Application.IService;
using PizzaCompant.API.Controllers;
using PizzaCompant.API.Controllers.Base;

namespace OrderManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
            : base(logger)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var orders = _orderService.GetOrders();
                return HandleResponse(orders);
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to retrieve orders.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var order = _orderService.GetOrderById(id);
                return HandleResponse(order);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve order with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrderDto orderDto)
        {
            try
            {
                if (orderDto == null)
                {
                    return BadRequest(new { message = "Invalid order data.", success = false });
                }

                _orderService.CreateOrder(orderDto);
                return HandleResponse(new { message = "Order created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create order.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] OrderDto orderDto)
        {
            try
            {
                if (orderDto == null)
                {
                    return BadRequest(new { message = "Invalid order data.", success = false });
                }

                _orderService.UpdateOrder(orderDto);
                return HandleResponse(new { message = "Order updated successfully.", success = true });
            }
            catch (ArgumentNullException)
            {
                return NotFound(new { message = "Order not found to update.", success = false });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to update order.");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                OrderDto orderDto = _orderService.GetOrderById(id);
                if (orderDto == null)
                {
                    return BadRequest(new { message = "Invalid order data.", success = false });
                }

                _orderService.DeleteOrder(id);
                return HandleResponse(new { message = "Order deleted successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve order with ID: {id}.");
            }

        }

    }
}
