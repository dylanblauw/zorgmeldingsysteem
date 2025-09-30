﻿using Microsoft.AspNetCore.Mvc;
using ZorgmeldSysteem.Application.Interfaces.IServices;
using ZorgmeldSysteem.Application.DTOs.Mechanic;
using ZorgmeldSysteem.Domain.Enums;

namespace ZorgmeldSysteem.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MechanicController : ControllerBase
{
    private readonly IMechanicService _mechanicService;

    public MechanicController(IMechanicService mechanicService)
    {
        _mechanicService = mechanicService;
    }

    // GET: api/mechanic
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<MechanicDto> mechanics = await _mechanicService.GetAllAsync();
        return Ok(mechanics);
    }

    // GET: api/mechanic/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        MechanicDto? mechanic = await _mechanicService.GetByIdAsync(id);

        if (mechanic == null)
        {
            return NotFound($"Monteur met id {id} niet gevonden");
        }

        return Ok(mechanic);
    }

    // GET: api/mechanic/active
    [HttpGet("active")]
    public async Task<IActionResult> GetActive()
    {
        IEnumerable<MechanicDto> mechanics = await _mechanicService.GetActiveAsync();
        return Ok(mechanics);
    }

    // GET: api/mechanic/type/1
    [HttpGet("type/{type}")]
    public async Task<IActionResult> GetByType(MechanicType type)
    {
        IEnumerable<MechanicDto> mechanics = await _mechanicService.GetByTypeAsync(type);
        return Ok(mechanics);
    }

    // POST: api/mechanic
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMechanicDto createDto)
    {
        try
        {
            MechanicDto mechanic = await _mechanicService.CreateAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = mechanic.MechanicID }, mechanic);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT: api/mechanic/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateMechanicDto updateDto)
    {
        try
        {
            MechanicDto mechanic = await _mechanicService.UpdateAsync(id, updateDto);
            return Ok(mechanic);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE: api/mechanic/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _mechanicService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}