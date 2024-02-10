using System.Net;
using System.Runtime.Serialization;
using LuxeLooks.Domain.Models.Requests;
using LuxeLooks.Service.Services;
using LuxeLooks.SharedLibrary.Exceptions;
using LuxeLooks.SharedLibrary.Validators;
using LuxeLooks.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LuxeLooks.Areas.Admin.Controllers;

[ApiController]
[Area("Admin")]
[Authorize(Policy = "AdminArea")]
[Route("{area}/Order")]
public class OrderController:ControllerBase
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllOrders()
    {
        var ordersResponse = await _orderService.GetOrders();
        if (ordersResponse.StatusCode!=HttpStatusCode.OK)
        {
            return NotFound(ordersResponse.Description);
        }

        return Ok(ordersResponse.Data);
    }

    [HttpPost("UpdateStatus")]
    public async Task<IActionResult> UpdateOrderStatus([FromBody] string newStatus,[FromBody] string id)
    {
        try
        {
            await _orderService.UpdateStatus(newStatus, id);
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