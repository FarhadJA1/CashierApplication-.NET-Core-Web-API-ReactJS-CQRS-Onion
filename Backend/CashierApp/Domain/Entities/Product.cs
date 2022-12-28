namespace Domain.Entities;
public sealed class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Barcode { get; set; } = string.Empty;
    public List<ProductProperty> ProductProperties { get; set; } = default!;
}
