using SaCompliance.Domain.Entities;

namespace SaCompliance.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> GetUserByEmailAsync(string email);
    Task<User> CreateUserAsync(User user);
}