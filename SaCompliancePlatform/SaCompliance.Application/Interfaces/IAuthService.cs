using SaCompliance.Application.DTOs;

namespace SaCompliance.Application.Interfaces;

public interface IAuthService
{
    Task<string> RegisterAsync(RegisterDto dto);
    Task<string> LoginAsync(LoginDto dto);
}
