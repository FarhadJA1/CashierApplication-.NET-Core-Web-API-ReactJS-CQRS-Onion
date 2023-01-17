using A.Domain.Common;
using A.Domain.Entities;
using A.Domain.Enum;
using B.Repository.Repositories.Interfaces;
using Dapper;
using Domain.Entities;


namespace B.Repository.Repositories.Implementations;
public class InvoiceRepository : BaseSqlRepository , IInvoiceRepository
{
    public Task CreateAsync(InvoiceBase entity)
    {
        return Task.Run(() => 
        {
            using var connection = OpenConnection();

            var transaction = connection.BeginTransaction();

            var sqlInsert = @"INSERT INTO [dbo].[Invoices] ([CreationDate],[UserId],[CustomerId],[InvoiceType]) 
                                OUTPUT Inserted.Id VALUES  (@CreationDate,@UserId,@CustomerId,@InvoiceType)";

            int invoiceId = connection.ExecuteScalar<int>(sqlInsert, new { entity.CreationDate, entity.UserId, entity.CustomerId, entity.InvoiceType }, transaction);
                       
            connection.Execute(@"INSERT INTO [dbo].[InvoiceDetails] ([InvoiceId],[ProductPropertiesId],[Price],[MeasureId],[Quantity])
                                            VALUES (@invoiceId,@ProductPropertiesId,@Price,@MeasureId,@Quantity)"
                                            , new{ invoiceId,entity.Details }, transaction);            

            transaction.Commit();
        });
    }
    

    public Task<List<VwInvoice>> GetAllAsync(InvoiceType? type=null)
    {
        return Task.Run(() =>
        {
            using var connection = OpenConnection();

            if (type == null)
            {
                string sql = @"SELECT Id Id,CreationDate CreationDate,UserId UserId,CustomerId CustomerId,InvoiceType InvoiceTypePtr 
                           FROM [dbo].[Invoices]";
                return connection.Query<VwInvoice>(sql).ToList();                
            }
            else
            {
                string sql = @"SELECT Id Id,CreateDate CreationDate,UserId UserId,CustomerId CustomerId,InvoiceType InvoiceTypePtr 
                           FROM [dbo].[Invoices]                           
                           WHERE InvoiceType = @type";

                return connection.Query<VwInvoice>(sql, new { type }).ToList();          
            }
        });
        
    }

    public Task<VwInvoice> GetInvoiceByCustomerAndUser(int customerId,int userId)
    {
        return Task.Run(() =>
        {
            using var connection = OpenConnection();

            string sql = @$"SELECT * FROM [dbo].[Invoices] i 
                            WHERE i.CustomerId = {customerId} AND i.userId = {userId}";

            return connection.QueryFirstOrDefault<VwInvoice>(sql);
        });
    }

    public Task<List<InvoiceDetail>> GetInvoiceDetailsAsync(int id)
    {
        using var connection = OpenConnection();

        string sql = @$"SELECT * FROM [dbo].[InvoiceDetails] detail
                       WHERE detail.InvoiceId = {id}";

        List<InvoiceDetail> invoiceDetails = connection.Query<InvoiceDetail>(sql).ToList();

        return Task.FromResult(invoiceDetails);
    }
}
