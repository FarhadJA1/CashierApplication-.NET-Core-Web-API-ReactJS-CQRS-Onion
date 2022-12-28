using A.Domain.Common;
using A.Domain.Enum;

namespace A.Domain.Entities;
public class SellingInvoice : InvoiceBase
{
    public override InvoiceType InvoiceType => InvoiceType.Selling;
}
