using CasoEstudio1_G1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CasoEstudio1_G1.Controllers
{
    public class BoletosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _httpClient;

        public BoletosController(ApplicationDbContext context)
        {
            _context = context;
            _httpClient = new HttpClient();
        }


        #region Comprar Boletos
        [HttpGet]
        public async Task<IActionResult> ComprarBoleto()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7245/api/rutas");

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.Rutas = new List<Ruta>(); 
                }
                else
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    ViewBag.Rutas = JsonConvert.DeserializeObject<List<Ruta>>(responseBody) ?? new List<Ruta>(); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener rutas: {ex.Message}");
                ViewBag.Rutas = new List<Ruta>();
            }

            ViewBag.Vehiculos = await _context.Vehiculos.ToListAsync() ?? new List<Vehiculo>(); 

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ComprarBoleto(int rutaId, int vehiculoId)
        {
            int usuarioId = 1; 
            var rutaResponse = await _httpClient.GetAsync($"https://localhost:7245/api/rutas/{rutaId}");
            if (!rutaResponse.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "La ruta seleccionada no existe o no está activa.");
                return View();
            }
            var vehiculo = await _context.Vehiculos.FirstOrDefaultAsync(v => v.Id == vehiculoId && v.RutaId == rutaId);
            if (vehiculo == null)
            {
                ModelState.AddModelError("", "El vehículo seleccionado no pertenece a la ruta elegida.");
                return View();
            }
            int boletosVendidos = await _context.Boletos.Where(b => b.VehiculoId == vehiculoId).CountAsync();
            if (boletosVendidos >= vehiculo.CapacidadPasajeros)
            {
                ModelState.AddModelError("", "No hay asientos disponibles.");
                return View();
            }
            var boleto = new Boleto
            {
                UsuarioId = usuarioId,
                VehiculoId = vehiculoId
            };

            _context.Boletos.Add(boleto);
            await _context.SaveChangesAsync();

            return RedirectToAction("MisBoletos", new { usuarioId });
        }

        #endregion

        #region Vista para ver mis Boletos Comprados
        public async Task<IActionResult> MisBoletos(int usuarioId)
        {
            var boletos = await _context.Boletos
                .Where(b => b.UsuarioId == usuarioId)
                .Include(b => b.Vehiculo)
                .ThenInclude(v => v.Ruta)
                .ToListAsync();

            return View(boletos);
        }
        #endregion

        #region Boletos Vendidos por Ruta Asignada al Conductos
        /* Importante primero es al Controller de Vehiculo y crear un nuevo vehiculo en codigo asignar el conductor y luego cambiar solo el usuario aca para que pueda ver los datos en la vista*/
        public async Task<IActionResult> BoletosPorRutaAsignada()
        {
            int usuarioId = 3; 
            int rolId = 2;

            if (rolId != 2)
            {
                return Unauthorized();
            }

            var boletos = await _context.Boletos
                .Include(b => b.Vehiculo)
                .ThenInclude(v => v.Ruta)
                .Include(b => b.Usuario)
                .Where(b => b.Vehiculo.UsuarioId == usuarioId) 
                .ToListAsync();

            return View(boletos);
        }
        #endregion

        #region Bolestos Vendidos Admin
        public async Task<IActionResult> BoletosVendidos()
        {
            int usuarioId = 1; 
            int rolId = 1; 

            if (rolId != 1) 
            {
                return Unauthorized(); 
            }

            var boletos = await _context.Boletos
                .Include(b => b.Usuario)
                .Include(b => b.Vehiculo)
                .ThenInclude(v => v.Ruta)
                .ToListAsync();

            return View(boletos);
        }

        #endregion
    }


}