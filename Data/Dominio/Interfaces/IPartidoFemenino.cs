namespace Data.Dominio.Interfaces
{
	public interface IPartidoFemenino : IPartido
	{
		public JugadorFemenino? Jugador1 { get; set; }
		public JugadorFemenino? Jugador2 { get; set; }
	}

}
