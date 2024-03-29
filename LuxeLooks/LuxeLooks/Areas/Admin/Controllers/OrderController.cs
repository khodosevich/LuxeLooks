﻿using System.Net;
using System.Runtime.Serialization;
using LuxeLooks.Domain.Entity;
using LuxeLooks.Domain.Models.Requests;
using LuxeLooks.Service.Services;
using LuxeLooks.SharedLibrary.Exceptions;
using LuxeLooks.SharedLibrary.Validators;
using LuxeLooks.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LuxeLooks.Areas.Admin.Controllers;

[ApiController]
[Area("Admin")]
[Authorize(Policy = "AdminArea")]
[Route("{area}/Order")]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [SwaggerOperation("Gets a list of apartment operations")]
    [SwaggerResponse(statusCode: 404, description: "Invalid operation")]
    [SwaggerResponse(statusCode: 200, type: typeof(List<Order>))]
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllOrders()
    {
        var ordersResponse = await _orderService.GetOrders();
        if (ordersResponse.StatusCode != HttpStatusCode.OK)
        {
            return NotFound(ordersResponse.Description);
        }

        return Ok(ordersResponse.Data);
    }

    [SwaggerOperation("Gets a list of apartment operations")]
    [SwaggerResponse(statusCode: 404, description: "Invalid operation")]
    [SwaggerResponse(statusCode: 400, description: "Invalid request")]
    [SwaggerResponse(statusCode: 200)]
    [HttpPut("UpdateStatus")]
    public async Task<IActionResult> UpdateOrderStatus([FromBody] UpdateOrderStatusRequest request)
    {
        try
        {
            await _orderService.UpdateStatus(request.NewStatus,request.Id);
        }
        catch (SerializationException e)
        {
            return BadRequest(e.Message);
        }
        catch (MappingException e)
        {
            return BadRequest(e.Message);
        }
        catch (InvalidOperationException e)
        {
            return NotFound(e.Message);
        }

        return Ok();
    }

    [SwaggerOperation("Gets a list of apartment operations")]
    [SwaggerResponse(statusCode: 404, description: "Invalid operation")]
    [SwaggerResponse(statusCode: 400, description: "Invalid request")]
    [SwaggerResponse(statusCode: 200)]
    [HttpPut("Update")]
    public async Task<IActionResult> UpdateOrder(UpdateOrderRequest request)
    {
        try
        {
            var validateResult = GeneralValidator.Validate(new UpdateOrderRequestValidator(), request);
            if (validateResult.Length != 0)
            {
                return BadRequest(validateResult.ToString());
            }

            await _orderService.Update(request);
        }
        catch (InvalidOperationException e)
        {
            return NotFound(e.Message);
        }
        catch (SerializationException e)
        {
            return BadRequest(e.Message);
        }
        catch (MappingException e)
        {
            return BadRequest(e.Message);
        }

        return Ok();
    }

    [SwaggerOperation("Gets a list of apartment operations")]
    [SwaggerResponse(statusCode: 404, description: "Invalid operation")]
    [SwaggerResponse(statusCode: 400, description: "Invalid request")]
    [SwaggerResponse(statusCode: 200)]
    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> DeleteOrder(string id)
    {
        try
        {
            await _orderService.Delete(id);
        }
        catch (InvalidOperationException e)
        {
            return NotFound(e.Message);
        }
        catch (MappingException e)
        {
            return BadRequest(e.Message);
        }

        return Ok();
    }
}