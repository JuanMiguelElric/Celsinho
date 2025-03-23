using System.ComponentModel.DataAnnotations;
namespace sbelt.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? email { get; set; }

        public string? password { get; set; }

    }
}
