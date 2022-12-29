using AutoMapper;
using C.Service.DTOs.CustomerDTOs;
using Domain.Entities;

namespace C.Service.Mappings;
public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Customer, CustomerGetDTO>();
	}
}
