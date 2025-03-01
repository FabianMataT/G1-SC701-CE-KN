using CasoEstudio1_G1.Models;

namespace CasoEstudio1_G1.Services
{
    public class RutaService
    {
        private readonly HttpClient _httpClient;

        public RutaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Ruta>> GetRutasAsync()
        {
            var response = await _httpClient.GetAsync("api/routes");
            if(response.IsSuccessStatusCode)
            {
                var rutas = await response.Content.ReadFromJsonAsync<List<Ruta>>();
                return rutas;
            }
            return null;
        }
    }
}
