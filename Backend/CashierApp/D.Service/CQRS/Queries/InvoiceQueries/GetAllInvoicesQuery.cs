using A.Domain.Enum;
using C.Service.DTOs.InvoiceDTOs;
using MediatR;

namespace C.Service.CQRS.Queries.InvoiceQueries;
public class GetAllInvoicesQuery : IRequest<List<InvoiceGetDTO>>
{
    public InvoiceType InvoiceType { get; set; }
}
