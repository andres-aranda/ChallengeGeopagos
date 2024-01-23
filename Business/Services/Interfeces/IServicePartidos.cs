using Dtos;

namespace Business.Services.Interfeces
{
	public interface IServicePartidos
	{
		List<IPartidoDto> CrearPartidos(IList<IJugadorDto> jugadoresDto);
		IPartidoDto? CrearProximoPartido(IPartidoDto partidoDto1, IPartidoDto partidoDto2);
		List<IPartidoDto> DeterminarGanadores(List<IPartidoDto> partidosDto);
		List<PartidoFemeninoDto> GetAllPartidosFemeninos();
		List<PartidoMasculinoDto> GetAllPartidosMasculinos();
	}
}