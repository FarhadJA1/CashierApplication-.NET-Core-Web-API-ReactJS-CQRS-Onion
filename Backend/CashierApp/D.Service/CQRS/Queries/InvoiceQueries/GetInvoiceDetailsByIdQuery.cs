using C.Service.DTOs.InvoiceDTOs;
using MediatR;

namespace C.Service.CQRS.Queries.InvoiceQueries;

public class GetInvoiceDetailsByIdQuery : IRequest<List<InvoiceDetailsGetDTO>>
{
    public int Id { get; set; }
}
