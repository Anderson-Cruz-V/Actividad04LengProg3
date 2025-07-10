using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg3.Models
{
    public class Materia
    {
        [Key]
        [Required]
        public string Codigo { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required, Range(1, 10)]
        public int Creditos { get; set; }

        [Required]
        public string Carrera { get; set; } = string.Empty;
    }
}
