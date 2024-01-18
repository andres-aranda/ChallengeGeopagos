namespace Data.Dominio.Interfaces
{
	public interface IJugadorMasculino : IJugador
	{
		public int Fuerza { get; set; }
		public int Velocidad { get; set; }
	}
}
