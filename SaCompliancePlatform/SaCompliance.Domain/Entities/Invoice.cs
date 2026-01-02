namespace SaCompliance.Domain.Entities;

public class Invoice
{
    public Guid Id { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;

    public decimal SubTotal { get; set; }
    public decimal VatAmount { get; set; }
    public decimal Total { get; set; }

    public bool IsPaid { get; set; }

    public Guid BusinessId { get; set; }
    public Business Business { get; set; } = null!;
}
