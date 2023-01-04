using C.Service.DTOs.ProductDTOs;

namespace C.Service.Services.Interfaces;

public interface IProductService
{
    Task CreateAsync(CreateProductDTO customerCreateDTO);
    Task<List<ProductGetDTO>> GetAllAsync();
    Task<ProductGetDTO> GetAsync(int id);
    Task DeleteAsync(int id);
    Task UpdateAsync(int id, UpdateProductDTO updateProductDTO,UpdateProductPropertiesDTO updateProductPropertiesDTO);
    Task SetProductPropertyToDefaultAsync(int productId,int measureUnitId, bool isDefault);
   

}
