namespace Dtos
{
	public interface IJugadorDto
	{
		public int Id { get; set; }
		public string? Nombre { get; set; }
		public int NivelHabilidad { get; set; }
		public int Suerte(IJugadorDto contrincante);

	}
}
