using Activida3LengProg03.Models;
using Microsoft.AspNetCore.Mvc;

namespace Activida3LengProg03.Controllers
{
    public class EstudiantesController : Controller
    {
        private static List<EstudiantesViewModel> estudiantes = new List<EstudiantesViewModel>
        {
            new EstudiantesViewModel
            {
                NombreCompleto = "Anderson Cruz",
                Matricula = "sd-2022-04079",
                Carrera = "Informática",
                CorreoInstitucional = "sd-2022-04079@ufhec.edu.do",
                Telefono = "809-555-5555",
                FechaDeNacimiento = new DateTime(2000, 1, 1),
                Genero = "Masculino",
                Turno = "Mañana",
                TipoDeIngreso = "Nuevo Ingreso",
                EstaBecado = true,
                PorcentajeDeBeca = 80,
                TerminosYCondiciones = true
            }
        };

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

      
        [HttpGet]
        public IActionResult Lista()
        {
            return View(estudiantes);
        }

      
        [HttpGet]
        public IActionResult Registrar()
        {
            ViewBag.Carreras = new List<string> { "Informática", "Contabilidad", "Administración" };
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(EstudiantesViewModel model)
        {
            if (ModelState.IsValid)
            {
                estudiantes.Add(model);
                TempData["Mensaje"] = "Estudiante registrado correctamente.";
                return RedirectToAction("Lista");
            }
            ViewBag.Carreras = new List<string> { "Informática", "Contabilidad", "Administración" };
            return View(model);
        }


        [HttpGet]
        public IActionResult Editar(string matricula)
        {
            if (string.IsNullOrEmpty(matricula))
            {
                TempData["MensajeError"] = "La matrícula pasada no existe.";
                return RedirectToAction("Lista");
            }

            var estudianteActual = estudiantes.FirstOrDefault(e => e.Matricula == matricula);

            if (estudianteActual == null)
            {
                TempData["MensajeError"] = "No existe el estudiante indicado";
                return RedirectToAction("Lista");
            }

            ViewBag.Carreras = new List<string> { "Informática", "Contabilidad", "Administración" };
            return View(estudianteActual);
        }

        [HttpGet]
        public IActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buscar(string matricula)
        {
            if (string.IsNullOrEmpty(matricula))
            {
                TempData["MensajeError"] = "Debes ingresar una matrícula.";
                return View();
            }

            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula.Equals(matricula, StringComparison.OrdinalIgnoreCase));
            if (estudiante == null)
            {
                TempData["MensajeError"] = "No se encontró ningún estudiante con esa matrícula.";
                return View();
            }

            return View("ExpedienteEstudiante", estudiante);

        }




        [HttpPost]
        public IActionResult Editar(EstudiantesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var estudianteActual = estudiantes.FirstOrDefault(e => e.Matricula == model.Matricula);

                if (estudianteActual == null)
                {
                    TempData["MensajeError"] = "No existe el estudiante indicado";
                    return RedirectToAction("Lista");
                }

                estudianteActual.NombreCompleto = model.NombreCompleto;
                estudianteActual.Carrera = model.Carrera;
                estudianteActual.CorreoInstitucional = model.CorreoInstitucional;
                estudianteActual.Telefono = model.Telefono;
                estudianteActual.FechaDeNacimiento = model.FechaDeNacimiento;
                estudianteActual.Genero = model.Genero;
                estudianteActual.Turno = model.Turno;
                estudianteActual.TipoDeIngreso = model.TipoDeIngreso;
                estudianteActual.EstaBecado = model.EstaBecado;
                estudianteActual.PorcentajeDeBeca = model.PorcentajeDeBeca;
                estudianteActual.TerminosYCondiciones = model.TerminosYCondiciones;

                TempData["Mensaje"] = "Estudiante editado correctamente.";
                return RedirectToAction("Lista");
            }
            ViewBag.Carreras = new List<string> { "Informática", "Contabilidad", "Administración" };
            return View(model);
        }

        
        [HttpGet]
        public IActionResult Eliminar(string id)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == id);
            if (estudiante == null)
            {
                TempData["MensajeError"] = "El estudiante no existe.";
                return RedirectToAction("Lista");
            }
            ViewBag.Carreras = new List<string> { "Informática", "Contabilidad", "Administración" };
            return View(estudiante);
        }

       
        [HttpPost]
        public IActionResult Eliminar(EstudiantesViewModel model)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == model.Matricula);
            if (estudiante == null)
            {
                TempData["MensajeError"] = "El estudiante no existe.";
                return RedirectToAction("Lista");
            }
            estudiantes.Remove(estudiante);
            TempData["Mensaje"] = "Estudiante eliminado correctamente.";
            return RedirectToAction("Lista");
        }
    }
}
