namespace ZorgmeldSysteem.Application.DTOs.Company;

public class UpdateCompanyDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phonenumber { get; set; }
    public string? Adress { get; set; }
    public string? Contact { get; set; }
    public bool? IsExternal { get; set; }
    public string ChangedBy { get; set; } = string.Empty;
}