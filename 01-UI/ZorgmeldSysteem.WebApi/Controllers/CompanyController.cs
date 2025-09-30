using Microsoft.AspNetCore.Mvc;
using ZorgmeldSysteem.Application.Interfaces.IServices;
using ZorgmeldSysteem.Application.DTOs.Company;

namespace ZorgmeldSysteem.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    // GET: api/company
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<CompanyDto> companies = await _companyService.GetAllAsync();
        return Ok(companies);
    }

    // GET: api/company/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        CompanyDto? company = await _companyService.GetByIdAsync(id);

        if (company == null)
        {
            return NotFound($"Bedrijf met id {id} niet gevonden");
        }

        return Ok(company);
    }

    // GET: api/company/external
    [HttpGet("external")]
    public async Task<IActionResult> GetExternal()
    {
        IEnumerable<CompanyDto> companies = await _companyService.GetExternalCompaniesAsync();
        return Ok(companies);
    }

    // POST: api/company
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCompanyDto createDto)
    {
        try
        {
            CompanyDto company = await _companyService.CreateAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = company.CompanyID }, company);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT: api/company/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCompanyDto updateDto)
    {
        try
        {
            CompanyDto company = await _companyService.UpdateAsync(id, updateDto);
            return Ok(company);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE: api/company/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _companyService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}