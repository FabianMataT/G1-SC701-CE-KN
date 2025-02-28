using CasoEstudio1_G1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CasoEstudio1_G1.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _httpClient;
        private readonly ILogger<VehiculoController> _logger;

        public VehiculoController(ApplicationDbContext context, HttpClient httpClient, ILogger<VehiculoController> logger)
        {
            _context = context;
            _httpClient = new HttpClient();
            _logger = logger;
        }
        
        #region Obtener Estados y rutas
        private async Task<List<Estado>> ObtenerEstadosVehiculoAsync()
        {
            try
            {
                var estados = await _context.Estados.ToListAsync();
                return estados;
            }
            catch (Exception ex)
            {
                return new List<Estado>();
            }
        }

        private async Task<List<Ruta>> ObtenerRutasVehiculoAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7245/api/rutas");

                if (!response.IsSuccessStatusCode)
                {
                    return new List<Ruta>();
                }

                var responseBody = await response.Content.ReadAsStringAsync();
                var rutas = JsonConvert.DeserializeObject<List<Ruta>>(responseBody, new JsonSerializerSettings
                {
                    Error = (sender, args) => args.ErrorContext.Handled = true
                });

                return rutas ?? new List<Ruta>();
            }
            catch
            {
                return new List<Ruta>();
            }
        }

        #endregion 

        #region Crear Vehiculo
        public async Task<IActionResult> CrearVehiculo()
        {
            ViewBag.Estados = await ObtenerEstadosVehiculoAsync();
            ViewBag.Rutas = await ObtenerRutasVehiculoAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearVehiculo(Vehiculo vehiculo)
        {
            vehiculo.Estado = null;
            vehiculo.Ruta = null;
            vehiculo.Usuario = null;

            if (!ModelState.IsValid)
            {
                ViewBag.Estados = await ObtenerEstadosVehiculoAsync();
                ViewBag.Rutas = await ObtenerRutasVehiculoAsync();
                return View(vehiculo);
            }

            try
            {
                vehiculo.FechaRegistro = DateTime.Now;
                vehiculo.UsuarioId = 3; /*IMPORTANTE  Asignarle el usuario que tenga el rol de conductor el conductor*/
                _context.Vehiculos.Add(vehiculo);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(ListarVehiculos));
            }
            catch
            {
                return View(vehiculo);
            }
        }

        #endregion 

        #region Listar los Vehiculos
        public async Task<IActionResult> ListarVehiculos()
        {
            var vehiculos = await _context.Vehiculos
                                          .Include(v => v.Estado)
                                          .Include(v => v.Ruta)
                                          .ToListAsync();
            return View(vehiculos);
        }
        #endregion 

        #region  Editar Vehiculo

        public async Task<IActionResult> EditarVehiculo(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            ViewBag.Estados = await ObtenerEstadosVehiculoAsync();
            ViewBag.Rutas = await ObtenerRutasVehiculoAsync();
            return View(vehiculo);
        }

        [HttpPost]
        public async Task<IActionResult> EditarVehiculo(int id, Vehiculo vehiculo)
        {
            var vehiculoExistente = await _context.Vehiculos.FindAsync(id);
            if (vehiculoExistente == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Estados = await ObtenerEstadosVehiculoAsync();
                ViewBag.Rutas = await ObtenerRutasVehiculoAsync();
                return View(vehiculo);
            }

            vehiculoExistente.Placa = vehiculo.Placa;
            vehiculoExistente.Modelo = vehiculo.Modelo;
            vehiculoExistente.CapacidadPasajeros = vehiculo.CapacidadPasajeros;
            vehiculoExistente.EstadoId = vehiculo.EstadoId;
            vehiculoExistente.RutaId = vehiculo.RutaId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ListarVehiculos));
        }

        #endregion 

        #region Eliminar Vehiculo

        [HttpPost]
        public async Task<IActionResult> EliminarVehiculo(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            try
            {
                _context.Vehiculos.Remove(vehiculo);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return BadRequest("No se pudo eliminar el vehículo.");
            }

            return RedirectToAction(nameof(ListarVehiculos));
        }

        #endregion 

    }
}