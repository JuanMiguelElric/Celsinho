using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace sbelt.Models
{
    public class Certificado
    {
        public int Id { get; set; }

        public string? Key { get; set; }


        public float? Conclusao { get; set; }

       public virtual Matricula Matricula { get; set; }




    }
}
