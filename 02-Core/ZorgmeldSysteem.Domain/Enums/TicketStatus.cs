using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorgmeldSysteem.Domain.Enums
{
    public enum TicketStatus
    {
        [Display(Name = "Open")]
        Open = 1,

        [Display(Name = "Toegewezen")]
        Assigned = 2,

        [Display(Name = "In behandeling")]
        InProgress = 3,

        [Display(Name = "Wacht op klant")]
        PendingCustomer = 4,

        [Display(Name = "Wacht op leverancier")]
        PendingSupplier = 5,

        [Display(Name = "Wacht op onderdelen")]
        AwaitingParts = 6,

        [Display(Name = "On hold")]
        OnHold = 7,

        [Display(Name = "Opgelost")]
        Solved = 8,

        [Display(Name = "Gesloten")]
        Closed = 9,

        [Display(Name = "Geannuleerd")]
        Cancelled = 10
    }
}
