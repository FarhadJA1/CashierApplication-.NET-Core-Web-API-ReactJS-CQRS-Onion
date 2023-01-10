using Domain.Entities;

namespace C.Service.DTOs.ProductDTOs;
public class ProductGetDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Barcode { get; set; } = string.Empty;   
}
