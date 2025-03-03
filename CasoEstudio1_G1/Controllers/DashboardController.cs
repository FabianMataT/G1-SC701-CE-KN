using CasoEstudio1_G1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasoEstudio1_G1.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            var rutasActivas = _context.Rutas.Count(r => r.Estado);
            var vehiculosBuenos = _context.Vehiculos.Count(v => v.EstadoId == 1);
            var boletosVendidos = _context.Boletos.Count();

            var dashboardData = new DashboardViewModel
            {
                RutasActivas = rutasActivas,
                VehiculosBuenos = vehiculosBuenos,
                BoletosVendidos = boletosVendidos
            };

            return View(dashboardData);
        }
    }
}
