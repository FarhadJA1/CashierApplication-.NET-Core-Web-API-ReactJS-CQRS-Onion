using Domain.Entities;
using Microsoft.Data.SqlClient;

namespace B.Repository.Repositories.Interfaces;
public interface IProductRepository:IRepository<Product>
{
    Task UpdateAsync(Product entity,ProductProperty productProperty);
    Task SetProductPropertyToDefaultAsync(int productId, int measureUnitId, bool isDefault);

    Task<ProductProperty> GetProductPropertiesByUnitId(int productId,int measureUnitId);
    Task CreateProductProperties(ProductProperty productProperty);

}
