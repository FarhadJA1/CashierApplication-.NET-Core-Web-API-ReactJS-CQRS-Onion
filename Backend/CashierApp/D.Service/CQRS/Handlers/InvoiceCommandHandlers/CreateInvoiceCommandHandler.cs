using C.Service.CQRS.Commands.InvoiceCommands;
using C.Service.DTOs.InvoiceDTOs;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.InvoiceCommandHandlers;
public class CreateImportInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand,bool>
{
    private readonly IInvoiceService _invoiceService;
    private readonly IProductService _productService;
    public CreateImportInvoiceCommandHandler(IInvoiceService invoiceService, IProductService productService)
    {
        _invoiceService = invoiceService;
        _productService = productService;
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

        foreach (var product in request.Products)
        {
            var productProperty = await _productService.GetProductPropertiesByUnitId(product.ProductId, product.MeasureUnitId);

            CreateInvoiceDetailsDTO createInvoiceDetailsDTO = new()
            {
                ProductPropertiesId = productProperty.Id,
                Price = productProperty.SellingPrice,
                MeasureId = product.MeasureUnitId,
                Quantity = product.Quantity,
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