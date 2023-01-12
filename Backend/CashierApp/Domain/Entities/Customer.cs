using FluentValidation;

namespace Domain.Entities;
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}
public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(m => m.Name).NotEmpty().MaximumLength(20).MinimumLength(1);
        RuleFor(m => m.Surname).NotEmpty().MaximumLength(20);
        RuleFor(m => m.PhoneNumber).NotEmpty().MaximumLength(50);
    }
}
