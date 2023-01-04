using A.Domain.Common;
using B.Repository.Repositories.Interfaces;
using Dapper;
using Domain.Entities;
using Microsoft.Data.SqlClient;

namespace B.Repository.Repositories.Implementations
{
    public class InvoiceRepository : IInvoiceRepository
    {

        public Task CreateAsync(InvoiceBase entity, InvoiceDetail invoiceDetail)
        {
            using SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-1NLMPNC\SQLEXPRESS01; initial Catalog=CashierDbDapper;
                                                            Integrated Security=True;");

            int productId = connection.QuerySingle<int>(@"INSERT INTO [dbo].[Invoices] ([CreateDate],[UserId],[CustomerId],[InvoiceType])
                                        OUTPUT Inserted.Id
                                        VALUES (@CreationDate,@UserId,@CustomerId,@InvoiceType)",
                                        new { entity.CreationDate,entity.UserId,entity.CustomerId ,entity.InvoiceType});

            connection.Query<InvoiceBase>(@"INSERT INTO [dbo].[InvoiceDetails] ([InvoiceId],[ProductId],[Price],[MeasureId],[Quantity]
                                            VALUES (@InvoiceId,@productId,@Price,@MeasureId,@Quantity))"
                                            , new { invoiceDetail.InvoiceId,productId, invoiceDetail.Price ,invoiceDetail.MeasureId, invoiceDetail.Quantity});
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<InvoiceBase>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceBase> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, InvoiceBase entity)
        {
            throw new NotImplementedException();
        }
    }
}
