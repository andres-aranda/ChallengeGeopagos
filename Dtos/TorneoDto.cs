using System.ComponentModel.DataAnnotations;

namespace Dtos
{
	public class TorneoDto: ITorneoDto
	{
		[Key]
		public int Id { get; set; }

		public DateTime? FechaFinalizacion { get; set; }

		public string? Ganador { get; set; }

		public virtual List<PartidoMasculinoDto> PartidosMasculinos { get; set; } = [];

		public virtual List<PartidoFemeninoDto> PartidosFemeninos { get; set; } = [];
	}
}
