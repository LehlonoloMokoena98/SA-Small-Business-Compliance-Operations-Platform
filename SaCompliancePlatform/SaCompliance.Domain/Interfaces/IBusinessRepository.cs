using SaCompliance.Domain.Entities;

namespace SaCompliance.Domain.Interfaces;

public interface IBusinessRepository
{
    Task<Business> CreateBusinessAsync(Business business);
    Task<IEnumerable<Business>> GetAllBusinessesAsync();
}