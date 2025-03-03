using CasoEstudio1_G1.Models;
using CasoEstudio1_G1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasoEstudio1_G1.Controllers
{
    public class HorarioController : Controller
    {
        private readonly HorarioService _horarioService;

        public HorarioController(HorarioService horarioService)
        {
            _horarioService = horarioService;
        }

        public async Task<IActionResult> VerHorarios(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarios = await _horarioService.GetHorariosAsync(id.Value) ?? new List<HorarioRuta>();

            if (!horarios.Any())
            {
                return NotFound();
            }

            return View(horarios);
        }
    }
}
