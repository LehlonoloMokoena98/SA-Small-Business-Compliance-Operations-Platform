using SaCompliance.Application.Interfaces;
using SaCompliance.Domain.Entities;
using SaCompliance.Infrastructure.Data;

namespace SaCompliance.Application.Services;

public class BusinessService : IBusinessService
{
    private readonly AppDbContext _context;

    public BusinessService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Business> CreateBusinessAsync(Business business)
    {
        _context.Businesses.Add(business);
        await _context.SaveChangesAsync();
        return business;
    }

    public async Task<IEnumerable<Business>> GetAllBusinessesAsync()
    {
        return await Task.FromResult(_context.Businesses.ToList());
    }
}
