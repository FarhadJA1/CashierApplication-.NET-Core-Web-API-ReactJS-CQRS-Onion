using A.Domain.Common;
using A.Domain.Entities;
using A.Domain.Enum;
using B.Repository.Repositories.Interfaces;
using Dapper;
using Domain.Entities;

namespace B.Repository.Repositories.Implementations;
public class InvoiceRepository : BaseSqlRepository , IInvoiceRepository
{
    public Task CreateAsync(InvoiceBase entity, InvoiceDetail invoiceDetail)
    {
        using var connection = OpenConnection();

        int invoiceId = connection.QuerySingle<int>(@"INSERT INTO [dbo].[Invoices] 
                                                        ([CreateDate],[UserId],[CustomerId],[InvoiceType])
                                                      OUTPUT Inserted.Id
                                                      VALUES (@CreationDate,@UserId,@CustomerId,@InvoiceType)",
                                                      new { entity.CreationDate,entity.UserId,entity.CustomerId ,
                                                            entity.InvoiceType});

        connection.Query<InvoiceBase>(@"INSERT INTO [dbo].[InvoiceDetails] 
                                          ([InvoiceId],[ProductId],[Price],[MeasureId],[Quantity])
                                        VALUES (@invoiceId,@productId,@Price,@MeasureId,@Quantity)"
                                        , new { invoiceId,invoiceDetail.ProductId, invoiceDetail.Price 
                                        ,invoiceDetail.MeasureId, invoiceDetail.Quantity});
        return Task.CompletedTask;
    }
    

    public Task<List<VwInvoice>> GetAllAsync(InvoiceType? type=null)
    {
        using var connection = OpenConnection();

        if (type == null)
        {
            string sql = @"SELECT Id Id,CreateDate CreationDate,UserId UserId,CustomerId CustomerId,InvoiceType InvoiceTypePtr 
                           FROM [dbo].[Invoices]";
            List<VwInvoice> invoices = connection.Query<VwInvoice>(sql).ToList();

            return Task.FromResult(invoices);
        }
        else
        {
            string sql = @"SELECT Id Id,CreateDate CreationDate,UserId UserId,CustomerId CustomerId,InvoiceType InvoiceTypePtr 
                           FROM [dbo].[Invoices]                           
                           WHERE InvoiceType = @type";
            List<VwInvoice> invoices = connection.Query<VwInvoice>(sql,new { type }).ToList();

            return Task.FromResult(invoices);
        }
    }

    public Task<List<InvoiceDetail>> GetInvoiceDetailsAsync(int id)
    {
        using var connection = OpenConnection();

        string sql = @"SELECT * FROM [dbo].[InvoiceDetails] detail
                       WHERE detail.InvoiceId = @id";

        List<InvoiceDetail> invoiceDetails = connection.Query<InvoiceDetail>(sql,new {id}).ToList();

        return Task.FromResult(invoiceDetails);
    }

    
}
