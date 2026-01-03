using SaCompliance.Domain.Interfaces;
using SaCompliance.Domain.Entities;
using SaCompliance.Infrastructure.Data;

namespace SaCompliance.Infrastructure.Repositories;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly AppDbContext _context;

    public InvoiceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Invoice> CreateInvoiceAsync(Invoice invoice)
    {
        _context.Invoices.Add(invoice);
        await _context.SaveChangesAsync();
        return invoice;
    }

    public async Task<Invoice?> GetInvoiceAsync(Guid invoiceId)
    {
        return await _context.Invoices.FindAsync(invoiceId);
    }
}