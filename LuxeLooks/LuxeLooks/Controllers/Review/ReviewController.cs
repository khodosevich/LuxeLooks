using System.ComponentModel.DataAnnotations;
using LuxeLooks.Domain.Models;
using LuxeLooks.Service.Services;
using LuxeLooks.SharedLibrary.Exceptions;
using LuxeLooks.SharedLibrary.Validators;
using Microsoft.AspNetCore.Mvc;

namespace LuxeLooks.Controllers.Review;
[ApiController]
[Route("Review")]
public class ReviewController:ControllerBase
{
    private readonly ReviewService _reviewService;

    public ReviewController(ReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    private void ValidateRequest(ReviewRequest reviewRequest)
    {
        var validateResult = GeneralValidator.Validate(new ReviewRequestValidator(), reviewRequest);
        if (validateResult.Length != 0)
        {
            throw new ValidationException(validateResult.ToString());
        }
    }
    [HttpPost("CreateReview")]
    public async Task<IActionResult> CreateReview([FromBody]ReviewRequest request)
    {
        try
        {
            ValidateRequest(request);
            await _reviewService.Create(request);
        }
        catch (InvalidOperationException e)
        {
            return NotFound(e.Message);
        }
        catch (ValidationException exception)
        {
            return BadRequest(exception.Message);
        }
        catch (MappingException exception)
        {
            return BadRequest(exception.Message);
        }
        return Ok();
    }

    [HttpGet("GetByUserId/{userId}")]
    public async Task<IActionResult> GetByUserId(string userId)
    {
        try
        {
            var reviews = await _reviewService.GetByUserId(userId);
            return Ok(reviews);
        }
        catch (InvalidOperationException e)
        {
            return NotFound(e.Message);
        }
        catch (MappingException exception)
        {
            return BadRequest(exception.Message);
        }
    }
    [HttpGet("GetByProductId/{productId}")]
    public async Task<IActionResult> GetByProductId(string productId)
    {
        try
        {
            var reviews = await _reviewService.GetByProductId(productId);
            return Ok(reviews);
        }
        catch (InvalidOperationException e)
        {
            return NotFound(e.Message);
        }
        catch (MappingException exception)
        {
            return BadRequest(exception.Message);
        }
    }
}