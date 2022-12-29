using C.Service.CQRS.Queries.CustomerQueries;
using C.Service.DTOs.CustomerDTOs;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.CustomerQueryHandlers;
public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery,List<CustomerGetDTO>>
{
    private readonly ICustomerService _customerService;
    public GetAllCustomersQueryHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    public async Task<List<CustomerGetDTO>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        return await _customerService.GetAllAsync();
    }
}
