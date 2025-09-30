using ZorgmeldSysteem.Application.Interfaces.IServices;
using ZorgmeldSysteem.Application.DTOs.Object;
using ZorgmeldSysteem.Domain.Entities;
using ZorgmeldSysteem.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ZorgmeldSysteem.Persistence.Services;

public class ObjectService : IObjectService
{
    private readonly ZorgmeldContext _context;

    public ObjectService(ZorgmeldContext context)
    {
        _context = context;
    }

    public async Task<ObjectDto?> GetByIdAsync(int id)
    {
        Objects? obj = await _context.Objects
            .Include(o => o.Company)
            .FirstOrDefaultAsync(o => o.ObjectID == id);

        if (obj == null)
        {
            return null;
        }

        return MapToDto(obj);
    }

    public async Task<ObjectDto?> GetByObjectCodeAsync(string objectCode)
    {
        Objects? obj = await _context.Objects
            .Include(o => o.Company)
            .FirstOrDefaultAsync(o => o.ObjectCode == objectCode);

        if (obj == null)
        {
            return null;
        }

        return MapToDto(obj);
    }

    public async Task<IEnumerable<ObjectDto>> GetAllAsync()
    {
        List<Objects> objects = await _context.Objects
            .Include(o => o.Company)
            .ToListAsync();

        List<ObjectDto> result = new List<ObjectDto>();
        foreach (Objects obj in objects)
        {
            result.Add(MapToDto(obj));
        }

        return result;
    }

    public async Task<ObjectDto> CreateAsync(CreateObjectDto createDto)
    {
        Objects obj = new Objects
        {
            ObjectCode = createDto.ObjectCode,
            Name = createDto.Name,
            Description = createDto.Description ?? string.Empty,
            Location = createDto.Location ?? string.Empty,
            Brand = createDto.Brand ?? string.Empty,
            Model = createDto.Model ?? string.Empty,
            SerialNumber = createDto.SerialNumber ?? string.Empty,
            InstallationDate = createDto.InstallationDate,
            NextMaintenance = createDto.NextMaintenance,
            CompanyID = createDto.CompanyID,
            CreatedBy = createDto.CreatedBy,
            CreatedOn = DateTime.Now
        };

        await _context.Objects.AddAsync(obj);
        await _context.SaveChangesAsync();

        Objects? savedObj = await _context.Objects
            .Include(o => o.Company)
            .FirstOrDefaultAsync(o => o.ObjectID == obj.ObjectID);

        return MapToDto(savedObj!);
    }

    public async Task<ObjectDto> UpdateAsync(int id, UpdateObjectDto updateDto)
    {
        Objects? obj = await _context.Objects.FindAsync(id);

        if (obj == null)
        {
            throw new Exception($"Object met id {id} niet gevonden");
        }

        if (updateDto.Name != null)
            obj.Name = updateDto.Name;

        if (updateDto.Description != null)
            obj.Description = updateDto.Description;

        if (updateDto.Location != null)
            obj.Location = updateDto.Location;

        if (updateDto.Brand != null)
            obj.Brand = updateDto.Brand;

        if (updateDto.Model != null)
            obj.Model = updateDto.Model;

        if (updateDto.SerialNumber != null)
            obj.SerialNumber = updateDto.SerialNumber;

        if (updateDto.LastMaintenance.HasValue)
            obj.LastMaintenance = updateDto.LastMaintenance;

        if (updateDto.NextMaintenance.HasValue)
            obj.NextMaintenance = updateDto.NextMaintenance;

        obj.ChangedBy = updateDto.ChangedBy;
        obj.ChangedOn = DateTime.Now;

        _context.Objects.Update(obj);
        await _context.SaveChangesAsync();

        Objects? updatedObj = await _context.Objects
            .Include(o => o.Company)
            .FirstOrDefaultAsync(o => o.ObjectID == id);

        return MapToDto(updatedObj!);
    }

    public async Task DeleteAsync(int id)
    {
        Objects? obj = await _context.Objects.FindAsync(id);

        if (obj == null)
        {
            throw new Exception($"Object met id {id} niet gevonden");
        }

        _context.Objects.Remove(obj);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ObjectDto>> GetByCompanyIdAsync(int companyId)
    {
        List<Objects> objects = await _context.Objects
            .Include(o => o.Company)
            .ToListAsync();

        List<ObjectDto> result = new List<ObjectDto>();
        foreach (Objects obj in objects)
        {
            if (obj.CompanyID == companyId)
            {
                result.Add(MapToDto(obj));
            }
        }

        return result;
    }

    public async Task<IEnumerable<ObjectDto>> GetDueForMaintenanceAsync()
    {
        DateTime today = DateTime.Now.Date;
        DateTime futureDate = today.AddDays(30);

        List<Objects> objects = await _context.Objects
            .Include(o => o.Company)
            .ToListAsync();

        List<ObjectDto> result = new List<ObjectDto>();
        foreach (Objects obj in objects)
        {
            if (obj.NextMaintenance.HasValue &&
                obj.NextMaintenance.Value.Date <= futureDate)
            {
                result.Add(MapToDto(obj));
            }
        }

        return result;
    }

    private ObjectDto MapToDto(Objects obj)
    {
        return new ObjectDto
        {
            ObjectID = obj.ObjectID,
            ObjectCode = obj.ObjectCode,
            Name = obj.Name,
            Description = obj.Description,
            Location = obj.Location,
            Brand = obj.Brand,
            Model = obj.Model,
            SerialNumber = obj.SerialNumber,
            InstallationDate = obj.InstallationDate,
            LastMaintenance = obj.LastMaintenance,
            NextMaintenance = obj.NextMaintenance,
            CompanyID = obj.CompanyID,
            CompanyName = obj.Company?.Name ?? string.Empty
        };
    }
}