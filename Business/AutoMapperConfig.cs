using AutoMapper;
using Data.Dominio;
using Dtos;

namespace Business
{
	public static class AutoMapperConfig
	{
		public static IMapper Initialize()
		{
			var config = new MapperConfiguration(cfg =>
			{
				// Configuraciones de mapeo aquí
				cfg.CreateMap<PartidoMasculinoDto, PartidoMasculino>().ReverseMap();
				cfg.CreateMap<PartidoFemeninoDto, PartidoFemenino>().ReverseMap();
				cfg.CreateMap<TorneoDto, Torneo>().ReverseMap();
				cfg.CreateMap<JugadorMasculinoDto, JugadorMasculino>().ReverseMap();
				cfg.CreateMap<JugadorFemeninoDto, JugadorFemenino>().ReverseMap();

			});

			return config.CreateMapper();
		}
	}
}
