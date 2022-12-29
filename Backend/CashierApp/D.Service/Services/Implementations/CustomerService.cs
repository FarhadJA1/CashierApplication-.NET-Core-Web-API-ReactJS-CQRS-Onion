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
        await _customerRepository.CreateAsync(_mapper.Map<Customer>(customerCreateDTO)); 
    }

    public async Task DeleteAsync(int id)
    {
        await _customerRepository.DeleteAsync(id);
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

    public async Task UpdateAsync(int id, CustomerUpdateDTO customerUpdateDTO)
    {
        Customer customer = new();
        _mapper.Map(customerUpdateDTO,customer);
        await _customerRepository.UpdateAsync(id, customer);
    }
}
