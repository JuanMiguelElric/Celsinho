
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

        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Certificado> Certificado { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapeando a tabela Matricula com o nome correto
            modelBuilder.Entity<Matricula>()
                .ToTable("Matricula"); // Definindo explicitamente o nome da tabela

            // Outras configurações de modelagem, se necessário
        }

    }
}
