using AutoMapper;
using Data.Dominio;
using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
