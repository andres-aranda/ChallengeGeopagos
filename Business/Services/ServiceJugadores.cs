using AutoMapper;
using Business.Services.Interfeces;
using Data.Dominio;
using Data.Repositorios.Interfaces;
using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ServiceJugadores(IMapper mapper
        , IRepositorioJugadoresFemeninos repositorioJugadoresFemeninos
        , IRepositorioJugadoresMasculinos repositorioJugadoresMasculinos) : IServiceJugadores
    {
        private readonly IRepositorioJugadoresMasculinos RepositorioJugadoresMasculinos = repositorioJugadoresMasculinos;
        private readonly IRepositorioJugadoresFemeninos RepositorioJugadoresFemeninos = repositorioJugadoresFemeninos;
        private readonly IMapper Mapper = mapper;





        public IEnumerable<JugadorMasculinoDto> GetAllJugadoresMasculinos()
        {
            var jugadoresMasculinosDominio = RepositorioJugadoresMasculinos.GetAll();
            var jugadoresMasculinos = Mapper.Map<List<JugadorMasculinoDto>>(jugadoresMasculinosDominio);
            return jugadoresMasculinos;
        }

        public IEnumerable<JugadorFemeninoDto> GetAllJugadoresFemeninos()
        {
            var jugadoresFemeninosDominio = RepositorioJugadoresFemeninos.GetAll();
            var jugadoresFemeninos = Mapper.Map<List<JugadorFemeninoDto>>(jugadoresFemeninosDominio);
            return jugadoresFemeninos;
        }

        public IJugadorDto? CrearJugador(IJugadorDto jugadorDto)
        {
            if (jugadorDto is JugadorMasculinoDto jugadorMasculinoDto)
            {
                var jugadorMasculino = Mapper.Map<JugadorMasculinoDto
                    , JugadorMasculino>(jugadorMasculinoDto);
                RepositorioJugadoresMasculinos.Add(jugadorMasculino);
                return Mapper.Map<JugadorMasculino, JugadorMasculinoDto>(jugadorMasculino);
            }
            else if (jugadorDto is JugadorFemeninoDto jugadorFemeninoDto)
            {
                var jugadorFemenino = Mapper.Map<JugadorFemeninoDto, JugadorFemenino>(jugadorFemeninoDto);
                RepositorioJugadoresFemeninos.Add(jugadorFemenino);
                return Mapper.Map<JugadorFemenino, JugadorFemeninoDto>(jugadorFemenino);
            }

            return null;
        }
    }
}
