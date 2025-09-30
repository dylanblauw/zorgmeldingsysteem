using ZorgmeldSysteem.Application.DTOs.Company;

namespace ZorgmeldSysteem.Application.Interfaces.IServices;

public interface ICompanyService
{
    Task<CompanyDto?> GetByIdAsync(int id);
    Task<IEnumerable<CompanyDto>> GetAllAsync();
    Task<CompanyDto> CreateAsync(CreateCompanyDto createDto);
    Task<CompanyDto> UpdateAsync(int id, UpdateCompanyDto updateDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<CompanyDto>> GetExternalCompaniesAsync();
}