namespace C.Service.DTOs.ProductDTOs;
public class CreateProductPropertyDto
{
    public int ProductId { get; set; }
    public int MeasureUnitId { get; set; }
    public string Barcode { get; set; } = string.Empty;
    public decimal PurchasePrice { get; set; }
    public decimal SellingPrice { get; set; }
    public decimal GrossPrice { get; set; }
}
