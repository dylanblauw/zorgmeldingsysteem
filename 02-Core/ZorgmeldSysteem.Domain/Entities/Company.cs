using System.ComponentModel.DataAnnotations;

namespace ZorgmeldSysteem.Domain.Entities
{
    public class Company
    {

        [Key]
        public int CompanyID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Phonenumber { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Adress { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Contact { get; set; } = string.Empty;

        public bool IsExternal { get; set; } = false;

        // Audit fields
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? ChangedOn { get; set; }
        public string ChangedBy { get; set; } = string.Empty;

        // Navigation properties
        public List<Ticket> Tickets { get; set; } = new();
        public List<Mechanic> Mechanics { get; set; } = new();
        public List<Objects> Objects { get; set; } = new();
    }
}


