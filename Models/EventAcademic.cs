using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace sbelt.Models
{
        [Table("eventacademics")]
    public class EventAcademic
    {
        [Key]

        public int Id { get; set; }
        public string? Nome { get; set; }
    }
}
