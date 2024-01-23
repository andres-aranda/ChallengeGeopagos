using AutoMapper;
using Business.Services.Interfeces;
using Data.Dominio;
using Data.Repositorios.Interfaces;
using Dtos;

namespace Business.Services
{
	public class ServicePartidos(IMapper mapper
		, IRepositorioPartidosFemeninos repositorioPartidosFemeninos
		, IRepositorioPartidosMasculinos repositorioPartidosMasculinos) : IServicePartidos
	{
		private readonly IMapper Mapper = mapper;
		private readonly IRepositorioPartidosFemeninos RepositorioPartidosFemeninos = repositorioPartidosFemeninos;
		private readonly IRepositorioPartidosMasculinos RepositorioPartidosMasculinos = repositorioPartidosMasculinos;

		public List<IPartidoDto> CrearPartidos(IList<IJugadorDto> jugadoresDto)
		{
			var partidosDto = new List<IPartidoDto>();
			if (jugadoresDto.Count % 2 == 0)
			{
				for (int i = 0; i < jugadoresDto.Count; i += 2)
				{
					if (jugadoresDto[i] is JugadorMasculinoDto jugadorMasculinoDto1 && jugadoresDto[i + 1] is JugadorMasculinoDto jugadorMasculinoDto2)
						partidosDto.Add(CrearPartidoMasculino(jugadorMasculinoDto1.Id
							, jugadorMasculinoDto2.Id));
					else if (jugadoresDto[i] is JugadorFemeninoDto jugadorFemeninoDto1 && jugadoresDto[i + 1] is JugadorFemeninoDto jugadorFemeninoDto2)
						partidosDto.Add(CrearPartidoFemenino(jugadorFemeninoDto1.Id, jugadorFemeninoDto2.Id));
				}
			}
			return partidosDto;
		}
		public List<IPartidoDto> DeterminarGanadores(List<IPartidoDto> partidosDto)
		{
			partidosDto.ForEach(partidoDto =>
			{
				if (partidoDto is PartidoMasculinoDto partidoMasculinoDto)
				{
					partidoMasculinoDto.DeterminarGanador();
					var partidoMasculino = Mapper.Map<PartidoMasculinoDto, PartidoMasculino>(partidoMasculinoDto);
					RepositorioPartidosMasculinos.Update(partidoMasculino);
				}
				else if (partidoDto is PartidoFemeninoDto partidoFemeninoDto)
				{
					partidoFemeninoDto.DeterminarGanador();
					var partidoFemenino = Mapper.Map<PartidoFemeninoDto, PartidoFemenino>(partidoFemeninoDto);
					RepositorioPartidosFemeninos.Update(partidoFemenino);
				}
			});

			return partidosDto;
		}

		public List<PartidoMasculinoDto> GetAllPartidosMasculinos()
		{
			var partidosMasculinosDominio = RepositorioPartidosMasculinos.GetAll();
			var partidosMasculinos = Mapper.Map<List<PartidoMasculinoDto>>(partidosMasculinosDominio);
			return partidosMasculinos;
		}

		public List<PartidoFemeninoDto> GetAllPartidosFemeninos()
		{
			var partidosFemeninosDominio = RepositorioPartidosFemeninos.GetAll();
			var partidosFemeninos = Mapper.Map<List<PartidoFemeninoDto>>(partidosFemeninosDominio);
			return partidosFemeninos;
		}

		public IPartidoDto? CrearProximoPartido(IPartidoDto partidoDto1, IPartidoDto partidoDto2)
		{
			if (partidoDto1.IdGanador == null
				|| partidoDto2.IdGanador == null
				|| partidoDto1.IdTorneo == null
				|| partidoDto2.IdTorneo == null
				|| partidoDto1.IdTorneo != partidoDto2.IdTorneo
				)
				return null;

			var IdGanador1 = (int)partidoDto1.IdGanador;
			var IdGanador2 = (int)partidoDto2.IdGanador;
			var IdTorneo = (int)partidoDto1.IdTorneo;

			if (partidoDto1 is PartidoMasculinoDto partidoMasculinoDto1 && partidoDto2 is PartidoMasculinoDto partidoMasculinoDto2)
				return CrearPartidoMasculino(IdGanador1, IdGanador2, IdTorneo, partidoMasculinoDto1, partidoMasculinoDto2);
			else if (partidoDto1 is PartidoFemeninoDto partidoFemeninoDto1 && partidoDto2 is PartidoFemeninoDto partidoFemeninoDto2)
				return CrearPartidoFemenino(IdGanador1, IdGanador2, IdTorneo, partidoFemeninoDto1, partidoFemeninoDto2);

			return null;
		}

		private IPartidoDto? CrearPartidoFemenino(int IdGanador1, int IdGanador2, int IdTorneo, PartidoFemeninoDto partidoFemeninoDto1, PartidoFemeninoDto partidoFemeninoDto2)
		{
			var partidoFemenino = new PartidoFemenino();
			partidoFemenino.IdJugador1 = IdGanador1;
			partidoFemenino.IdJugador2 = IdGanador2;
			partidoFemenino.IdTorneo = IdTorneo;
			var nuevopartidoDb = RepositorioPartidosFemeninos.Add(partidoFemenino);
			PartidoFemenino nuevopartido = nuevopartidoDb as PartidoFemenino;
			partidoFemeninoDto1.IPartidoSiguiente = nuevopartido.Id;
			partidoFemeninoDto2.IPartidoSiguiente = nuevopartido.Id;
			RepositorioPartidosFemeninos.Update(Mapper.Map<PartidoFemeninoDto, PartidoFemenino>(partidoFemeninoDto1));
			RepositorioPartidosFemeninos.Update(Mapper.Map<PartidoFemeninoDto, PartidoFemenino>(partidoFemeninoDto2));
			return Mapper.Map<PartidoFemenino, PartidoFemeninoDto>(nuevopartido);
		}

		private IPartidoDto CrearPartidoFemenino(int IdGanador1, int IdGanador2)
		{
			var partidoFemenino = new PartidoFemeninoDto();
			partidoFemenino.IdJugador1 = IdGanador1;
			partidoFemenino.IdJugador2 = IdGanador2;
			return partidoFemenino;
		}

		private IPartidoDto CrearPartidoMasculino(int IdGanador1, int IdGanador2, int IdTorneo, PartidoMasculinoDto partidoMasculinoDto1, PartidoMasculinoDto partidoMasculinoDto2)
		{
			var partidoMasculino = new PartidoMasculino();
			partidoMasculino.IdJugador1 = IdGanador1;
			partidoMasculino.IdJugador2 = IdGanador2;
			partidoMasculino.IdTorneo = IdTorneo;
			var nuevopartidoDb = RepositorioPartidosMasculinos.Add(partidoMasculino);
			PartidoMasculino nuevopartido = (PartidoMasculino)nuevopartidoDb;
			partidoMasculinoDto1.IPartidoSiguiente = nuevopartido.Id;
			partidoMasculinoDto2.IPartidoSiguiente = nuevopartido.Id;
			RepositorioPartidosMasculinos.Update(Mapper.Map<PartidoMasculinoDto, PartidoMasculino>(partidoMasculinoDto1));
			RepositorioPartidosMasculinos.Update(Mapper.Map<PartidoMasculinoDto, PartidoMasculino>(partidoMasculinoDto2));
			return Mapper.Map<PartidoMasculino, PartidoMasculinoDto>(nuevopartido);
		}

		private IPartidoDto CrearPartidoMasculino(int IdGanador1, int IdGanador2)
		{
			var partidoMasculino = new PartidoMasculinoDto();
			partidoMasculino.IdJugador1 = IdGanador1;
			partidoMasculino.IdJugador2 = IdGanador2;
			return partidoMasculino;
		}

	}
}
