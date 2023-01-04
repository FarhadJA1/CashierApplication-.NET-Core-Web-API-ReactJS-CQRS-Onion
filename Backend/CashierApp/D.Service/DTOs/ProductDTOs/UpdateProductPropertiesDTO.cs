namespace C.Service.DTOs.ProductDTOs;
public class UpdateProductPropertiesDTO
{
    public int MeasureUnitId { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal SellingPrice { get; set; }
    public decimal GrossPrice { get; set; }
}
