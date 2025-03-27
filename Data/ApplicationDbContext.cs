
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using sbelt.Models;

namespace sbelt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EventAcademic> Eventacademics { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        

    }
}
