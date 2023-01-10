using A.Domain.Common;
using A.Domain.Entities;
using A.Domain.Enum;
using B.Repository.Repositories.Interfaces;
using Dapper;
using Domain.Entities;
using Microsoft.Data.SqlClient;

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
            string sql = @"SELECT * 
                           FROM [dbo].[Invoices]";
            List<VwInvoice> invoices = connection.Query<VwInvoice, List<InvoiceDetail>, VwInvoice>(sql, (m, y) =>
            {
                m.Details = y;
                return m;
            }).ToList();

            return Task.FromResult(invoices);
        }
        else
        {
            string sql = @"SELECT * FROM [dbo].[Invoices] invoice INNER JOIN [dbo].[InvoiceDetails] detail 
                           ON invoice.Id = detail.InvoiceId
                           WHERE invoice.InvoiceType = @type";
            List<VwInvoice> invoices = connection.Query<VwInvoice, List<InvoiceDetail>, VwInvoice>(sql, (m, y) =>
            {
                m.Details = y;
                return m;
            }, new { type }).ToList();

            return Task.FromResult(invoices);
        }
    }

    public Task<InvoiceBase> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    
}
