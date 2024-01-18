using Microsoft.EntityFrameworkCore;

namespace Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
		public DbSet<Dominio.PartidoFemenino> PartidosFemeninos { get; set; }
		public DbSet<Dominio.PartidoMasculino> PartidosMasculinos { get; set; }
		public DbSet<Dominio.JugadorFemenino> JugadoresFemeninos { get; set; }
		public DbSet<Dominio.JugadorMasculino> JugadoresMasculinos { get; set; }
		public DbSet<Dominio.Torneo> Torneos { get; set; }


	}
}
