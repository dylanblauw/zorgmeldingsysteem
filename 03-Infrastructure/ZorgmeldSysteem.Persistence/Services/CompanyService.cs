using ZorgmeldSysteem.Application.Interfaces.IServices;
using ZorgmeldSysteem.Application.DTOs.Company;
using ZorgmeldSysteem.Domain.Entities;
using ZorgmeldSysteem.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ZorgmeldSysteem.Persistence.Services;

public class CompanyService : ICompanyService
{
    private readonly ZorgmeldContext _context;

    public CompanyService(ZorgmeldContext context)
    {
        _context = context;
    }

    public async Task<CompanyDto?> GetByIdAsync(int id)
    {
        Company? company = await _context.Companies.FindAsync(id);

        if (company == null)
        {
            return null;
        }

        return MapToDto(company);
    }

    public async Task<IEnumerable<CompanyDto>> GetAllAsync()
    {
        List<Company> companies = await _context.Companies.ToListAsync();

        List<CompanyDto> result = new List<CompanyDto>();
        foreach (Company company in companies)
        {
            result.Add(MapToDto(company));
        }

        return result;
    }

    public async Task<CompanyDto> CreateAsync(CreateCompanyDto createDto)
    {
        Company company = new Company
        {
            Name = createDto.Name,
            Email = createDto.Email,
            Phonenumber = createDto.Phonenumber,
            Street = createDto.Street,
            HouseNumber = createDto.HouseNumber,
            HouseNumberAddition = createDto.HouseNumberAddition,
            PostalCode = createDto.PostalCode,
            City = createDto.City,
            Province = createDto.Province,
            Country = createDto.Country,
            Contact = createDto.Contact,
            IsExternal = createDto.IsExternal,
            CreatedBy = createDto.CreatedBy,
            CreatedOn = DateTime.Now
        };

        await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync();

        return MapToDto(company);
    }

    public async Task<CompanyDto> UpdateAsync(int id, UpdateCompanyDto updateDto)
    {
        Company? company = await _context.Companies.FindAsync(id);

        if (company == null)
        {
            throw new Exception($"Bedrijf met id {id} niet gevonden");
        }

        if (updateDto.Name != null)
            company.Name = updateDto.Name;

        if (updateDto.Email != null)
            company.Email = updateDto.Email;

        if (updateDto.Phonenumber != null)
            company.Phonenumber = updateDto.Phonenumber;

        if (updateDto.Street != null)
            company.Street = updateDto.Street;

        if (updateDto.HouseNumber != null)
            company.HouseNumber = updateDto.HouseNumber;

        if (updateDto.HouseNumberAddition != null)
            company.HouseNumberAddition = updateDto.HouseNumberAddition;

        if (updateDto.PostalCode != null)
            company.PostalCode = updateDto.PostalCode;

        if (updateDto.City != null)
            company.City = updateDto.City;

        if (updateDto.Province != null)
            company.Province = updateDto.Province;

        if (updateDto.Country != null)
            company.Country = updateDto.Country;

        if (updateDto.Contact != null)
            company.Contact = updateDto.Contact;

        if (updateDto.IsExternal.HasValue)
            company.IsExternal = updateDto.IsExternal.Value;

        company.ChangedBy = updateDto.ChangedBy;
        company.ChangedOn = DateTime.Now;

        _context.Companies.Update(company);
        await _context.SaveChangesAsync();

        return MapToDto(company);
    }

    public async Task DeleteAsync(int id)
    {
        Company? company = await _context.Companies.FindAsync(id);

        if (company == null)
        {
            throw new Exception($"Bedrijf met id {id} niet gevonden");
        }

        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<CompanyDto>> GetExternalCompaniesAsync()
    {
        List<Company> companies = await _context.Companies.ToListAsync();

        List<CompanyDto> result = new List<CompanyDto>();
        foreach (Company company in companies)
        {
            if (company.IsExternal)
            {
                result.Add(MapToDto(company));
            }
        }

        return result;
    }

    private CompanyDto MapToDto(Company company)
    {
        return new CompanyDto
        {
            CompanyID = company.CompanyID,
            Name = company.Name,
            Email = company.Email,
            Phonenumber = company.Phonenumber,
            Street = company.Street,
            HouseNumber = company.HouseNumber,
            HouseNumberAddition = company.HouseNumberAddition,
            PostalCode = company.PostalCode,
            City = company.City,
            Province = company.Province,
            Country = company.Country,
            Contact = company.Contact,
            IsExternal = company.IsExternal
        };
    }
}