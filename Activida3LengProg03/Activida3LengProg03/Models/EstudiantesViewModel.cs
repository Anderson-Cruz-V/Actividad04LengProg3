using System.ComponentModel.DataAnnotations;

namespace Activida3LengProg03.Models
{
    public class EstudiantesViewModel
    {
        [Required (ErrorMessage ="El Nomnre es obligatorio completarlo ")]
        [StringLength (20,MinimumLength =3, ErrorMessage ="El nombre debe Estar entre 3 y 20 caracteres.")]
        [Display(Name ="Nombre Completo")]
        public string NombreCompleto { get; set; }
        public string Matricula{ get; set; }
        public string Carrera { get; set; }
        [Required(ErrorMessage = "El correo institucional es obligatorio completarlo ")]
        [EmailAddress(ErrorMessage ="El correo no es valido")]
        public string CorreoInstitucional { get; set; }
        public string Telefono { get; set; }
        public string FechaDeNacimiento { get; set; }
        public string Genero { get; set; }
        public string Turno { get; set; }
        public string TipoDeIngreso { get; set; }
        public string EstaBecado { get; set; }
        public string PorcentajeDeBeca { get; set; }
        public string TerminosYCondiciones { get; set; }
    }
}
