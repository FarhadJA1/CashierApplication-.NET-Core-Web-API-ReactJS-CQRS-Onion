using A.Domain.Common;
using B.Repository.Data;
using B.Repository.Repositories.Interfaces;

namespace B.Repository.Repositories.Implementations
{
    public class InvoiceRepository : IInvoiceRepository
    {

        public Task CreateAsync(InvoiceBase entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(InvoiceBase entity)
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

        public Task UpdateAsync(InvoiceBase entity)
        {
            throw new NotImplementedException();
        }
    }
}
