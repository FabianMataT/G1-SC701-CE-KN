using CasoEstudio1_G1.Models;
using CasoEstudio1_G1.Services;
using Microsoft.AspNetCore.Mvc;

namespace CasoEstudio1_G1.Controllers
{
    public class RutasController : Controller
    {
        private readonly RutaService _rutaService;

        public RutasController(RutaService rutaService)
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

    }
}
