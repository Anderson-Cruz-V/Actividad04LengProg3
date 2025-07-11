
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Actividad4LengProg3.Data;
using Actividad4LengProg3.Models;

namespace Actividad4LengProg3.Controllers
{
    public class MateriasController : Controller
    {
        private readonly MiContexto _context;
        public MateriasController(MiContexto context) => _context = context;

        public IActionResult Lista()
        {
            var lista = _context.Materias.AsNoTracking().ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Materia model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.Materias.Add(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public IActionResult Editar(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
                return RedirectToAction(nameof(Lista));

            var mat = _context.Materias.Find(codigo);
            if (mat == null)
                return RedirectToAction(nameof(Lista));

            return View(mat);
        }

        [HttpPost]
        public IActionResult Editar(Materia model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.Materias.Update(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public IActionResult Eliminar(string codigo)
        {
            var mat = _context.Materias.Find(codigo);
            if (mat == null)
                return RedirectToAction(nameof(Lista));

            return View(mat);
        }

        [HttpPost, ActionName("Eliminar")]
        public IActionResult EliminarConfirmado(string codigo)
        {
            var mat = _context.Materias.Find(codigo);
            if (mat != null)
            {
                _context.Materias.Remove(mat);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Lista));
        }
    }
}
