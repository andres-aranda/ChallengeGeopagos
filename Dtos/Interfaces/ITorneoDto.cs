namespace Dtos
{
	public interface ITorneoDto
	{
		int Id { get; set; }
		DateTime? FechaFinalizacion { get; set; }
		string? Ganador { get; set; }
		List<PartidoFemeninoDto> PartidosFemeninos { get; set; }
		List<PartidoMasculinoDto> PartidosMasculinos { get; set; }
	}
}