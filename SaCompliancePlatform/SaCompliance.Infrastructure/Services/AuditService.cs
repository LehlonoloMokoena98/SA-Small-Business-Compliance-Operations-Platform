using SaCompliance.Application.Interfaces;
using SaCompliance.Domain.Entities;
using SaCompliance.Infrastructure.Data;

namespace SaCompliance.Infrastructure.Services;

public class AuditService : IAuditService
{
    private readonly AppDbContext _context;

    public AuditService(AppDbContext context)
    {
        _context = context;
    }

    public async Task LogAsync(
        Guid? userId,
        string action,
        string entity,
        string entityId)
    {
        var log = new AuditLog
        {
            UserId = userId,
            Action = action,
            Entity = entity,
            EntityId = entityId
        };

        _context.AuditLogs.Add(log);
        await _context.SaveChangesAsync();
    }
}
