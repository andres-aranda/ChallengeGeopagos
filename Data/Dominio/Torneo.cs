using Data.Dominio.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Dominio
{
	public class Torneo : ITorneo
	{


		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public DateTime? FechaFinalizacion { get; set; }

		[NotMapped]
		public string Ganador
		{
			get
			{

				var partidosConGanadores = new List<IPartido>();
				partidosConGanadores.AddRange(PartidosMasculinos.Where(p => p.IdGanador != null));
				partidosConGanadores.AddRange(PartidosFemeninos.Where(p => p.IdGanador != null));


				var idGanador = partidosConGanadores.Find(p => p.IPartidoSiguiente == null)?.IdGanador;

				if (idGanador == null)
					return "Aun no hay ganador";

				var ganadorMasculino = PartidosMasculinos.Find(p => p.IdGanador == idGanador)?.Ganador;
				var ganadorFemenino = PartidosFemeninos.Find(p => p.IdGanador == idGanador)?.Ganador;

				if (ganadorMasculino != null)
					return ganadorMasculino.Nombre;
				else if (ganadorFemenino != null)
					return ganadorFemenino.Nombre;
				else
					return "Aun no hay ganador";

			}
			set { }
		}

		public virtual List<PartidoMasculino> PartidosMasculinos { get; set; } = new List<PartidoMasculino>();
		public virtual List<PartidoFemenino> PartidosFemeninos { get; set; } = new List<PartidoFemenino>();
	}
}
