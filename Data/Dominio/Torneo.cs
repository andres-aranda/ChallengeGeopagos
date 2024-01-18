using Data.Dominio.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Data.Dominio
{
	public class Torneo : ITorneo
	{
		[Key]
		public int Id { get; set; }

		public DateTime? FechaFinalizacion { get; set; }

		public virtual List<PartidoMasculino> PartidosMasculinos { get; set; } = new List<PartidoMasculino>();
		public virtual List<PartidoFemenino> PartidosFemeninos { get; set; } = new List<PartidoFemenino>();
	}
}
