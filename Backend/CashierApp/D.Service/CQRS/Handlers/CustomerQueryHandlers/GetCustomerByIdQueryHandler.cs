using C.Service.CQRS.Queries.CustomerQueries;
using C.Service.DTOs.CustomerDTOs;
using C.Service.Services.Interfaces;
using MediatR;

namespace C.Service.CQRS.Handlers.CustomerQueryHandlers;
public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerGetDTO>
{
    private readonly ICustomerService _customerService;
    public GetCustomerByIdQueryHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    public async Task<CustomerGetDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        return await _customerService.GetByIdAsync(request.Id);
    }
}
