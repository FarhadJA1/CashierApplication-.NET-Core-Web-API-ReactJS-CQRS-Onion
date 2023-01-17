using AutoMapper;
using B.Repository.Repositories.Interfaces;
using C.Service.DTOs.ProductDTOs;
using C.Service.Services.Interfaces;
using Domain.Entities;

namespace C.Service.Services.Implementations;
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task CreateAsync(CreateProductDTO createProductDTO)
    {        
        await _productRepository.CreateAsync(_mapper.Map<Product>(createProductDTO));
    }

    public async Task DeleteAsync(int id)
    {
        await _productRepository.DeleteAsync(id);
    }

    public async Task<List<ProductGetDTO>> GetAllAsync()
    {
        List<Product> products = await _productRepository.GetAllAsync();
        return _mapper.Map<List<ProductGetDTO>>(products);      
    }

    public async Task<ProductGetDTO> GetAsync(int id)
    {
        Product product = await _productRepository.GetAsync(id);
        return _mapper.Map<ProductGetDTO>(product);
    }

    public async Task SetProductPropertyToDefaultAsync(int productId, int measureUnitId,bool isDefault)
    {
        await _productRepository.SetProductPropertyToDefaultAsync(productId,measureUnitId, isDefault);
    }

    public async Task UpdateAsync(int id, UpdateProductDTO updateProductDTO, UpdateProductPropertiesDTO updateProductPropertiesDTO)
    {
        Product product = new();
        ProductProperty productProperty = new();
        _mapper.Map(updateProductDTO, product);
        _mapper.Map(updateProductPropertiesDTO, productProperty);
        product.Id = id;
        await _productRepository.UpdateAsync(product, productProperty);
    }

   
    
}
