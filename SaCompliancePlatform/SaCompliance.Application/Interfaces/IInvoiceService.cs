using SaCompliance.Domain.Entities;
using SaCompliance.Application.DTOs;

namespace SaCompliance.Application.Interfaces;

public interface IInvoiceService
{
    Task<Invoice> CreateInvoiceAsync(CreateInvoiceDto dto);
    Task<Invoice?> GetInvoiceAsync(Guid invoiceId);

}
