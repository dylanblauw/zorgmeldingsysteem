using ZorgmeldSysteem.Application.DTOs.Ticket;
using ZorgmeldSysteem.Domain.Enums;

namespace ZorgmeldSysteem.Application.Interfaces.IServices;

public interface ITicketService
{
    // Haal één ticket op
    Task<TicketDto?> GetByIdAsync(int id);  

    // Zoek op ticketcode
    Task<TicketDto?> GetByTicketCodeAsync(string ticketCode);  

    // Haal alle tickets op
    Task<IEnumerable<TicketDto>> GetAllAsync();

    // Maak nieuwe ticket
    Task<TicketDto> CreateAsync(CreateTicketDto createDto);  

    // Update bestaande ticket
    Task<TicketDto> UpdateAsync(int id, UpdateTicketDto updateDto); 

    // Verwijder ticket
    Task DeleteAsync(int id);

    // Haal tickets op per bedrijf
    Task<IEnumerable<TicketDto>> GetByCompanyIdAsync(int companyId);

    // Haal tickets op per monteur
    Task<IEnumerable<TicketDto>> GetByMechanicIdAsync(int mechanicId);

    // Haal tickets op per status
    Task<IEnumerable<TicketDto>> GetByStatusAsync(TicketStatus status);

    // Haal open tickets op
    Task<IEnumerable<TicketDto>> GetOpenTicketsAsync();

    // Wijs een monteur toe aan een ticket
    Task<bool> AssignMechanicAsync(int ticketId, int mechanicId);  

    // Update de status van een ticket
    Task<bool> UpdateStatusAsync(int ticketId, TicketStatus newStatus);  
}