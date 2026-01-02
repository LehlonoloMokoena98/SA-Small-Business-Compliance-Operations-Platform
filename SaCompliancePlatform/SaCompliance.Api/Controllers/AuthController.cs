using Microsoft.AspNetCore.Mvc;
using SaCompliance.Application.DTOs;
using SaCompliance.Application.Interfaces;

namespace SaCompliance.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;

    public AuthController(IAuthService auth)
    {
        _auth = auth;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var token = await _auth.RegisterAsync(dto);
        return Ok(new { token });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var token = await _auth.LoginAsync(dto);
        return Ok(new { token });
    }
}
