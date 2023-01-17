using A.Domain.Common;
using A.Domain.Entities;
using AutoMapper;
using C.Service.DTOs.AccountDtos;
using C.Service.DTOs.CustomerDTos;
using C.Service.DTOs.CustomerDTOs;
using C.Service.DTOs.InvoiceDTOs;
using C.Service.DTOs.MeasureUnitDTOs;
using C.Service.DTOs.ProductDTOs;
using Domain.Entities;

namespace C.Service.Mappings;
public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Customer, CustomerGetDTO>();
        CreateMap<Customer, CustomerUpdateDTO>().ReverseMap();
        CreateMap<Customer, CustomerCreateDTO>().ReverseMap();
        

        CreateMap<MeasureUnit, GetMeasureUnitDTO>();
        CreateMap<MeasureUnit, CreateMeasureUnitDTO>().ReverseMap();
        CreateMap<MeasureUnit, UpdateMeasureUnitDTO>().ReverseMap();
        CreateMap<MeasureUnit, ProductMeasureUnitGetDTO>();

        CreateMap<Product, CreateProductDTO>().ReverseMap();
        CreateMap<Product, ProductGetDTO>();
        CreateMap<ProductProperty, ProductPropertiesGetDto>();
        CreateMap<Product,UpdateProductDTO>().ReverseMap();
        CreateMap<ProductProperty,UpdateProductPropertiesDTO>().ReverseMap();

        CreateMap<ImportInvoice, CreateInvoiceDTO>().ReverseMap();
        CreateMap<ReturnInvoice, CreateInvoiceDTO>().ReverseMap();
        CreateMap<SellingInvoice, CreateInvoiceDTO>().ReverseMap();        
        CreateMap<VwInvoice,InvoiceGetDTO>();
        CreateMap<InvoiceDetail, InvoiceDetailsGetDTO>();
        CreateMap<InvoiceDetail,CreateInvoiceDetailsDTO>().ReverseMap();
            
        CreateMap<AppUser, LoginDto>();
    }
}
