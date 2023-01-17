using FluentValidation;

namespace Domain.Entities;
public sealed class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;    
    public List<ProductProperty> ProductProperties { get; set; } = default!;
}
public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(m => m.Name).NotEmpty().MaximumLength(30);       
    }
}
