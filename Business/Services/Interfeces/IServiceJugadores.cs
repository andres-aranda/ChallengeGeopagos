using Dtos;

namespace Business.Services.Interfeces
{
    public interface IServiceJugadores
    {
        IJugadorDto? CrearJugador(IJugadorDto jugadorDto);
        IEnumerable<JugadorFemeninoDto> GetAllJugadoresFemeninos();
        IEnumerable<JugadorMasculinoDto> GetAllJugadoresMasculinos();
    }
}