using B.Repository.Repositories.Interfaces;
using Dapper;
using Domain.Entities;

namespace B.Repository.Repositories.Implementations;
public class ProductRepository : BaseSqlRepository, IProductRepository
{
    public Task CreateAsync(Product entity)
    {
        return Task.Run(() =>
        {
            using var connection = OpenConnection();

            string sql = "INSERT INTO [dbo].[Products] ([Name],[SoftDelete]) VALUES (@Name,0)";

            connection.Execute(sql,new { entity.Name });
        });       
    }

    public Task DeleteAsync(int id)
    {
        return Task.Run(() =>
        {
            using var connection = OpenConnection();
            connection.Execute(@$"UPDATE Products SET SoftDelete = 1 WHERE Id = @id 
                                  DELETE FROM ProductProperties WHERE ProductId = {id}");
        });                                      
    }

    public  Task<List<Product>> GetAllAsync()
    {
        return Task.Run(() =>
        {
            using var connection = OpenConnection();

            string sql = @"SELECT * FROM [dbo].[Products] WHERE SoftDelete = 0";

            return connection.Query<Product>(sql).ToList();
        });
    }

    public Task<Product> GetAsync(int id)
    {
        return Task.Run(() =>
        {
            using var connection = OpenConnection();

            

            string productSql = $"SELECT * FROM [dbo].[Products] product WHERE product.Id = {id}";

            string propertySql = @$"SELECT * FROM [dbo].[ProductProperties] property 
                                    INNER JOIN [dbo].[MeasureUnits] unit ON property.MeasureUnitId = unit.Id 
                                    WHERE property.ProductId = {id}";

            Product product =  connection.QueryFirstOrDefault<Product>(productSql);

            List<ProductProperty> productProperties = connection.Query<ProductProperty, MeasureUnit, ProductProperty>(propertySql, (x, y) =>
            {
                x.MeasureUnit = y;
                return x;
            }).ToList();

            product.ProductProperties = productProperties;

            

            return product;            
        });
        
    }

   
    public Task SetProductPropertyToDefaultAsync(int productId, int measureUnitId, bool isDefault)
    {
        return Task.Run(() =>
        {
            using var connection = OpenConnection();

            var transaction = connection.BeginTransaction();

            connection.Execute(@$"UPDATE ProductProperties SET IsDefault = @isDefault
                                  WHERE ProductId = {productId} AND MeasureUnitId = {measureUnitId}");

            if (isDefault == true)
            {
                connection.Execute(@$"UPDATE ProductProperties SET IsDefault = 0 
                                      WHERE ProductId = {productId} AND MeasureUnitId != {measureUnitId}");
            }

            transaction.Commit();
        });
        
    }

    public Task UpdateAsync(Product entity,ProductProperty productProperty)
    {
        return Task.Run(() =>
        {
            using var connection = OpenConnection();

            var transaction = connection.BeginTransaction();

            connection.Execute(@"UPDATE Products SET Name = @Name WHERE Id = @Id

                                 UPDATE ProductProperties SET MeasureUnitId = @MeasureUnitId, PurchasePrice=@PurchasePrice,
                                 SellingPrice = @SellingPrice, GrossPrice = @GrossPrice WHERE ProductId = @Id ",

                                 new{entity.Id,entity.Name,productProperty.MeasureUnitId,productProperty.PurchasePrice
                                 ,productProperty.SellingPrice,productProperty.GrossPrice,productProperty.ProductId});

            transaction.Commit();
        });
    }

    
}
