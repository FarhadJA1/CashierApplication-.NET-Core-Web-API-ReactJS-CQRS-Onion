using C.Service.DTOs.CustomerDTOs;
using MediatR;

namespace C.Service.CQRS.Queries.CustomerQueries;
public class GetCustomerByIdQuery : IRequest<CustomerGetDTO>
{
    public int Id { get; set; }
}
