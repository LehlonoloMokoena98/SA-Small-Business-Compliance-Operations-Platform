using SaCompliance.Domain.Entities;

namespace SaCompliance.Application.Interfaces;

public interface IBusinessService
{
    Task<Business> CreateBusinessAsync(Business business);
    Task<IEnumerable<Business>> GetAllBusinessesAsync();
}
