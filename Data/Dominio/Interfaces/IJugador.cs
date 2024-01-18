namespace Data.Dominio.Interfaces
{
	public interface IJugador
	{
		public int Id { get; set; }
		public string? Nombre { get; set; }
		public int NivelHabilidad { get; set; }

	}
}
