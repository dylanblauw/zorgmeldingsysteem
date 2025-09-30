using ZorgmeldSysteem.Application.DTOs.Mechanic;
using ZorgmeldSysteem.Domain.Enums;

namespace ZorgmeldSysteem.Application.Interfaces.IServices;

public interface IMechanicService
{
    Task GetByIdAsync(int id);
    Task<IEnumerable<MechanicDto>> GetAllAsync();
    Task CreateAsync(CreateMechanicDto createDto);
    Task UpdateAsync(int id, UpdateMechanicDto updateDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<MechanicDto>> GetActiveAsync();
    Task<IEnumerable<MechanicDto>> GetByTypeAsync(MechanicType type);
}