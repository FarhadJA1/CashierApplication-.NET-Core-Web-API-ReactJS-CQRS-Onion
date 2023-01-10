using C.Service.CQRS.Commands.InvoiceCommands;
using C.Service.DTOs.InvoiceDTOs;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.InvoiceCommandHandlers;
public class CreateImportInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand>
{
    private readonly IInvoiceService _invoiceService;
    public CreateImportInvoiceCommandHandler(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }
    public async Task<Unit> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        CreateInvoiceDTO createInvoiceDTO = new()
        {
            CreationDate = DateTime.Now,
            UserId = request.UserId,
            CustomerId = request.CustomerId,    
            InvoiceType= request.InvoiceType,
        };
        CreateInvoiceDetailsDTO createInvoiceDetailsDTO = new()
        {
            ProductId = request.ProductId,
            Price = request.Price,
            MeasureId = request.MeasureId,
            Quantity = request.Quantity,
        };

        await _invoiceService.CreateInvoiceAsync(createInvoiceDTO, createInvoiceDetailsDTO);

        return Unit.Value;
    }
}