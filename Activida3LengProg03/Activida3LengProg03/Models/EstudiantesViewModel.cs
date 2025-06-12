using System.ComponentModel.DataAnnotations;

namespace Activida3LengProg03.Models
{
    public class EstudiantesViewModel
    {
        [Required(ErrorMessage = "El Nombre es obligatorio completarlo")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe estar entre 3 y 100 caracteres.")]
        [Display(Name = "Nombre completo")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "La matrícula es obligatoria")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "La matrícula debe estar entre 6 y 15 caracteres.")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "La carrera es obligatoria")]
        public string Carrera { get; set; }

        [Required(ErrorMessage = "El correo institucional es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo no es válido")]
        [Display(Name = "Correo institucional")]
        public string CorreoInstitucional { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [Phone(ErrorMessage = "El teléfono no es válido")]
        [StringLength(10, ErrorMessage = "El teléfono debe tener 10 dígitos.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime? FechaDeNacimiento { get; set; }

        [Required(ErrorMessage = "El género es obligatorio")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "El turno es obligatorio")]
        public string Turno { get; set; }

        [Required(ErrorMessage = "El tipo de ingreso es obligatorio")]
        [Display(Name = "Tipo de ingreso")]
        public string TipoDeIngreso { get; set; }

        [Display(Name = "¿Está becado?")]
        public bool EstaBecado { get; set; }

        [Range(0, 100, ErrorMessage = "El porcentaje de beca debe estar entre 0 y 100")]
        [Display(Name = "Porcentaje de beca")]
        public int? PorcentajeDeBeca { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Debe aceptar los términos y condiciones")]
        [Display(Name = "Términos y condiciones")]
        public bool TerminosYCondiciones { get; set; }
     
    }
}