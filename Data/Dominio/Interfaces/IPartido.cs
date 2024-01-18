namespace Data.Dominio.Interfaces
{
	public interface IPartido
	{

		public int Id { get; set; }
		public int IdJugador1 { get; set; }
		public int IdJugador2 { get; set; }
		public int? IdGanador { get; set; }
		public int? IdTorneo { get; set; }

	}
}
