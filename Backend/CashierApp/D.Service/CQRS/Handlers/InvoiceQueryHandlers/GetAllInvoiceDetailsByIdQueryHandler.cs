using C.Service.CQRS.Queries.InvoiceQueries;
using C.Service.DTOs.InvoiceDTOs;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.InvoiceQueryHandlers;
public class GetAllInvoiceDetailsByIdQueryHandler : IRequestHandler<GetInvoiceDetailsByIdQuery, List<InvoiceDetailsGetDTO>>
{
    private readonly IInvoiceService _invoiceService;
    public GetAllInvoiceDetailsByIdQueryHandler(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }
    public async Task<List<InvoiceDetailsGetDTO>> Handle(GetInvoiceDetailsByIdQuery request, CancellationToken cancellationToken)
    {
        return await _invoiceService.GetInvoiceDetailsByIdAsync(request.Id);
    }
}
