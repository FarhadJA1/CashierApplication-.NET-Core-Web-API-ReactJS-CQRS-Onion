using A.Domain.Enum;
using C.Service.DTOs.InvoiceDTOs;
using MediatR;

namespace C.Service.CQRS.Commands.InvoiceCommands;
public class CreateImportInvoiceCommand : IRequest
{
    public int UserId { get; set; }
    public int CustomerId { get; set; }
    public int InvoiceId { get; set; }
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    public int MeasureId { get; set; }
    public decimal Quantity { get; set; }
}
