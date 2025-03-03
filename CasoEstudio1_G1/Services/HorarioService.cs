
using CasoEstudio1_G1.Models;

namespace CasoEstudio1_G1.Services
{
    public class HorarioService
    {
        private readonly HttpClient _httpClient;

        public HorarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<HorarioRuta>> GetHorariosAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/horarios/{id}");
            if (response.IsSuccessStatusCode)
            {
                var horarios = await response.Content.ReadFromJsonAsync<List<HorarioRuta>>();
                return horarios;
            }
            return null;
        }
    }
}
