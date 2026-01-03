using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaCompliance.Application.DTOs;
using SaCompliance.Application.Interfaces;

namespace SaCompliance.Api.Controllers;

[ApiController]
[Route("api/invoices")]
[Authorize]
public class InvoicesController : ControllerBase
{
    private readonly IInvoiceService _service;

    public InvoicesController(IInvoiceService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateInvoiceDto dto)
    {
        var invoice = await _service.CreateInvoiceAsync(dto);
        return Ok(invoice);
    }
}
