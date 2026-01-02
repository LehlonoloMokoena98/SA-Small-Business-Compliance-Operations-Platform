using SaCompliance.Application.Interfaces;
using SaCompliance.Domain.Entities;

namespace SaCompliance.Application.Services;

public class BusinessService : IBusinessService
{
    private readonly IBusinessRepository _businessRepository;

    public BusinessService(IBusinessRepository businessRepository)
    {
        _businessRepository = businessRepository;
    }

    public async Task<Business> CreateBusinessAsync(Business business)
    {
        return await _businessRepository.CreateBusinessAsync(business);
    }

    public async Task<IEnumerable<Business>> GetAllBusinessesAsync()
    {
        return await _businessRepository.GetAllBusinessesAsync();
    }
}
