using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sbelt.Models
{
    public class Certificado
    {
        public int Id { get; set; } // Chave primária do Certificado

        public string? Key { get; set; } // Campo para armazenar a chave

        public float? Conclusao { get; set; } // Campo para armazenar a conclusão do certificado

        // Chave estrangeira para a tabela Matricula
        public int MatriculaId { get; set; } // MatriculaId como chave estrangeira

        // Relacionamento com a tabela Matricula
        [ForeignKey("MatriculaId")] // Explicitando o relacionamento com a chave estrangeira
        public virtual Matricula Matricula { get; set; }
    }
}
