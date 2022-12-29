using AutoMapper;
using B.Repository.Repositories.Interfaces;
using C.Service.DTOs.CustomerDTos;
using C.Service.DTOs.CustomerDTOs;
using C.Service.Services.Interfaces;
using Domain.Entities;

namespace C.Service.Services.Implementations;
public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
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

    public async Task<List<CustomerGetDTO>> GetAllAsync()
    {
        List<Customer> customers = await _customerRepository.GetAllAsync();
        return _mapper.Map<List<CustomerGetDTO>>(customers);
    }

    public async Task<CustomerGetDTO> GetByIdAsync(int id)
    {
        Customer customer = await _customerRepository.GetAsync(id);
        return _mapper.Map<CustomerGetDTO>(customer);
    }
}
