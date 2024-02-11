using LuxeLooks.Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace LuxeLooks.Controllers.Type;

[Route("Type")]
public class TypeController : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllTypes()
    {
        string[] productTypeNames = Enum.GetNames(typeof(ProductType));

        List<string> productTypesList = new List<string>(productTypeNames);
        return Ok(productTypesList);
    }
}