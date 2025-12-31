using Microsoft.AspNetCore.Mvc;
using SaCompliance.Application.Interfaces;
using SaCompliance.Domain.Entities;

namespace SaCompliance.Api.Controllers;

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
    public async Task<IActionResult> Create(Business business)
    {
        var result = await _service.CreateBusinessAsync(business);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var businesses = await _service.GetAllBusinessesAsync();
        return Ok(businesses);
    }
}
