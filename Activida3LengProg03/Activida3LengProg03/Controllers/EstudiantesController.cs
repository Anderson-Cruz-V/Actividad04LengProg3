using Activida3LengProg03.Models;
using Microsoft.AspNetCore.Mvc;

namespace Activida3LengProg03.Controllers
{
    public class EstudiantesController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
                ViewBag.Message = "El Estudiante ha sido Registrado";
                return View(model);
            }
            return View();
        }

    }
}
