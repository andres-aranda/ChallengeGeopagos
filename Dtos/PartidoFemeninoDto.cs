
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dtos
{
	public class PartidoFemeninoDto : IPartidoDto
	{
		[Key]
		public int Id { get; set; }
		public int IdJugador1 { get; set; }
		public int IdJugador2 { get; set; }
		public int? IdGanador { get; set; }
		public int? IdTorneo { get; set; }
		public int? IPartidoSiguiente { get; set; }

		public virtual TorneoDto? Torneo { get; set; }
		public virtual JugadorFemeninoDto? Jugador1 { get; set; }
		public virtual JugadorFemeninoDto? Jugador2 { get; set; }
		public virtual JugadorFemeninoDto? Ganador { get; set; }

		public void DeterminarGanador()
		{
			if (Jugador1 == null || Jugador2 == null)
				return;

			var random = new Random();
			var probabilidadBase = 50;
			var probabilidadJugador1 = probabilidadBase + Jugador1.Suerte(Jugador2);

			var resultado = random.Next(0, 100);
			 if (resultado <= probabilidadJugador1)
			{
				 IdGanador = Jugador1.Id;
				 Ganador = Jugador1;
			 }
			 else
			{
				IdGanador = Jugador2.Id;
				 Ganador = Jugador2;
			 }

		}
	}

}
