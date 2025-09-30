using ZorgmeldSysteem.Application.DTOs.Company;

namespace ZorgmeldSysteem.Application.Interfaces.IServices;

public interface ICompanyService
{
    Task GetByIdAsync(int id);
    Task<IEnumerable<CompanyDto>> GetAllAsync();
    Task CreateAsync(CreateCompanyDto createDto);
    Task UpdateAsync(int id, UpdateCompanyDto updateDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<CompanyDto>> GetExternalCompaniesAsync();
}