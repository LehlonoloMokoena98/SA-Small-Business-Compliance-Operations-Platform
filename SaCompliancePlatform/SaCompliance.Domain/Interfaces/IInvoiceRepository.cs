using SaCompliance.Domain.Entities;

namespace SaCompliance.Domain.Interfaces;

public interface IInvoiceRepository
{
    Task<Invoice> CreateInvoiceAsync(Invoice invoice);
    Task<Invoice?> GetInvoiceAsync(Guid invoiceId);
}