using C.Service.CQRS.Queries.CustomerQueries;
using C.Service.DTOs.CustomerDTOs;
using C.Repository.Exceptions;
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
        var customer = await _customerService.GetByIdAsync(request.Id);

        if (customer is null)
            throw new InvalidClientOperationException("Bu ID-də müştəri yoxdur");

        return customer;
    }
}
