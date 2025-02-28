using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CasoEstudio1_G1_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasoEstudio1_G1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RutaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todas las rutas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ruta>>> GetRutas()
        {
            return await _context.Rutas.ToListAsync();
        }

        // Obtener una ruta por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Ruta>> GetRuta(int id)
        {
            var ruta = await _context.Rutas.FindAsync(id);
            if (ruta == null) return NotFound();
            return ruta;
        }

        // Crear una nueva ruta
        [HttpPost]
        public async Task<ActionResult<Ruta>> PostRuta(Ruta ruta)
        {
            _context.Rutas.Add(ruta);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRuta), new { id = ruta.Id }, ruta);
        }

        // Actualizar una ruta existente
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRuta(int id, Ruta ruta)
        {
            if (id != ruta.Id) return BadRequest();

            _context.Entry(ruta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Eliminar una ruta
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRuta(int id)
        {
            var ruta = await _context.Rutas.FindAsync(id);
            if (ruta == null) return NotFound();

            _context.Rutas.Remove(ruta);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
