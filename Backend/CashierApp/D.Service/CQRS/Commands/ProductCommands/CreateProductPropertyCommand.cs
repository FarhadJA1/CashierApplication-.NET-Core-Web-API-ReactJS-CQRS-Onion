using MediatR;

namespace C.Service.CQRS.Commands.ProductCommands;
public class CreateProductPropertyCommand : IRequest
{
    public int ProductId { get; set; }
    public int MeasureUnitId { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal SellingPrice { get; set; }
    public decimal GrossPrice { get; set; }
}
