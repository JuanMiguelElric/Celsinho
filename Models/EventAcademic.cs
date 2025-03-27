using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sbelt.Models
{
    [Table("eventacademics")]
    public class EventAcademic
    {
        [Key]
        public int Id { get; set; }

        public string? Nome { get; set; } // ou public string Name { get; set; }  

        // Inicializando a coleção  
        public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
    }
}