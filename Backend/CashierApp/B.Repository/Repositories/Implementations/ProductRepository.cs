using B.Repository.Repositories.Interfaces;
using Dapper;
using Domain.Entities;
using Microsoft.Data.SqlClient;

namespace B.Repository.Repositories.Implementations;
public class ProductRepository : IProductRepository
{
    public Task CreateAsync(Product entity)
    {        
        using SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-1NLMPNC\SQLEXPRESS01; initial Catalog=CashierDbDapper;
                                                            Integrated Security=True;");

        connection.Query<Product>(@"INSERT INTO [dbo].[Products] ([Name], [Barcode])
                                    VALUES (@Name,@Barcode)",
                                    new { entity.Name, entity.Barcode});
       
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        using SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-1NLMPNC\SQLEXPRESS01; initial Catalog=CashierDbDapper;
                                                            Integrated Security=True;");
        connection.Query(@"DELETE FROM Products
                           WHERE Id = @id 
                           DELETE FROM ProductProperties
                           WHERE ProductId = @id", new { id });
        
        return Task.CompletedTask;
                                                      
    }

    public  Task<List<Product>> GetAllAsync()
    {
        using SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-1NLMPNC\SQLEXPRESS01; initial Catalog=CashierDbDapper;
                                                            Integrated Security=True;");

        string sql = @"SELECT * FROM [dbo].[ProductProperties] prop INNER JOIN [dbo].[Products] product ON prop.ProductId = product.Id";

        List<ProductProperty> productProperties = connection.Query<ProductProperty,Product, ProductProperty>(sql, (m,x) =>
        {         
            m.Product = x;
            return m;
        }).ToList();

        List<Product> products = new List<Product>();

        return Task.FromResult(MapListProductPropertyToProduct(products, productProperties));
    }

    public Task<Product> GetAsync(int id)
    {
        using SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-1NLMPNC\SQLEXPRESS01; initial Catalog=CashierDbDapper;
                                                            Integrated Security=True;");

        string sql = @"SELECT * FROM [dbo].[ProductProperties] prop 
                       INNER JOIN [dbo].[Products] product 
                       ON prop.ProductId = product.Id                        
                      ";

        List<ProductProperty> productProperties = connection.Query<ProductProperty, Product, ProductProperty>(sql, (m, x) =>
        {
            m.Product = x;
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


    public Task UpdateAsync(int id, Product entity)
    {
        throw new NotImplementedException();
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
