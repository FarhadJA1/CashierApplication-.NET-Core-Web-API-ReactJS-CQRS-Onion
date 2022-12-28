using A.Domain.Common;
using A.Domain.Enum;
using Domain.Entities;

namespace A.Domain.Entities
{
    public class ReturnInvoice : InvoiceBase
    {
        public override InvoiceType InvoiceType => InvoiceType.Return;
    }
}
