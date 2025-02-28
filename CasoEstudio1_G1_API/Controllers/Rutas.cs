using CasoEstudio1_G1_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CasoEstudio1_G1_API.Controllers
{
    [Route("api/rutas")]
    [ApiController]
  
        public class RutasController : ControllerBase
        {
            private readonly ApplicationDbContext _context;

            public RutasController(ApplicationDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<IActionResult> GetRoutes()
            {
                var rutas = await _context.Rutas
                    .Where(r => r.Estado)
                    .Select(r => new
                    {
                        r.Id,
                        r.NombreRuta,
                        r.Descripcion,
                        r.FechaRegistro
                    })
                    .ToListAsync();

                return Ok(rutas);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetRoute(int id)
            {
                var ruta = await _context.Rutas
                    .Where(r => r.Id == id && r.Estado) 
                    .Select(r => new
                    {
                        r.Id,
                        r.NombreRuta,
                        r.Descripcion,
                        r.FechaRegistro,
                        Horarios = _context.HorariosRutas
                            .Where(hr => hr.RutaId == r.Id)
                            .Select(hr => hr.Horario.Hora)
                            .ToList()
                    })
                    .FirstOrDefaultAsync();

                if (ruta == null)
                {
                    return NotFound(new { message = "Ruta no encontrada." });
                }

                return Ok(ruta);
            }
        }
    }