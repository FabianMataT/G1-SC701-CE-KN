using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CasoEstudio1_G1.Models;
using System.Linq;

namespace CasoEstudio1_G1.Controllers
{
    public class RutaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RutaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var rutas = _context.Rutas.Include(r => r.Usuario).ToList();
            return View(rutas);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Ruta ruta)
        {
            if (ModelState.IsValid)
            {
                ruta.FechaRegistro = DateTime.Now;
                ruta.UsuarioId = ObtenerUsuarioActual(); // Método para obtener usuario autenticado
                _context.Rutas.Add(ruta);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ruta);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var ruta = _context.Rutas.Find(id);
            if (ruta == null)
            {
                return NotFound();
            }
            return View(ruta);
        }

        [HttpPost]
        public IActionResult Editar(Ruta ruta)
        {
            if (ModelState.IsValid)
            {
                _context.Rutas.Update(ruta);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ruta);
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            var ruta = _context.Rutas.Find(id);
            if (ruta == null)
            {
                return NotFound();
            }
            return View(ruta);
        }

        [HttpPost, ActionName("Eliminar")]
        public IActionResult EliminarConfirmado(int id)
        {
            var ruta = _context.Rutas.Find(id);
            if (ruta != null)
            {
                _context.Rutas.Remove(ruta);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        private int ObtenerUsuarioActual()
        {
            return 1; // Aquí debes reemplazar con el ID del usuario autenticado
        }
    }
}
