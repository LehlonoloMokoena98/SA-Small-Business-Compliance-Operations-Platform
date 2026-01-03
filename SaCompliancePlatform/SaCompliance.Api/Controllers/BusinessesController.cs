using Microsoft.AspNetCore.Mvc;
using SaCompliance.Application.Interfaces;
using SaCompliance.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
namespace SaCompliance.Api.Controllers;
using SaCompliance.Api.Extensions;

[ApiController]
[Route("api/businesses")]
public class BusinessesController : ControllerBase
{
    private readonly IBusinessService _service;

    public BusinessesController(IBusinessService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
    Business business,
    [FromServices] IAuditService audit)
    {
    var result = await _service.CreateBusinessAsync(business);

    await audit.LogAsync(
        HttpContext.GetUserId(),
        "CREATE",
        "Business",
        result.Id.ToString()
    );

    return Ok(result);
    }
}
