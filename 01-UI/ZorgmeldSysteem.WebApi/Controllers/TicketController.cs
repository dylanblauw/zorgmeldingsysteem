using Microsoft.AspNetCore.Mvc;
using ZorgmeldSysteem.Application.Interfaces.IServices;
using ZorgmeldSysteem.Application.DTOs.Ticket;
using ZorgmeldSysteem.Domain.Enums;

namespace ZorgmeldSysteem.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    // GET: api/ticket
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<TicketDto> tickets = await _ticketService.GetAllAsync();
        return Ok(tickets);
    }

    // GET: api/ticket/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        TicketDto? ticket = await _ticketService.GetByIdAsync(id);

        if (ticket == null)
        {
            return NotFound($"Ticket met id {id} niet gevonden");
        }

        return Ok(ticket);
    }

    // GET: api/ticket/code/TK-2025-0001
    [HttpGet("code/{ticketCode}")]
    public async Task<IActionResult> GetByTicketCode(string ticketCode)
    {
        TicketDto? ticket = await _ticketService.GetByTicketCodeAsync(ticketCode);

        if (ticket == null)
        {
            return NotFound($"Ticket met code {ticketCode} niet gevonden");
        }

        return Ok(ticket);
    }

    // GET: api/ticket/company/5
    [HttpGet("company/{companyId}")]
    public async Task<IActionResult> GetByCompanyId(int companyId)
    {
        IEnumerable<TicketDto> tickets = await _ticketService.GetByCompanyIdAsync(companyId);
        return Ok(tickets);
    }

    // GET: api/ticket/mechanic/3
    [HttpGet("mechanic/{mechanicId}")]
    public async Task<IActionResult> GetByMechanicId(int mechanicId)
    {
        IEnumerable<TicketDto> tickets = await _ticketService.GetByMechanicIdAsync(mechanicId);
        return Ok(tickets);
    }

    // GET: api/ticket/status/1
    [HttpGet("status/{status}")]
    public async Task<IActionResult> GetByStatus(TicketStatus status)
    {
        IEnumerable<TicketDto> tickets = await _ticketService.GetByStatusAsync(status);
        return Ok(tickets);
    }

    // GET: api/ticket/open
    [HttpGet("open")]
    public async Task<IActionResult> GetOpen()
    {
        IEnumerable<TicketDto> tickets = await _ticketService.GetOpenTicketsAsync();
        return Ok(tickets);
    }

    // POST: api/ticket
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTicketDto createDto)
    {
        try
        {
            TicketDto ticket = await _ticketService.CreateAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = ticket.TicketID }, ticket);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT: api/ticket/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTicketDto updateDto)
    {
        try
        {
            TicketDto ticket = await _ticketService.UpdateAsync(id, updateDto);
            return Ok(ticket);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE: api/ticket/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _ticketService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PATCH: api/ticket/5/assign/3
    [HttpPatch("{ticketId}/assign/{mechanicId}")]
    public async Task<IActionResult> AssignMechanic(int ticketId, int mechanicId)
    {
        bool success = await _ticketService.AssignMechanicAsync(ticketId, mechanicId);

        if (!success)
        {
            return NotFound("Ticket of Monteur niet gevonden");
        }

        return Ok("Monteur succesvol toegewezen");
    }

    // PATCH: api/ticket/5/status
    [HttpPatch("{ticketId}/status")]
    public async Task<IActionResult> UpdateStatus(int ticketId, [FromBody] TicketStatus newStatus)
    {
        bool success = await _ticketService.UpdateStatusAsync(ticketId, newStatus);

        if (!success)
        {
            return NotFound($"Ticket met id {ticketId} niet gevonden");
        }

        return Ok("Status succesvol bijgewerkt");
    }
}