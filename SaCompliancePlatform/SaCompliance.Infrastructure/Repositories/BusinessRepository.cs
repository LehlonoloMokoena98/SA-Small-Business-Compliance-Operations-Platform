using SaCompliance.Domain.Interfaces;
using SaCompliance.Domain.Entities;
using SaCompliance.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SaCompliance.Infrastructure.Repositories;

public class BusinessRepository : IBusinessRepository
{
    private readonly AppDbContext _context;

    public BusinessRepository(AppDbContext context)
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
        return await _context.Businesses.ToListAsync();
    }
}