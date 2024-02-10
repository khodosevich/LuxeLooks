using System.Net;
using System.Runtime.Serialization;
using FluentValidation;
using LuxeLooks.Domain.Enum;
using LuxeLooks.Domain.Models;
using LuxeLooks.Domain.Models.Requests;
using LuxeLooks.Domain.Response;
using LuxeLooks.Service.Services;
using LuxeLooks.SharedLibrary.Exceptions;
using LuxeLooks.SharedLibrary.Mappers;
using LuxeLooks.SharedLibrary.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LuxeLooks.Areas.Admin.Controllers;
[ApiController]
[Area("Admin")]
[Authorize(Policy = "AdminArea")]
[Route("{area}/Product")]
public class ProductController:ControllerBase
{
    private readonly ProductService _productService;
    private readonly ILogger<ProductController> _logger;
    private readonly StringToGuidMapper _guidMapper;
    public ProductController(ProductService productService, ILogger<ProductController> logger, StringToGuidMapper guidMapper)
    {
        _productService = productService;
        _logger = logger;
        _guidMapper = guidMapper;
    }
    
    private IActionResult HandleResponse<T>(BaseResponse<T> response)
    {
        if (response.StatusCode != HttpStatusCode.OK)
        {
            _logger.LogError($"Response from service status is not OK: {response.StatusCode}");
            return StatusCode((int)response.StatusCode, response.Description);
        }

        return Ok(response.Data);
    }

    private ProductType GetEnumValueFromString(string type)
    {
        if (!Enum.IsDefined(typeof(ProductType), type))
        {
            throw new SerializationException("Invalid type");
        }

        return (ProductType)Enum.Parse(typeof(ProductType), type);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest request)
    {
        try
        {
            var validateResult = GeneralValidator.Validate(new UpdateProductRequestValidator(), request);
            if (validateResult.Length != 0)
            {
                return BadRequest(validateResult.ToString());
            }
            var product = new Domain.Entity.Product()
            {
                Id = _guidMapper.MapTo(request.Id),
                Description = request.Description,
                Type = GetEnumValueFromString(request.Type),
                ImageUrl = request.ImageUrl,
                IsForKids = request.IsForKids,
                IsForMen = request.IsForMen,
                Name = request.Name,
                Price = request.Price
            };
            await _productService.UpdateProduct(product);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
    {
        try
        {
            var validateResult = GeneralValidator.Validate(new CreateProductRequestValidator(), request);
            if (validateResult.Length != 0)
            {
                return BadRequest(validateResult.ToString());
            }

            var product = new Domain.Entity.Product()
            {
                Description = request.Description,
                Type = GetEnumValueFromString(request.Type),
                ImageUrl = request.ImageUrl,
                IsForKids = request.IsForKids,
                IsForMen = request.IsForMen,
                Name = request.Name,
                Price = request.Price
            };
            var response = await _productService.CreateProduct(product);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return HandleResponse(response);
            }
        }
        catch (SerializationException e)
        {
            return BadRequest(e.Message);
        }

        return Ok();
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        try
        {
            await _productService.DeleteProduct(id);
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
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllProducts()
    {
        bool useCache = false;
        var response = await _productService.GetProducts(useCache);
        return HandleResponse(response);
    }
}