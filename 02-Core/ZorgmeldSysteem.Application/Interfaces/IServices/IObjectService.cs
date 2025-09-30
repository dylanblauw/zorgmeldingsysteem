using ZorgmeldSysteem.Application.DTOs.Mechanic;
using ZorgmeldSysteem.Application.DTOs.Object;

namespace ZorgmeldSysteem.Application.Interfaces.IServices;

public interface IObjectService
{
    Task GetByIdAsync(int id);
    Task GetByObjectCodeAsync(string objectCode);
    Task<IEnumerable<ObjectDto>> GetAllAsync();
    Task CreateAsync(CreateObjectDto createDto);
    Task UpdateAsync(int id, UpdateObjectDto updateDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<ObjectDto>> GetByCompanyIdAsync(int companyId);
    Task<IEnumerable<ObjectDto>> GetDueForMaintenanceAsync();
}