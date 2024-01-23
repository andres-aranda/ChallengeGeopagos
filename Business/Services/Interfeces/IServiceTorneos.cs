using Dtos;

namespace Business.Services.Interfeces
{
	public interface IServiceTorneos
	{
		bool BorrarTorneo(int id);
		ITorneoDto? CrearTorneo(List<IJugadorDto> Jugadores);
		ITorneoDto? FinalizarTorneo(int id);
		IEnumerable<ITorneoDto> GetAllTorneos();
		IEnumerable<ITorneoDto> GetAllTorneosFinalizados(bool? masculino, DateTime? fechaDesde, DateTime? fechaHasta);
	}
}