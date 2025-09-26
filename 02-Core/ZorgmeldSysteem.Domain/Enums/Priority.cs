using System.ComponentModel.DataAnnotations;

namespace ZMS.Models.Enums
{
    public enum Priority
    {
        [Display(Name = "Laag")]
        Low = 1,

        [Display(Name = "Normaal")]
        Normal = 2,

        [Display(Name = "Hoog")]
        High = 3,

        [Display(Name = "Urgent")]
        Urgent = 4,

        [Display(Name = "Kritiek")]
        Critical = 5
    }
}

