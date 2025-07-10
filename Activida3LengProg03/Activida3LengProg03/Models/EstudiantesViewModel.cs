using System;
using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg3.Models
{
    public class EstudiantesViewModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe estar entre 3 y 100 caracteres.")]
        [Display(Name = "Nombre completo")]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required(ErrorMessage = "La matrícula es obligatoria.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "La matrícula debe estar entre 6 y 20 caracteres.")]
        [Display(Name = "Matrícula")]
        public string Matricula { get; set; } = string.Empty;

        [Required(ErrorMessage = "La carrera es obligatoria.")]
        public string Carrera { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo institucional es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo no es válido.")]
        [Display(Name = "Correo institucional")]
        public string CorreoInstitucional { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "El teléfono debe tener el formato 809-555-5555.")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime? FechaDeNacimiento { get; set; }

        [Required(ErrorMessage = "El género es obligatorio.")]
        public string Genero { get; set; } = string.Empty;

        [Required(ErrorMessage = "El turno es obligatorio.")]
        public string Turno { get; set; } = string.Empty;

        [Required(ErrorMessage = "El tipo de ingreso es obligatorio.")]
        [Display(Name = "Tipo de ingreso")]
        public string TipoDeIngreso { get; set; } = string.Empty;

        [Display(Name = "¿Está becado?")]
        public bool EstaBecado { get; set; }

        [Range(0, 100, ErrorMessage = "El porcentaje de beca debe estar entre 0 y 100.")]
        [Display(Name = "Porcentaje de beca")]
        public int? PorcentajeDeBeca { get; set; }

        [Required(ErrorMessage = "Debe aceptar los términos y condiciones.")]
        [Display(Name = "Términos y condiciones")]
        public bool TerminosYCondiciones { get; set; }
    }
}

