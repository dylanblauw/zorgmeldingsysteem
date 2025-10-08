using Microsoft.AspNetCore.Mvc;
using ZorgmeldSysteem.Application.Interfaces.IServices;
using ZorgmeldSysteem.Application.DTOs.Object;

namespace ZorgmeldSysteem.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ObjectController : ControllerBase
{
    private readonly IObjectService _objectService;

    public ObjectController(IObjectService objectService)
    {
        _objectService = objectService;
    }

    // GET: api/object
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<ObjectDto> objects = await _objectService.GetAllAsync();
        return Ok(objects);
    }

    // GET: api/object/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        ObjectDto? obj = await _objectService.GetByIdAsync(id);

        if (obj == null)
        {
            return NotFound($"Object met id {id} niet gevonden");
        }

        return Ok(obj);
    }

    // GET: api/object/code/OBJ-001
    [HttpGet("code/{objectCode}")]
    public async Task<IActionResult> GetByObjectCode(string objectCode)
    {
        ObjectDto? obj = await _objectService.GetByObjectCodeAsync(objectCode);

        if (obj == null)
        {
            return NotFound($"Object met code {objectCode} niet gevonden");
        }

        return Ok(obj);
    }

    // GET: api/object/company/5
    [HttpGet("company/{companyId}")]
    public async Task<IActionResult> GetByCompanyId(int companyId)
    {
        IEnumerable<ObjectDto> objects = await _objectService.GetByCompanyIdAsync(companyId);
        return Ok(objects);
    }

    // GET: api/object/company/5/locations
    [HttpGet("company/{companyId}/locations")]
    public async Task<IActionResult> GetLocationsByCompanyId(int companyId)
    {
        IEnumerable<ObjectDto> objects = await _objectService.GetByCompanyIdAsync(companyId);

        // Haal unieke locaties op (niet-lege waarden)
        var locations = objects
            .Where(o => !string.IsNullOrWhiteSpace(o.Location))
            .Select(o => o.Location)
            .Distinct()
            .OrderBy(l => l)
            .ToList();

        return Ok(locations);
    }

    // GET: api/object/maintenance/due
    [HttpGet("maintenance/due")]
    public async Task<IActionResult> GetDueForMaintenance()
    {
        IEnumerable<ObjectDto> objects = await _objectService.GetDueForMaintenanceAsync();
        return Ok(objects);
    }

    // POST: api/object
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateObjectDto createDto)
    {
        try
        {
            ObjectDto obj = await _objectService.CreateAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = obj.ObjectID }, obj);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT: api/object/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateObjectDto updateDto)
    {
        try
        {
            ObjectDto obj = await _objectService.UpdateAsync(id, updateDto);
            return Ok(obj);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE: api/object/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _objectService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}