using C.Service.DTOs.MeasureUnitDTOs;

namespace C.Service.Services.Interfaces;
public interface IMeasureUnitService
{
    Task CreateAsync(CreateMeasureUnitDTO createMeasureUnitDTO);
    Task<List<GetMeasureUnitDTO>> GetAllAsync();
    Task<GetMeasureUnitDTO> GetByIdAsync(int id);
    Task DeleteAsync(int id);
    Task UpdateAsync(int id, UpdateMeasureUnitDTO updateMeasureUnitDTO);
}
