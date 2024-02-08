using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketProject.Models;

namespace TicketProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TicketSystemCategoryType> TicketSystemCategoryTypes { get; set; }
        public DbSet<TicketEntry> TicketEntries { get; set; }
    }
}
