using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sbelt.Models
{
    [Table("eventacademics")]  // Mapeando a tabela para 'eventacademics'
    public class EventAcademic
    {
        [Key]  // Definindo a propriedade 'Id' como chave primária
        public int Id { get; set; }

        [Required]  // Tornando o campo 'Nome' obrigatório
        [MaxLength(256)]  // Limite de 256 caracteres para o nome
        public string? Nome { get; set; } // Nome do evento acadêmico

        // Inicializando a coleção de Matriculas
        public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
    }
}
