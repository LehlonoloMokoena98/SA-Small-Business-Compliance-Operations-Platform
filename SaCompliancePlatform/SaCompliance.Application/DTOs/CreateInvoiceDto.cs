namespace SaCompliance.Application.DTOs;

public class CreateInvoiceDto
{
    public Guid BusinessId { get; set; }
    public decimal SubTotal { get; set; }
}
