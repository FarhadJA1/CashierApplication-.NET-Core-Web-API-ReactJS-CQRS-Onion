using A.Domain.Common;
using A.Domain.Enum;

namespace A.Domain.Entities;
public class ImportInvoice : InvoiceBase
{
    public override InvoiceType InvoiceType => InvoiceType.Import;
}
