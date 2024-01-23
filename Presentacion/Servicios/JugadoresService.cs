using Dtos;
using Presentacion.Helpers;
using Presentacion.Servicios.Interfaces;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Presentacion.Servicios
{
	public class JugadoresService(HttpClient httpClient) : IJugadoresService
	{
		private readonly HttpClient _httpClient = httpClient;
		private readonly string _urlApi = Inicializar.UrlServicio;

		public async Task<IEnumerable<JugadorFemeninoDto>?> ObtenerFemeninos()
		{
			var options = new JsonSerializerOptions()
			{
				ReferenceHandler = ReferenceHandler.Preserve,
				PropertyNameCaseInsensitive = true
			};
			var result = await _httpClient.GetFromJsonAsync<IEnumerable<JugadorFemeninoDto>>($"{_urlApi}api/Jugadores/Femeninos", options);
			return result;

		}
		public async Task<IEnumerable<JugadorMasculinoDto>?> ObtenerMasculinos()
		{
			var options = new JsonSerializerOptions()
			{
				ReferenceHandler = ReferenceHandler.Preserve,
				PropertyNameCaseInsensitive = true
			};
			var result = await _httpClient.GetFromJsonAsync<IEnumerable<JugadorMasculinoDto>>($"{_urlApi}api/Jugadores/Masculinos", options);
			return result;
		}
		public async Task<bool> CrearMasculino(JugadorMasculinoDto jugador)
		{
			var result = await _httpClient.PostAsJsonAsync($"{_urlApi}api/Jugadores/Masculinos", jugador);
			var jugadorCreado = await result.Content.ReadFromJsonAsync<JugadorMasculinoDto>();
			return result?.StatusCode == HttpStatusCode.Created || result?.StatusCode == HttpStatusCode.OK;
		}
		public async Task<bool> CrearFemenino(JugadorFemeninoDto jugador)
		{
			var result = await _httpClient.PostAsJsonAsync($"{_urlApi}api/Jugadores/Femeninos", jugador);
			var jugadorCreado = await result.Content.ReadFromJsonAsync<JugadorFemeninoDto>();
			return result?.StatusCode == HttpStatusCode.Created;
		}
		public async Task<bool> BorrarMasculino(int id)
		{
			var response = await _httpClient.DeleteAsync($"{_urlApi}api/Jugadores/BorrarMasculinos/{id}");
			if (response.IsSuccessStatusCode)
			{
				return true;
			}
			return false;
		}
		public async Task<bool> BorrarFemenino(int id)
		{
			var response = await _httpClient.DeleteAsync($"{_urlApi}api/Jugadores/BorrarFemeninos/{id}");
			if (response.IsSuccessStatusCode)
			{
				return true;
			}
			return false;
		}

	}
}
