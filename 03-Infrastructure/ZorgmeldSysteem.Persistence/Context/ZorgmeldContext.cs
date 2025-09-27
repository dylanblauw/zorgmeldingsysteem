using Microsoft.EntityFrameworkCore;
using ZorgmeldSysteem.Domain.Entities;

namespace ZorgmeldSysteem.Persistence.Context
{
    public class ZorgmeldContext : DbContext
    {
        public ZorgmeldContext(DbContextOptions<ZorgmeldContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<Objects> Objects { get; set; }
    }
}