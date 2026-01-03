using SaCompliance.Domain.Entities;

namespace SaCompliance.Application.Interfaces;

public interface IInvoicePdfGenerator
{
    byte[] GenerateInvoicePdf(Invoice invoice);
}
