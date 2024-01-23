using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Interfeces;
using Data.Dominio;
using Data.Dominio.Interfaces;
using Data.Repositorios.Interfaces;
using Dtos;

namespace Business.Services
{
	public class ServiceTorneos(IMapper mapper, IRepositorioTorneos repositorioTorneos, IServicePartidos servicePartidos) : IServiceTorneos
	{
		private readonly IRepositorioTorneos RepositorioTorneos = repositorioTorneos;
		private readonly IMapper Mapper = mapper;
		private readonly IServicePartidos ServicePartidos = servicePartidos;

		public IEnumerable<ITorneoDto> GetAllTorneos()
		{
			var torneosDominio = RepositorioTorneos.GetAll();
			var torneos = Mapper.Map<List<TorneoDto>>(torneosDominio);
			return torneos;
		}
		public ITorneoDto? CrearTorneo(List<IJugadorDto> Jugadores)
		{
			if (Jugadores.Count % 2 == 0
				&& (Jugadores.Count / 2) % 2 == 0)
			{
				var torneoDto = new TorneoDto();

				var partidos = ServicePartidos.CrearPartidos(Jugadores);

				if (partidos == null)
					return null;

				partidos.ForEach(partido =>
				{
					if (partido is PartidoMasculinoDto partidoMasculinoDto)
						torneoDto.PartidosMasculinos.Add(partidoMasculinoDto);
					else if (partido is PartidoFemeninoDto partidoFemeninoDto)
						torneoDto.PartidosFemeninos.Add(partidoFemeninoDto);
				});

				var torneo = Mapper.Map<TorneoDto, Torneo>(torneoDto);
				RepositorioTorneos.Add(torneo);
				return Mapper.Map<Torneo, TorneoDto>(torneo);
			}
			return null;

		}

		public ITorneoDto? FinalizarTorneo(int id)
		{
			var torneo = RepositorioTorneos.GetById(id);
			if (torneo == null)
				return null;

			var torneoDto = Mapper.Map<Torneo, TorneoDto>(torneo as Torneo);
			var listaDePartidos = new List<IPartidoDto>(torneoDto.PartidosMasculinos);
			listaDePartidos.AddRange(torneoDto.PartidosFemeninos);

			while (listaDePartidos.Count >= 1)
			{
				listaDePartidos = ServicePartidos.DeterminarGanadores(listaDePartidos);
				if (listaDePartidos.Count % 2 == 0)
				{
					var nuevosPartidos = new List<IPartidoDto>();
					for (int i = 0; i < listaDePartidos.Count; i += 2)
					{
						var proximoPartido = ServicePartidos.CrearProximoPartido(listaDePartidos[i], listaDePartidos[i + 1]);
						if (proximoPartido != null)
							nuevosPartidos.Add(proximoPartido);
					}
					listaDePartidos = nuevosPartidos;
				}
				else
				{
					ServicePartidos.DeterminarGanadores(listaDePartidos);
					listaDePartidos = new List<IPartidoDto>();
				}
			}
			RepositorioTorneos.FinalizarTorneo(torneoDto.Id);
			torneo = RepositorioTorneos.GetById(id);
			torneoDto = Mapper.Map<Torneo, TorneoDto>(torneo as Torneo);


			return torneoDto;
		}

		public IEnumerable<ITorneoDto> GetAllTorneosFinalizados(bool? masculino, DateTime? fechaDesde, DateTime? fechaHasta)
		{
			Expression<Func<ITorneo, bool>> query = t => t.FechaFinalizacion != null;

			query = AddFilter(query, t => masculino == true, t => t.PartidosMasculinos.Count > 0);
			query = AddFilter(query, t => masculino == false, t => t.PartidosFemeninos.Count > 0);
			query = AddFilter(query, t => fechaDesde != null, t => t.FechaFinalizacion >= fechaDesde.Value);
			query = AddFilter(query, t => fechaHasta != null, t => t.FechaFinalizacion <= fechaHasta.Value);

			var torneosDominio = RepositorioTorneos.GetFromQuery(query);


			var torneos = Mapper.Map<List<TorneoDto>>(torneosDominio);
			return torneos;
		}
		public bool BorrarTorneo(int id)
		{
			RepositorioTorneos.Delete(id);
			return true;
		}

		private Expression<Func<T, bool>> AddFilter<T>(
		Expression<Func<T, bool>> baseExpression,
		Expression<Func<T, bool>> condition,
		Expression<Func<T, bool>> filter)
		{
			var combinedCondition = Expression.AndAlso(condition.Body, filter.Body);

			var lambda = Expression.Lambda<Func<T, bool>>(combinedCondition, baseExpression.Parameters);

			return Expression.Lambda<Func<T, bool>>(
				Expression.AndAlso(baseExpression.Body, lambda.Body),
				baseExpression.Parameters);
		}
	}
}
