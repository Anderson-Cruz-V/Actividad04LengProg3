using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Actividad4LengProg3.Data;
using Actividad4LengProg3.Models;

namespace Actividad4LengProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly MiContexto _context;

        public EstudiantesController(MiContexto context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Lista()
        {
            var lista = _context.Estudiantes
                                .AsNoTracking()
                                .ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            ViewBag.Carreras = new[] { "Informática", "Contabilidad", "Administración" };
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Estudiante model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Carreras = new[] { "Informática", "Contabilidad", "Administración" };
                return View(model);
            }

            _context.Estudiantes.Add(model);
            _context.SaveChanges();
            TempData["Mensaje"] = "Estudiante registrado correctamente.";
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public IActionResult Editar(string matricula)
        {
            var est = _context.Estudiantes
                              .AsNoTracking()
                              .FirstOrDefault(e => e.Matricula == matricula);
            if (est == null)
                return RedirectToAction(nameof(Lista));

            ViewBag.Carreras = new[] { "Informática", "Contabilidad", "Administración" };
            return View(est);
        }

       [HttpPost]
public IActionResult Editar(Estudiante model)
{
    if (!ModelState.IsValid)
    {
        ViewBag.Carreras = new[] { "Informática", "Contabilidad", "Administración" };
        return View(model);
    }

    var entidad = _context.Estudiantes.Find(model.Id);
    if (entidad == null)
        return RedirectToAction(nameof(Lista));

    entidad.NombreCompleto       = model.NombreCompleto;
    entidad.CorreoInstitucional  = model.CorreoInstitucional;
    entidad.Carrera              = model.Carrera;
    entidad.Telefono             = model.Telefono;
    entidad.FechaNacimiento      = model.FechaNacimiento;
    entidad.Genero               = model.Genero;
    entidad.Turno                = model.Turno;
    entidad.TipoIngreso          = model.TipoIngreso;
    entidad.EstaBecado           = model.EstaBecado;
    entidad.PorcentajeBeca       = model.PorcentajeBeca;
    entidad.TerminosYCondiciones = model.TerminosYCondiciones;

    _context.SaveChanges();
    TempData["Mensaje"] = "Estudiante editado correctamente.";
    return RedirectToAction(nameof(Lista));
}


        [HttpGet]
        public IActionResult Eliminar(string matricula)
        {
            var est = _context.Estudiantes
                              .AsNoTracking()
                              .FirstOrDefault(e => e.Matricula == matricula);
            if (est == null)
                return RedirectToAction(nameof(Lista));

            return View(est);
        }

        [HttpPost, ActionName("Eliminar")]
        public IActionResult EliminarConfirmado(string matricula)
        {
            var est = _context.Estudiantes
                              .FirstOrDefault(e => e.Matricula == matricula);
            if (est != null)
            {
                _context.Estudiantes.Remove(est);
                _context.SaveChanges();
                TempData["Mensaje"] = "Estudiante eliminado correctamente.";
            }
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public IActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buscar(string matricula)
        {
            if (string.IsNullOrWhiteSpace(matricula))
            {
                TempData["MensajeError"] = "Debes ingresar una matrícula.";
                return View();
            }

            var est = _context.Estudiantes
                              .AsNoTracking()
                              .FirstOrDefault(e => e.Matricula == matricula);
            if (est == null)
            {
                TempData["MensajeError"] = "No se encontró ningún estudiante con esa matrícula.";
                return View();
            }
            return View("ExpedienteEstudiante", est);
        }
    }
}
