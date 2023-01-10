using A.Domain.Common;
using A.Domain.Enum;

namespace A.Domain.Entities;
public class VwInvoice : InvoiceBase
{
    private InvoiceType _invoiceType;
    public override InvoiceType InvoiceType => _invoiceType;

    public InvoiceType InvoiceTypePtr 
    { 
        get
        {
            return _invoiceType;
        } 
        set
        {
            _invoiceType = value;
        }
    }
}
