using System;
using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg3.Models
{
    public class Estudiante
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Nombre completo")]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required, StringLength(20, MinimumLength = 6)]
        [Display(Name = "Matrícula")]
        public string Matricula { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Carrera")]
        public string Carrera { get; set; } = string.Empty;

        [Required, EmailAddress]
        [Display(Name = "Correo institucional")]
        public string CorreoInstitucional { get; set; } = string.Empty;

        [Required, RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; } = string.Empty;

        [Required, DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [Display(Name = "Género")]
        public string Genero { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Turno")]
        public string Turno { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Tipo de ingreso")]
        public string TipoIngreso { get; set; } = string.Empty;

        [Display(Name = "¿Está becado?")]
        public bool EstaBecado { get; set; }

        [Range(0, 100)]
        [Display(Name = "Porcentaje de beca")]
        public int PorcentajeBeca { get; set; }

        [Required]
        [Display(Name = "Términos y condiciones")]
        public bool TerminosYCondiciones { get; set; }
    }
}
