using B.Repository.Repositories.Interfaces;
using Dapper;
using Domain.Entities;
using Microsoft.Data.SqlClient;

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

        string sql = @"SELECT * FROM ([dbo].[ProductProperties] prop JOIN [dbo].[MeasureUnits] measure ON prop.MeasureUnitId = measure.Id) INNER JOIN [dbo].[Products] product ON prop.ProductId = product.Id";

        List<ProductProperty> productProperties = connection.Query<ProductProperty,Product, MeasureUnit,ProductProperty>(sql, (m,x,y) =>
        {         
            m.Product = x;
            m.MeasureUnit= y;
            return m;
        }).ToList();

        List<Product> products = new List<Product>();

        return Task.FromResult(MapListProductPropertyToProduct(products, productProperties));
    }

    public Task<Product> GetAsync(int id)
    {
        using var connection = OpenConnection();

        string sql = @"SELECT * FROM ([dbo].[ProductProperties] prop 
                       JOIN [dbo].[MeasureUnits] measure ON prop.MeasureUnitId = measure.Id)
                       INNER JOIN [dbo].[Products] product 
                       ON prop.ProductId = product.Id                        
                      ";

        List<ProductProperty> productProperties = connection.Query<ProductProperty, Product, MeasureUnit,ProductProperty>(sql, (m, x,y) =>
        {
            m.Product = x;
            m.MeasureUnit= y;
            return m;
        }).ToList();

        Product? product = connection.Query<Product>("SELECT * FROM [dbo].[Products] WHERE Id = @id", new { id }).FirstOrDefault();


        if (product!=null)
        {
            return Task.FromResult(MapSingleProductPropertyToProduct(product, productProperties));
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


    private List<Product> MapListProductPropertyToProduct(List<Product> products, List<ProductProperty> productProperties)
    {
        foreach (ProductProperty property in productProperties)
        {
            products.Add(property.Product);
        }
        foreach (Product product in products)
        {
            product.ProductProperties = productProperties;
        }
        return products;
    }

    private Product MapSingleProductPropertyToProduct(Product product, List<ProductProperty> productProperties)
    {        
        foreach (var property in productProperties)
        {
            if (property.ProductId==product.Id)
            {
                product.ProductProperties = productProperties;
            }
        }
        return product;
    }


}
