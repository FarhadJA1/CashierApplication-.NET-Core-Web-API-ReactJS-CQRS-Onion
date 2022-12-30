using C.Service.DTOs.ProductDTOs;
using Domain.Entities;

namespace C.Service.Services.Interfaces;

public interface IProductService
{
    Task CreateAsync(CreateProductDTO customerCreateDTO);
    Task<List<ProductGetDTO>> GetAllAsync();
    Task<ProductGetDTO> GetAsync(int id);
    Task DeleteAsync(int id);

}
