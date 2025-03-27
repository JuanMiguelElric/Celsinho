using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace sbelt.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Id { get; set; } // ID do usuário  
        public string? UserName { get; set; } // Nome de usuário  
        public string? NormalizedUserName { get; set; } // Nome de usuário normalizado  
        public string? Email { get; set; } // Email do usuário  
        public string? NormalizedEmail { get; set; } // Email normalizado  
        public bool EmailConfirmed { get; set; } // Confirmação de email  
        public string? PasswordHash { get; set; } // Hash da senha  
        public string? SecurityStamp { get; set; } // Carimbo de segurança  
        public string? ConcurrencyStamp { get; set; } // Carimbo de concorrência  
        public string? PhoneNumber { get; set; } // Número de telefone  
        public bool PhoneNumberConfirmed { get; set; } // Confirmação do número de telefone  
        public bool TwoFactorEnabled { get; set; } // Habilitado para autenticação de dois fatores  
        public DateTimeOffset? LockoutEnd { get; set; } // Fim do bloqueio  
        public bool LockoutEnabled { get; set; } // Habilitar bloqueio  
        public int AccessFailedCount { get; set; } // Contador de falhas de acesso  

        public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
    }
}
