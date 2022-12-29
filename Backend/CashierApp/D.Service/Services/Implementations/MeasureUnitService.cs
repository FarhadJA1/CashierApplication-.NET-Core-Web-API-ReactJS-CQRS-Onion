using AutoMapper;
using B.Repository.Repositories.Implementations;
using B.Repository.Repositories.Interfaces;
using C.Service.DTOs.CustomerDTos;
using C.Service.DTOs.CustomerDTOs;
using C.Service.DTOs.MeasureUnitDTOs;
using C.Service.Services.Interfaces;
using Domain.Entities;

namespace C.Service.Services.Implementations;
public class MeasureUnitService : IMeasureUnitService
{
    private readonly IMeasureUnitRepository _measureUnitRepository;
    private readonly IMapper _mapper;
    public MeasureUnitService(IMeasureUnitRepository measureUnitRepository, IMapper mapper)
    {
        _measureUnitRepository = measureUnitRepository;
        _mapper = mapper;
    }
    public async Task CreateAsync(CreateMeasureUnitDTO createMeasureUnitDTO)
    {
        await _measureUnitRepository.CreateAsync(_mapper.Map<MeasureUnit>(createMeasureUnitDTO));
    }

    public async Task DeleteAsync(int id)
    {
        await _measureUnitRepository.DeleteAsync(id);
    }

    public async Task<List<GetMeasureUnitDTO>> GetAllAsync()
    {
        List<MeasureUnit> measureUnits = await _measureUnitRepository.GetAllAsync();
        return _mapper.Map<List<GetMeasureUnitDTO>>(measureUnits);
    }

    public async Task<GetMeasureUnitDTO> GetByIdAsync(int id)
    {
        MeasureUnit measureUnit = await _measureUnitRepository.GetAsync(id);
        return _mapper.Map<GetMeasureUnitDTO>(measureUnit);
    }

    public async Task UpdateAsync(int id, UpdateMeasureUnitDTO updateMeasureUnitDTO)
    {
        MeasureUnit measureUnit = new();
        _mapper.Map(updateMeasureUnitDTO, measureUnit);
        await _measureUnitRepository.UpdateAsync(id, measureUnit);
    }
}
