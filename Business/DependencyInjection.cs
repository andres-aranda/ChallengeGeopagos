using Data;
using Data.Repositorios;
using Data.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
	public static class DependencyInjection
	{
		public static void AddRepositories(IServiceCollection services,string connectionString)
		{
			services.AddSingleton(AutoMapperConfig.Initialize());
			services.AddScoped<IRepositorioJugadoresFemeninos,RepositorioJugadoresFemeninos>();
			services.AddScoped<IRepositorioJugadoresMasculinos,RepositorioJugadoresMasculinos>();
			services.AddScoped<IRepositorioPartidosFemeninos,RepositorioPartidosFemeninos>();
			services.AddScoped<IRepositorioPartidosMasculinos,RepositorioPartidosMasculinos>();
			services.AddScoped<IRepositorioTorneos,RepositorioTorneos>();
			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(connectionString);
			});
		}
	}
}
