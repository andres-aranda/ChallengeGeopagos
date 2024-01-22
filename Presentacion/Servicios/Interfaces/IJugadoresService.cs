using Dtos;

namespace Presentacion.Servicios.Interfaces
{
    public interface IJugadoresService
    {
        Task<bool> BorrarFemenino(int id);
        Task<bool> BorrarMasculino(int id);
        Task<bool> CrearFemenino(JugadorFemeninoDto jugador);
        Task<bool> CrearMasculino(JugadorMasculinoDto jugador);
        Task<IEnumerable<JugadorFemeninoDto>?> ObtenerFemeninos();
        Task<IEnumerable<JugadorMasculinoDto>?> ObtenerMasculinos();
    }
}