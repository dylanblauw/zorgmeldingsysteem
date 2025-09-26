using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorgmeldSysteem.Domain.Enums
{
    public enum MechanicType
    {
        [Display(Name = "Interne monteur")]
        InternalGeneral = 1,

        [Display(Name = "Interne elektricien")]
        InternalElectrical = 2,

        [Display(Name = "Interne loodgieter")]
        InternalPlumbing = 3,

        [Display(Name = "Interne HVAC monteur")]
        InternalHVAC = 4,

        [Display(Name = "Externe elektricien")]
        ExternalElectrical = 5,

        [Display(Name = "Externe loodgieter")]
        ExternalPlumbing = 6,

        [Display(Name = "Externe HVAC specialist")]
        ExternalHVAC = 7,

        [Display(Name = "Externe schoonmaakbedrijf")]
        ExternalCleaning = 8,

        [Display(Name = "Externe beveiligingsbedrijf")]
        ExternalSecurity = 9,

        [Display(Name = "Externe IT support")]
        ExternalIT = 10,

        [Display(Name = "Externe monteur")]
        ExternalGeneral = 11
    }
}
