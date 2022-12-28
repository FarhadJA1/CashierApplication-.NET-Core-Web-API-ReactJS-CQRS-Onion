namespace Domain.Entities;
public sealed class ProductProperty
{
    public int ProductId { get; set; }   
    public int MeasureUnitId { get; set; }   
    public decimal PurchasePrice { get; set; }
    public decimal SellingPrice { get; set; }
    public decimal GrossPrice { get; set; }       
    public bool IsDefault { get; set; }

    public MeasureUnit MeasureUnit { get; set; } = default!;
    public Product Product { get; set; } = default!;
}
