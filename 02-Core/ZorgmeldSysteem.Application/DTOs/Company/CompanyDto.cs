namespace ZorgmeldSysteem.Application.DTOs.Company;

public class CompanyDto
{
    public int CompanyID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phonenumber { get; set; } = string.Empty;
    public string Adress { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
    public bool IsExternal { get; set; }
}