using Data.Dominio.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Dominio
{
	public class PartidoMasculino : IPartidoMasculino
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[ForeignKey("Jugador1")]
		public int IdJugador1 { get; set; }
		[ForeignKey("Jugador2")]
		public int IdJugador2 { get; set; }
		[ForeignKey("Ganador")]
		public int? IdGanador { get; set; }
		[ForeignKey("Torneo")]
		public int? IdTorneo { get; set; }
		[ForeignKey("PartidoSiguiente")]
		public int? IPartidoSiguiente { get; set; }
		public virtual Torneo? Torneo { get; set; }
		public virtual JugadorMasculino? Jugador1 { get; set; }
		public virtual JugadorMasculino? Jugador2 { get; set; }
		public virtual JugadorMasculino? Ganador { get; set; }
		public virtual PartidoMasculino? PartidoSiguiente { get; set; }
	}
}
