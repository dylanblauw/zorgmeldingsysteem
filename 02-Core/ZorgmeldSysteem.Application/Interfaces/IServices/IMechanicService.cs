using ZorgmeldSysteem.Application.DTOs.Mechanic;
using ZorgmeldSysteem.Domain.Enums;

namespace ZorgmeldSysteem.Application.Interfaces.IServices;

public interface IMechanicService
{
    Task<MechanicDto?> GetByIdAsync(int id);
    Task<IEnumerable<MechanicDto>> GetAllAsync();
    Task<MechanicDto> CreateAsync(CreateMechanicDto createDto);
    Task<MechanicDto> UpdateAsync(int id, UpdateMechanicDto updateDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<MechanicDto>> GetActiveAsync();
    Task<IEnumerable<MechanicDto>> GetByTypeAsync(MechanicType type);
}