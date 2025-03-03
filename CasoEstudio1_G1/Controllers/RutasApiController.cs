using CasoEstudio1_G1.Models;
using CasoEstudio1_G1.Services;
using Microsoft.AspNetCore.Mvc;

namespace CasoEstudio1_G1.Controllers
{
    public class RutasApiController : Controller
    {
        private readonly RutaService _rutaService;

        public RutasApiController(RutaService rutaService)
        {
            _rutaService = rutaService;
        }
        public async Task<IActionResult> Index()
        {
            var rutas = await _rutaService.GetRutasAsync();

            if (rutas == null)
            {
                rutas = new List<Ruta>(); 
            }

            return View(rutas);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ruta = await _rutaService.GetRutaAsync(id.Value);

            if (ruta == null)
            {
                return NotFound();
            }

            return View(ruta);
        }

    }
}
