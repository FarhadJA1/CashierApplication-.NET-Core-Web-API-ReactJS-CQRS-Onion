using C.Service.DTOs.CustomerDTOs;
using MediatR;

namespace C.Service.CQRS.Queries.CustomerQueries;
public  class GetAllCustomersQuery : IRequest<List<CustomerGetDTO>>
{

}
