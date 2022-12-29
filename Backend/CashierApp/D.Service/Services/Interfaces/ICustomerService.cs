using C.Service.DTOs.CustomerDTos;
using C.Service.DTOs.CustomerDTOs;

namespace C.Service.Services.Interfaces;
public interface ICustomerService
{
    Task CreateAsync(CustomerCreateDTO customerCreateDTO);
    Task<List<CustomerGetDTO>> GetAllAsync();
    Task<CustomerGetDTO> GetByIdAsync(int id);
   
}
