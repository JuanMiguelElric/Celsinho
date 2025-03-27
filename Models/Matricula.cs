using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sbelt.Models
{
    [Table("Matricula")]
    public class Matricula
    {
        [Key]
        public int Id { get; set; } // Usando Pascal Case para a propriedade Id  

        [Required(ErrorMessage = "UserId é obrigatório")]
        [ForeignKey("ApplicationUser")]
        public string? UserId { get; set; }

        [Required(ErrorMessage = "EventAcademics_Id é obrigatório")]

        [ForeignKey("EventAcademic")] // Definindo a chave estrangeira  
        
        public int EventAcademics_Id { get; set; } // Usando Pascal Case  

        // Propriedade de navegação  
        public virtual ApplicationUser? User { get; set; } // Propriedade de navegação para User  
        public virtual EventAcademic? EventAcademic { get; set; } // Propriedade de navegação para EventAcademic
                                                                  // 
        public virtual ICollection<Certificado> Certificados { get; set; }=new List<Certificado>();
    }//
}