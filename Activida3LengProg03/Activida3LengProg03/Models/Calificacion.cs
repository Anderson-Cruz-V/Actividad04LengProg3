using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg3.Models
{
    public class Calificacion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string MatriculaEstudiante { get; set; } = string.Empty;

        [Required]
        public string CodigoMateria { get; set; } = string.Empty;

        [Required, Range(0, 100)]
        public int Nota { get; set; }

        [Required]
        public string Periodo { get; set; } = string.Empty;
    }
}
