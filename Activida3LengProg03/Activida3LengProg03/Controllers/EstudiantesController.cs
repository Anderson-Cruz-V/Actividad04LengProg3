using Activida3LengProg03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Activida3LengProg03.Controllers
{
    public class EstudiantesController : Controller
    {
        private static List<EstudiantesViewModel> Estudiantes = new List<EstudiantesViewModel>
        {
            new EstudiantesViewModel
            {
                NombreCompleto = "Anderson Cruz",
                Matricula = "20210001",
                Carrera = "Informática",
                CorreoInstitucional = "anderson@ufhec.edu.do",
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
        public IActionResult Lista()
        {
            return View(Estudiantes);
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
                Estudiantes.Add(model);
                TempData["Mensaje"] = "Estudiante Registrado Correctamente";
                return RedirectToAction("Lista");
            }
            ViewBag.Carreras = new List<string> { "Informática", "Contabilidad", "Administración" };
            return View(model);
        }

        [HttpGet]
        public IActionResult Editar(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["Error"] = "El estudiante no existe";
                return RedirectToAction("Lista");
            }

            var estudiantesactual = Estudiantes.FirstOrDefault(e => e.Matricula.Equals(id));
            if (estudiantesactual == null)
            {
                TempData["Error"] = "El estudiante no existe";
                return RedirectToAction("Lista");
            }

            ViewBag.Carreras = new List<string> { "Informática", "Contabilidad", "Administración" };
            return View(estudiantesactual);
        }

        [HttpPost]
        public IActionResult Editar(EstudiantesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var estudiantesactual = Estudiantes.FirstOrDefault(e => e.Matricula.Equals(model.Matricula));
                if (estudiantesactual == null)
                {
                    TempData["Error"] = "El estudiante no existe";
                    return RedirectToAction("Lista");
                }

                estudiantesactual.NombreCompleto = model.NombreCompleto;
                estudiantesactual.Carrera = model.Carrera;
                estudiantesactual.CorreoInstitucional = model.CorreoInstitucional;
                estudiantesactual.Telefono = model.Telefono;
                estudiantesactual.FechaDeNacimiento = model.FechaDeNacimiento;
                estudiantesactual.Genero = model.Genero;
                estudiantesactual.Turno = model.Turno;
                estudiantesactual.TipoDeIngreso = model.TipoDeIngreso;
                estudiantesactual.EstaBecado = model.EstaBecado;
                estudiantesactual.PorcentajeDeBeca = model.PorcentajeDeBeca;
                estudiantesactual.TerminosYCondiciones = model.TerminosYCondiciones;

                TempData["Mensaje"] = "Estudiante editado correctamente";
                return RedirectToAction("Lista");
            }
            ViewBag.Carreras = new List<string> { "Informática", "Contabilidad", "Administración" };
            return View(model);
        }
        [HttpGet]
        public IActionResult Eliminar(string id)
        {
            var estudianteActual = Estudiantes.FirstOrDefault(e => e.Matricula.Equals(id));
            if (estudianteActual == null)
            {
                TempData["Error"] = "El estudiante no existe";
                return RedirectToAction("Lista");
            }
            return View(estudianteActual); // Muestra la vista de confirmación
        }
        [HttpPost]
        public IActionResult EliminarConfirmado(string matricula)
        {
            var estudianteAEliminar = Estudiantes.FirstOrDefault(e => e.Matricula.Equals(matricula));
            if (estudianteAEliminar == null)
            {
                TempData["Error"] = "El estudiante no existe";
                return RedirectToAction("Lista");
            }

            Estudiantes.Remove(estudianteAEliminar);
            TempData["Mensaje"] = "Estudiante eliminado correctamente.";
            return RedirectToAction("Lista");
        }
    }
}
