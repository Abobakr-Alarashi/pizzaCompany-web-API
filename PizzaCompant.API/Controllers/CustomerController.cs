using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.DTOs;
using Application.IService;
using PizzaCompant.API.Controllers;
using PizzaCompant.API.Controllers.Base;
using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
            : base(logger)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var customers = _customerService.GetCustomers();
                return HandleResponse(customers);
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to retrieve customers.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var customer = _customerService.GetCustomerById(id);
                return HandleResponse(customer);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve customer with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CustomerDto customerDto)
        {
            try
            {
                if (customerDto == null)
                {
                    return BadRequest(new { message = "Invalid customer data.", success = false });
                }
                _customerService.CreateCustomer(customerDto);
                return HandleResponse(new { message = "Customer created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create customer.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] CustomerDto customerDto)
        {
            try
            {
                if (customerDto == null)
                {
                    return BadRequest(new { message = "Invalid customer data.", success = false });
                }

                _customerService.UpdateCustomer(customerDto);
                return HandleResponse(new { message = "Customer updated successfully.", success = true });
            }
            catch (ArgumentNullException)
            {
                return NotFound(new { message = "Customer not found to update.", success = false });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to update customer.");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                CustomerDto customerDto = _customerService.GetCustomerById(id);
                if (customerDto == null)
                {
                    return BadRequest(new { message = "Invalid customer data.", success = false });
                }

                _customerService.DeleteCustomer(id);
                return HandleResponse(new { message = "Customer deleted successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve customer with ID: {id}.");
            }

        }
    }

    }
