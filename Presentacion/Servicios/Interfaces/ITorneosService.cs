using Dtos;

namespace Presentacion.Servicios.Interfaces
{
	public interface ITorneosService
	{
		Task<bool> BorrarTorneo(int id);
		Task<bool> CrearTorneoFemenino(IEnumerable<JugadorFemeninoDto> poster);
		Task<TorneoDto?> CrearTorneoFemeninoYFinalizar(IEnumerable<JugadorFemeninoDto> poster);
		Task<bool> CrearTorneoMasculino(IEnumerable<JugadorMasculinoDto> poster);
		Task<TorneoDto?> CrearTorneoMasculinoYFinalizar(IEnumerable<JugadorMasculinoDto> poster);
		Task<TorneoDto?> FinalizarTorneo(int idTorneo);
		Task<IEnumerable<TorneoDto>> ObtenerTodos();
		Task<TorneoDto?> ObtenerUno(int id);
	}
}