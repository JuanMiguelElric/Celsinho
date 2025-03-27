using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sbelt.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Não é necessário declarar a propriedade Id, pois ela já está na classe IdentityUser
        // public string Id { get; set; }  // 'Id' já é do tipo string por padrão no IdentityUser

        // Propriedades adicionais se necessário
        public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
    }
}
