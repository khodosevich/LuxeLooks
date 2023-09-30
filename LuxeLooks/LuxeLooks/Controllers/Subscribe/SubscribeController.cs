using LuxeLooks.Domain.Models;
using LuxeLooks.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace LuxeLooks.Controllers.Subscribe;

[Route("Subscribe")]
public class SubscribeController : ControllerBase
{
    private readonly ILogger<SubscribeController> _logger;
    private readonly SubcsribeService _subcsribeService;

    public SubscribeController(ILogger<SubscribeController> logger, SubcsribeService subcsribeService)
    {
        _logger = logger;
        _subcsribeService = subcsribeService;
    }

    [HttpPut("CreateSubscribe")]
    public async Task<IActionResult> CreateSubscribe([FromBody]SubscribeRequest request)
    {
        if (!ModelState.IsValid ||(request.Category!="Mens"&&request.Category!="Womens"&&request.Category!="Kids"))
        {
            return BadRequest("Invalid Data of subscribe");
        }

        var subscribe = new Domain.Entity.Subscribe()
        {
            Category = request.Category,
            Email = request.Email
        };
        //await _subcsribeService.CreateSubscribe(subscribe);
        return Ok();
    }
}