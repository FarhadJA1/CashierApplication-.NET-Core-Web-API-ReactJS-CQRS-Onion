using C.Service.CQRS.Commands.InvoiceCommands;
using C.Service.DTOs.InvoiceDTOs;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.InvoiceCommandHandlers;
public class CreateImportInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand,bool>
{
    private readonly IInvoiceService _invoiceService;
    public CreateImportInvoiceCommandHandler(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }
    public async Task<bool> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        CreateInvoiceDTO createInvoiceDTO = new()
        {
            CreationDate = DateTime.Now,
            UserId = request.UserId,
            CustomerId = request.CustomerId,    
            InvoiceType = request.InvoiceType,
        };

        List<CreateInvoiceDetailsDTO> detailsDTOs = new List<CreateInvoiceDetailsDTO>();

        foreach (var id in request.Products)
        {
            CreateInvoiceDetailsDTO createInvoiceDetailsDTO = new()
            {
                ProductId = id,
                Price = request.Price,
                MeasureId = request.MeasureId,
                Quantity = request.Quantity,
            };
            detailsDTOs.Add(createInvoiceDetailsDTO);
        }
        createInvoiceDTO.Details = detailsDTOs;

         var result = await _invoiceService.CreateInvoiceAsync(createInvoiceDTO);
        if (result==true) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}