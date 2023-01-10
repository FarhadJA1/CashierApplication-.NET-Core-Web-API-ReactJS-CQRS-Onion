namespace C.Service.DTOs.InvoiceDTOs;
public class InvoiceDetailsGetDTO
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    public int MeasureId { get; set; }
    public decimal Quantity { get; set; }
}
