using SaCompliance.Application.DTOs;
using SaCompliance.Application.Interfaces;
using SaCompliance.Domain.Constants;
using SaCompliance.Domain.Entities;
using SaCompliance.Domain.Interfaces;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IBusinessRepository _businessRepository;
    private readonly IAuditService _audit;

    public InvoiceService(IInvoiceRepository invoiceRepository, IBusinessRepository businessRepository, IAuditService audit)
    {
        _invoiceRepository = invoiceRepository;
        _businessRepository = businessRepository;
        _audit = audit;
    }

    public async Task<Invoice> CreateInvoiceAsync(CreateInvoiceDto dto)
    {
        var business = await _businessRepository.GetBusinessAsync(dto.BusinessId);
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

        var createdInvoice = await _invoiceRepository.CreateInvoiceAsync(invoice);

        await _audit.LogAsync(
            null,
            "CREATE",
            "Invoice",
            createdInvoice.Id.ToString()
        );

        return createdInvoice;
    }

    public async Task<Invoice?> GetInvoiceAsync(Guid invoiceId)
    {
        return await _invoiceRepository.GetInvoiceAsync(invoiceId);
    }
}
