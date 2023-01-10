using B.Repository.Repositories.Interfaces;
using Dapper;
using Domain.Entities;

namespace B.Repository.Repositories.Implementations;
public class ProductRepository : BaseSqlRepository, IProductRepository
{
    public Task CreateAsync(Product entity)
    {        
        using var connection = OpenConnection();

        connection.Query<Product>(@"INSERT INTO [dbo].[Products] ([Name], [Barcode])
                                    VALUES (@Name,@Barcode)",
                                    new { entity.Name, entity.Barcode});
       
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        using var connection = OpenConnection();
        connection.Query(@"DELETE FROM Products
                           WHERE Id = @id 
                           DELETE FROM ProductProperties
                           WHERE ProductId = @id", new { id });
        
        return Task.CompletedTask;
                                                      
    }

    public  Task<List<Product>> GetAllAsync()
    {
        using var connection = OpenConnection();

        string sql = @"SELECT * FROM [dbo].[Products]";

        List<Product> products = connection.Query<Product>(sql).ToList();

        return Task.FromResult(products);
    }

    public Task<Product> GetAsync(int id)
    {
        using var connection = OpenConnection();

        string sql = @"SELECT * FROM [dbo].[Products] product                        
                       WHERE product.Id = @id                      
                      ";

        Product? product = connection.Query<Product>(sql, new { id }).FirstOrDefault(); 

        if (product!=null)
        {
            return Task.FromResult(product);
        }
        else
        {
            throw new NullReferenceException("Product not found");
        }
    }

   
    public Task SetProductPropertyToDefaultAsync(int productId, int measureUnitId, bool isDefault)
    {
        using var connection = OpenConnection();

        connection.Query(@"UPDATE ProductProperties
                           SET IsDefault = @isDefault
                           WHERE ProductId = @productId AND MeasureUnitId = @measureUnitId
                           ", new { isDefault, productId ,measureUnitId});

        if (isDefault==true)
        {
            connection.Query(@"UPDATE ProductProperties
                           SET IsDefault = 0
                           WHERE ProductId = @productId AND MeasureUnitId != @measureUnitId
                           ", new { productId, measureUnitId });
        }
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Product entity,ProductProperty productProperty)
    {
        using var connection = OpenConnection();

        connection.Query(@"UPDATE Products
                           SET Name = @Name
                           WHERE Id = @Id

                           UPDATE ProductProperties
                           SET MeasureUnitId = @MeasureUnitId, PurchasePrice=@PurchasePrice,
                               SellingPrice = @SellingPrice, GrossPrice = @GrossPrice
                           WHERE ProductId = @Id
                          ", new { entity.Id ,entity.Name , productProperty.MeasureUnitId, productProperty.PurchasePrice,
                                   productProperty.SellingPrice, productProperty.GrossPrice, productProperty.ProductId });        
      

        return Task.CompletedTask;
    }

    public Task<List<ProductProperty>> GetAllProductPropertiesAsync(int productId)
    {
        using var connection = OpenConnection();

        string sql = @"SELECT * FROM [dbo].[ProductProperties] property INNER JOIN [dbo].[MeasureUnits] unit
                       ON property.MeasureUnitId = unit.Id
                       WHERE property.ProductId = @productId";

        List<ProductProperty> productProperties = connection.Query<ProductProperty, MeasureUnit, ProductProperty>(sql, (x, y) =>
        {
            x.MeasureUnit = y;
            return x;
        },new { productId}).ToList();

        if (productProperties != null)
        {
            return Task.FromResult(productProperties);
        }
        else
        {
            throw new NullReferenceException("Product Properties not found");
        }
    }

}
