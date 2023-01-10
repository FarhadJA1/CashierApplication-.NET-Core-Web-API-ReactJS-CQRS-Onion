using A.Domain.Common;
using A.Domain.Entities;
using A.Domain.Enum;
using AutoMapper;
using B.Repository.Repositories.Interfaces;
using C.Service.DTOs.InvoiceDTOs;
using C.Service.Services.Interfaces;
using Domain.Entities;

namespace C.Service.Services.Implementations;
public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IMapper _mapper;
    public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper)
    {
        _invoiceRepository = invoiceRepository;
        _mapper = mapper;
    }
    public async Task CreateInvoiceAsync(CreateInvoiceDTO createInvoice,CreateInvoiceDetailsDTO createInvoiceDetailsDTO)
    {
        switch (createInvoice.InvoiceType)
        {
            case 1:
                await _invoiceRepository.CreateAsync(_mapper.Map<SellingInvoice>(createInvoice)
                                            , _mapper.Map<InvoiceDetail>(createInvoiceDetailsDTO));
                break;
            case 2:
                await _invoiceRepository.CreateAsync(_mapper.Map<ReturnInvoice>(createInvoice)
                                           , _mapper.Map<InvoiceDetail>(createInvoiceDetailsDTO));
                break;
            case 3:
                await _invoiceRepository.CreateAsync(_mapper.Map<ImportInvoice>(createInvoice)
                                            , _mapper.Map<InvoiceDetail>(createInvoiceDetailsDTO));
                break;               
            default:
                throw new Exception("Bad Request");                
        }
    }

    public async Task<List<InvoiceGetDTO>> GetAllInvoicesAsync(InvoiceType? invoiceType = null)
    {
        List<VwInvoice> invoices = await _invoiceRepository.GetAllAsync(invoiceType);
        return _mapper.Map<List<InvoiceGetDTO>>(invoices);
    }
}
