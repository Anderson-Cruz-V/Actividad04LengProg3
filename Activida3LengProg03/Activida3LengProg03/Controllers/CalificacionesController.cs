using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Actividad4LengProg3.Data;
using Actividad4LengProg3.Models;

namespace Actividad4LengProg3.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly MiContexto _context;
        public CalificacionesController(MiContexto context) => _context = context;

        public IActionResult Lista() =>
            View(_context.Calificaciones.AsNoTracking().ToList());

        [HttpGet]
        public IActionResult Registrar() => View();

        [HttpPost]
        public IActionResult Registrar(Calificacion model)
        {
            if (!ModelState.IsValid) return View(model);
            _context.Calificaciones.Add(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var c = _context.Calificaciones.Find(id);
            if (c == null) return RedirectToAction(nameof(Lista));
            return View(c);
        }

        [HttpPost]
        public IActionResult Editar(Calificacion model)
        {
            if (!ModelState.IsValid) return View(model);
            _context.Calificaciones.Update(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            var c = _context.Calificaciones.Find(id);
            if (c == null) return RedirectToAction(nameof(Lista));
            return View(c);
        }

        [HttpPost, ActionName("Eliminar")]
        public IActionResult EliminarConfirmado(int id)
        {
            var c = _context.Calificaciones.Find(id);
            if (c != null)
            {
                _context.Calificaciones.Remove(c);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Lista));
        }
    }
}
