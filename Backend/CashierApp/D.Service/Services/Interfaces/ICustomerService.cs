using C.Service.DTOs.CustomerDTos;

namespace C.Service.Services.Interfaces;
public interface ICustomerService
{
    Task CreateAsync(CustomerCreateDTO customerCreateDTO);
   
}
