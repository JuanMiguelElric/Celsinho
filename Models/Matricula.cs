using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sbelt.Models
{
    public class Matricula
    {
        [Key]
        public int Id { get; set; } // Usando Pascal Case para a propriedade Id  

        [ForeignKey("ApplicationUser")] // Definindo a chave estrangeira  
        public int User_id { get; set; } // Usando Pascal Case e removendo sublinhado  

        [ForeignKey("EventAcademic")] // Definindo a chave estrangeira  
        public int EventAcademicId { get; set; } // Usando Pascal Case  

        // Propriedade de navegação  
        public virtual ApplicationUser User { get; set; } // Propriedade de navegação para User  
        public virtual EventAcademic EventAcademic { get; set; } // Propriedade de navegação para EventAcademic
                                                                 // 
        public virtual ICollection<Certificado> Certificados { get; set; }=new List<Certificado>();
    }//
}