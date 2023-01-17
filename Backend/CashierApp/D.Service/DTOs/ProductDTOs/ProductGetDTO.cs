using Domain.Entities;

namespace C.Service.DTOs.ProductDTOs;
public class ProductGetDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<ProductPropertiesGetDto> ProductProperties { get; set; } = default!;
}
