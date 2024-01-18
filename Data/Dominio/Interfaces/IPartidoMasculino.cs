namespace Data.Dominio.Interfaces
{
	public interface IPartidoMasculino : IPartido
	{
		public JugadorMasculino Jugador1 { get; set; }
		public JugadorMasculino Jugador2 { get; set; }
		public JugadorMasculino Ganador { get; set; }

	}
}
