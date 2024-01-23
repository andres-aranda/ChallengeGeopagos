using Dtos;
using Presentacion.Helpers;
using Presentacion.Servicios.Interfaces;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Presentacion.Servicios
{
	public class TorneosService(HttpClient httpClient) : ITorneosService
	{
		private readonly HttpClient _httpClient = httpClient;
		private readonly string _urlApi = Inicializar.UrlServicio;
		private readonly JsonSerializerOptions options = new JsonSerializerOptions()
		{
			ReferenceHandler = ReferenceHandler.Preserve,
			PropertyNameCaseInsensitive = true

		};
		public async Task<TorneoDto?> ObtenerUno(int id)
		{
			return await _httpClient.GetFromJsonAsync<TorneoDto>($"{_urlApi}api/Torneos/{id}", options);
		}

		public async Task<bool> CrearTorneoMasculino(IEnumerable<JugadorMasculinoDto> jugadores)
		{
			var result = await _httpClient.PostAsJsonAsync($"{_urlApi}api/Torneos/CrearTorneoMasculino", jugadores, options);
			return result?.StatusCode == HttpStatusCode.OK;
		}

		public async Task<bool> CrearTorneoFemenino(IEnumerable<JugadorFemeninoDto> jugadores)
		{

			var result = await _httpClient.PostAsJsonAsync($"{_urlApi}api/Torneos/CrearTorneoFemenino", jugadores, options);
			return result?.StatusCode == HttpStatusCode.OK;
		}

		public async Task<TorneoDto?> CrearTorneoFemeninoYFinalizar(IEnumerable<JugadorFemeninoDto> jugadores)
		{

			var result = await _httpClient.PostAsJsonAsync($"{_urlApi}api/Torneos/CrearTorneoYFinalizarFemenino", jugadores, options);
			if (result?.StatusCode == HttpStatusCode.OK)
			{
				var torneo = await result.Content.ReadFromJsonAsync<TorneoDto>(options);
				return torneo;
			}
			return null;
		}

		public async Task<TorneoDto?> CrearTorneoMasculinoYFinalizar(IEnumerable<JugadorMasculinoDto> jugadores)
		{
			var result = await _httpClient.PostAsJsonAsync($"{_urlApi}api/Torneos/CrearTorneoYFinalizarMasculino", jugadores, options);
			if (result?.StatusCode == HttpStatusCode.OK)
			{
				var torneo = await result.Content.ReadFromJsonAsync<TorneoDto>(options);
				return torneo;
			}
			return null;
		}

		public async Task<TorneoDto?> FinalizarTorneo(int idTorneo)
		{

			var result = await _httpClient.GetFromJsonAsync<TorneoDto>($"{_urlApi}api/Torneos/FinalizarTorneo/{idTorneo}", options);
			return result;
		}

		public async Task<bool> BorrarTorneo(int id)
		{
			var response = await _httpClient.DeleteAsync($"{_urlApi}api/Torneos/{id}");
			return response.StatusCode == HttpStatusCode.NoContent;
		}

		public async Task<IEnumerable<TorneoDto>> ObtenerTodos()
		{

			var result = await _httpClient.GetFromJsonAsync<IEnumerable<TorneoDto>>($"{_urlApi}api/Torneos/ObtenerTodos", options);
			return result ?? new List<TorneoDto>();
		}

	}
}
