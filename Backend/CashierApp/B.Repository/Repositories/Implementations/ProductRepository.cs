using B.Repository.Repositories.Interfaces;
using C.Repository.Exceptions;
using Dapper;
using Domain.Entities;
using static Dapper.SqlMapper;

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

    public Task CreateProductProperties(ProductProperty productProperty)
    {
        return Task.Run(() =>
        {
            using var connection = OpenConnection();

            string sql = @"INSERT INTO [dbo].[ProductProperties] ([ProductId],[MeasureUnitId],[Barcode],[PurchasePrice]
                                                                 ,[SellingPrice],[GrossPrice],[IsDefault])
                                                          VALUES (@ProductId,@MeasureUnitId,@Barcode,@PurchasePrice,@SellingPrice,@GrossPrice,0)";

            connection.Execute(sql, new { productProperty.ProductId, productProperty.Barcode,productProperty.MeasureUnitId
                                         ,productProperty.PurchasePrice, productProperty.SellingPrice,productProperty.GrossPrice });
        });
    }

    public Task DeleteAsync(int id)
    {
        return Task.Run(() =>
        {
            using var connection = OpenConnection();
            var dbTransaction = connection.BeginTransaction();
            connection.Execute(@$"UPDATE Products SET SoftDelete = 1 WHERE Id = {id} 
                                  DELETE FROM ProductProperties WHERE ProductId = {id}",transaction: dbTransaction);
            dbTransaction.Commit();
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
            
            string productSql = $"SELECT * FROM [dbo].[Products] product WHERE product.Id = {id} AND SoftDelete = 0";

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

            
                        
            if (isDefault == true)
            {
                var dbTransaction = connection.BeginTransaction();

                connection.Execute(@$"UPDATE ProductProperties SET IsDefault = 1
                                      WHERE ProductId = {productId} AND MeasureUnitId = {measureUnitId}

                                      UPDATE ProductProperties SET IsDefault = 0 
                                      WHERE ProductId = {productId} AND MeasureUnitId != {measureUnitId}", transaction: dbTransaction);


                dbTransaction.Commit();
            }
            else
            {
                connection.Execute(@$"UPDATE ProductProperties SET IsDefault = 0
                                  WHERE ProductId = {productId} AND MeasureUnitId = {measureUnitId}");
            }

            
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
                                 ,productProperty.SellingPrice,productProperty.GrossPrice,productProperty.ProductId},transaction);

            transaction.Commit();
        });
    }

    public  Task<ProductProperty> GetProductPropertiesByUnitId(int productId, int measureUnitId)
    {
        return Task.Run(() =>
        {
            using var connection = OpenConnection();

            string propertySql = @$"SELECT * FROM [dbo].[ProductProperties] property                                     
                                    WHERE property.ProductId = {productId} AND property.MeasureUnitId = {measureUnitId}";

            var result = connection.QueryFirstOrDefault<ProductProperty>(propertySql);

            if (result == null)
                throw new InvalidClientOperationException("No Product Property were found");

            return result;
        });       
    }


}
