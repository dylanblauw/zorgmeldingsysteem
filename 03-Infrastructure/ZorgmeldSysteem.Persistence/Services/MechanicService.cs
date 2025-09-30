using ZorgmeldSysteem.Application.Interfaces.IServices;
using ZorgmeldSysteem.Application.DTOs.Mechanic;
using ZorgmeldSysteem.Domain.Entities;
using ZorgmeldSysteem.Domain.Enums;
using ZorgmeldSysteem.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ZorgmeldSysteem.Persistence.Services;

public class MechanicService : IMechanicService
{
    private readonly ZorgmeldContext _context;

    public MechanicService(ZorgmeldContext context)
    {
        _context = context;
    }

    public async Task<MechanicDto?> GetByIdAsync(int id)
    {
        Mechanic? mechanic = await _context.Mechanics
            .Include(m => m.Company)
            .FirstOrDefaultAsync(m => m.MechanicID == id);

        if (mechanic == null)
        {
            return null;
        }

        return MapToDto(mechanic);
    }

    public async Task<IEnumerable<MechanicDto>> GetAllAsync()
    {
        List<Mechanic> mechanics = await _context.Mechanics
            .Include(m => m.Company)
            .ToListAsync();

        List<MechanicDto> result = new List<MechanicDto>();
        foreach (Mechanic mechanic in mechanics)
        {
            result.Add(MapToDto(mechanic));
        }

        return result;
    }

    public async Task<MechanicDto> CreateAsync(CreateMechanicDto createDto)
    {
        Mechanic mechanic = new Mechanic
        {
            Name = createDto.Name,
            Email = createDto.Email,
            Phonenumber = createDto.Phonenumber,
            Type = createDto.Type,
            IsActive = createDto.IsActive,
            CompanyID = createDto.CompanyID,
            CreatedBy = createDto.CreatedBy,
            CreatedOn = DateTime.Now
        };

        await _context.Mechanics.AddAsync(mechanic);
        await _context.SaveChangesAsync();

        Mechanic? savedMechanic = await _context.Mechanics
            .Include(m => m.Company)
            .FirstOrDefaultAsync(m => m.MechanicID == mechanic.MechanicID);

        return MapToDto(savedMechanic!);
    }

    public async Task<MechanicDto> UpdateAsync(int id, UpdateMechanicDto updateDto)
    {
        Mechanic? mechanic = await _context.Mechanics.FindAsync(id);

        if (mechanic == null)
        {
            throw new Exception($"Monteur met id {id} niet gevonden");
        }

        if (updateDto.Name != null)
            mechanic.Name = updateDto.Name;

        if (updateDto.Email != null)
            mechanic.Email = updateDto.Email;

        if (updateDto.Phonenumber != null)
            mechanic.Phonenumber = updateDto.Phonenumber;

        if (updateDto.Type.HasValue)
            mechanic.Type = updateDto.Type.Value;

        if (updateDto.IsActive.HasValue)
            mechanic.IsActive = updateDto.IsActive.Value;

        if (updateDto.CompanyID.HasValue)
            mechanic.CompanyID = updateDto.CompanyID.Value;

        mechanic.ChangedBy = updateDto.ChangedBy;
        mechanic.ChangedOn = DateTime.Now;

        _context.Mechanics.Update(mechanic);
        await _context.SaveChangesAsync();

        Mechanic? updatedMechanic = await _context.Mechanics
            .Include(m => m.Company)
            .FirstOrDefaultAsync(m => m.MechanicID == id);

        return MapToDto(updatedMechanic!);
    }

    public async Task DeleteAsync(int id)
    {
        Mechanic? mechanic = await _context.Mechanics.FindAsync(id);

        if (mechanic == null)
        {
            throw new Exception($"Monteur met id {id} niet gevonden");
        }

        _context.Mechanics.Remove(mechanic);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<MechanicDto>> GetActiveAsync()
    {
        List<Mechanic> mechanics = await _context.Mechanics
            .Include(m => m.Company)
            .ToListAsync();

        List<MechanicDto> result = new List<MechanicDto>();
        foreach (Mechanic mechanic in mechanics)
        {
            if (mechanic.IsActive)
            {
                result.Add(MapToDto(mechanic));
            }
        }

        return result;
    }

    public async Task<IEnumerable<MechanicDto>> GetByTypeAsync(MechanicType type)
    {
        List<Mechanic> mechanics = await _context.Mechanics
            .Include(m => m.Company)
            .ToListAsync();

        List<MechanicDto> result = new List<MechanicDto>();
        foreach (Mechanic mechanic in mechanics)
        {
            if (mechanic.Type == type)
            {
                result.Add(MapToDto(mechanic));
            }
        }

        return result;
    }

    private MechanicDto MapToDto(Mechanic mechanic)
    {
        return new MechanicDto
        {
            MechanicID = mechanic.MechanicID,
            Name = mechanic.Name,
            Email = mechanic.Email,
            Phonenumber = mechanic.Phonenumber,
            Type = mechanic.Type,
            IsActive = mechanic.IsActive,
            CompanyID = mechanic.CompanyID,
            CompanyName = mechanic.Company?.Name
        };
    }
}