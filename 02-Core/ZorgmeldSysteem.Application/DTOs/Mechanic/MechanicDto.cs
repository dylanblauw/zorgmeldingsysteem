﻿using ZorgmeldSysteem.Domain.Enums;

namespace ZorgmeldSysteem.Application.DTOs.Mechanic;

public class MechanicDto
{
    public int MechanicID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phonenumber { get; set; } = string.Empty;
    public MechanicType Type { get; set; }
    public bool IsActive { get; set; }
    public int? CompanyID { get; set; }
    public string? CompanyName { get; set; }
}