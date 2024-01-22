using Data.Dominio;
using Data.Dominio.Interfaces;

namespace Data.Repositorios.Interfaces
{
	public interface IRepositorioTorneos : IRepositorio<ITorneo>
	{
		Torneo? FinalizarTorneo(int idTorneo);
	}
}