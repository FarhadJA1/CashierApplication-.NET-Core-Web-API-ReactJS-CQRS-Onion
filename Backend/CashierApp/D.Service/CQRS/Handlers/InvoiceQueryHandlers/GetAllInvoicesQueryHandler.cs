using C.Service.CQRS.Queries.InvoiceQueries;
using C.Service.DTOs.InvoiceDTOs;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.InvoiceQueryHandlers;
public class GetAllInvoicesQueryHandler : IRequestHandler<GetAllInvoicesQuery, List<InvoiceGetDTO>>
{
    private readonly IInvoiceService _invoiceService;
    public GetAllInvoicesQueryHandler(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }
    public async Task<List<InvoiceGetDTO>> Handle(GetAllInvoicesQuery request, CancellationToken cancellationToken)
    {
        if (request.InvoiceType!=0)
        {
            return await _invoiceService.GetAllInvoicesAsync(request.InvoiceType);
        }
        else
        {
            return await _invoiceService.GetAllInvoicesAsync();
        }
        
    }
}
