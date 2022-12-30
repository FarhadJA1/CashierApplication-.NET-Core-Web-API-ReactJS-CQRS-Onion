using AutoMapper;
using C.Service.DTOs.CustomerDTos;
using C.Service.DTOs.CustomerDTOs;
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
    }
}
