using A.Domain.Enum;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace C.Service.CQRS.Commands.InvoiceCommands;
public class CreateInvoiceCommand : IRequest<bool>
{
    [Required]
    public int UserId { get; set; }
    [Required]
    public int CustomerId { get; set; }
    public List<int> Products { get; set; } = new List<int>(0);
    public decimal Price { get; set; }
    public int MeasureId { get; set; }
    public decimal Quantity { get; set; }
    public byte InvoiceType { get; set; }

}
