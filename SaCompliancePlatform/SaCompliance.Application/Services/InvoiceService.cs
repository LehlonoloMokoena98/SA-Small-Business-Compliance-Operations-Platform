using SaCompliance.Application.DTOs;
using SaCompliance.Application.Interfaces;
using SaCompliance.Domain.Constants;
using SaCompliance.Domain.Entities;
using SaCompliance.Infrastructure.Data;

public class InvoiceService : IInvoiceService
{
    private readonly AppDbContext _context;

    public InvoiceService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Invoice> CreateInvoiceAsync(CreateInvoiceDto dto)
    {
        var business = await _context.Businesses.FindAsync(dto.BusinessId);
        if (business == null)
            throw new Exception("Business not found");

        decimal vat = business.IsVatRegistered
            ? dto.SubTotal * VatConstants.VatRate
            : 0;

        var invoice = new Invoice
        {
            InvoiceNumber = $"INV-{DateTime.UtcNow.Ticks}",
            SubTotal = dto.SubTotal,
            VatAmount = vat,
            Total = dto.SubTotal + vat,
            BusinessId = business.Id
        };

        _context.Invoices.Add(invoice);
        await _context.SaveChangesAsync();

        return invoice;
    }
}
