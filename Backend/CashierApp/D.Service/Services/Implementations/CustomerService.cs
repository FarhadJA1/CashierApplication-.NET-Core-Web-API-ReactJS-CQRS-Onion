using B.Repository.Repositories.Interfaces;
using C.Service.DTOs.CustomerDTos;
using C.Service.Services.Interfaces;
using Domain.Entities;

namespace C.Service.Services.Implementations;
public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task CreateAsync(CustomerCreateDTO customerCreateDTO)
    {
        Customer customer = new() 
        { 
            Name= customerCreateDTO.Name,
            Surname=customerCreateDTO.Surname,
            PhoneNumber=customerCreateDTO.PhoneNumber
        };
        await _customerRepository.CreateAsync(customer);
    }
}
