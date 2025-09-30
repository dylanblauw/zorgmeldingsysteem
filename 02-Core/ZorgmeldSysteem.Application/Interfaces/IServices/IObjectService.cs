using ZorgmeldSysteem.Application.DTOs.Object;

namespace ZorgmeldSysteem.Application.Interfaces.IServices;

public interface IObjectService
{
    Task<ObjectDto?> GetByIdAsync(int id);
    Task<ObjectDto?> GetByObjectCodeAsync(string objectCode);
    Task<IEnumerable<ObjectDto>> GetAllAsync();
    Task<ObjectDto> CreateAsync(CreateObjectDto createDto);
    Task<ObjectDto> UpdateAsync(int id, UpdateObjectDto updateDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<ObjectDto>> GetByCompanyIdAsync(int companyId);
    Task<IEnumerable<ObjectDto>> GetDueForMaintenanceAsync();
}