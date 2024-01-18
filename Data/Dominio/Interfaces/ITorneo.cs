namespace Data.Dominio.Interfaces
{
	public interface ITorneo
	{
		DateTime? FechaFinalizacion { get; set; }
		int Id { get; set; }
		List<PartidoFemenino> PartidosFemeninos { get; set; }
		List<PartidoMasculino> PartidosMasculinos { get; set; }
	}
}