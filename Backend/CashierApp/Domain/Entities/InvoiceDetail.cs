namespace Domain.Entities;
public class InvoiceDetail
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public int ProductPropertiesId { get; set; }
    public int MeasureId { get; set; }
    public decimal Price { get; set; }   
    public decimal Quantity { get; set; }
}
