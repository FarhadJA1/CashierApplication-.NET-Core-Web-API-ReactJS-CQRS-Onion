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
    public List<CreateInvoiceCommandProductDto> Products { get; set; } = default!;    
    public byte InvoiceType { get; set; }

}
public class CreateInvoiceCommandProductDto
{
    public int ProductId { get; set; }
    public int MeasureUnitId { get; set; }
    public decimal Quantity { get; set; }
}
