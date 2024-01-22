using Data.Dominio;
using Data.Dominio.Interfaces;
using Data.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositorios
{
	public class RepositorioTorneos(ApplicationDbContext context) : IRepositorioTorneos
	{
		private readonly ApplicationDbContext _context = context;



		public IEnumerable<ITorneo> GetAll()
		{
			return _context.Torneos
				.Include(t => t.PartidosMasculinos)
				.ThenInclude(t => t.Ganador)
				.Include(t => t.PartidosFemeninos)
				.ThenInclude(t => t.Ganador)
				.OrderBy(t => t.Id)
				.AsSplitQuery()
				.ToList();
		}

		public IEnumerable<ITorneo> GetFromQuery(System.Linq.Expressions.Expression<Func<ITorneo, bool>> query)
		{
			return _context.Torneos.Where(query).Include(t => t.PartidosMasculinos)
				.ThenInclude(t => t.Ganador)
				.Include(t => t.PartidosFemeninos)
				.ThenInclude(t => t.Ganador)
				.OrderBy(t => t.Id)
				.AsSplitQuery()
				.ToList();
		}

		public ITorneo? GetById(int id)
		{
			return _context.Torneos.
				Include(t => t.PartidosMasculinos)
				.ThenInclude(t => t.Jugador1)
				.Include(t => t.PartidosMasculinos)
				.ThenInclude(t => t.Jugador2)
				.Include(t => t.PartidosMasculinos)
				.ThenInclude(t => t.Ganador)
				.Include(t => t.PartidosFemeninos)
				.ThenInclude(t => t.Jugador1)
				.Include(t => t.PartidosFemeninos)
				.ThenInclude(t => t.Jugador2)
				.Include(t => t.PartidosFemeninos)
				.ThenInclude(t => t.Ganador)
				.OrderBy(t => t.Id)
				.AsSplitQuery()
				.FirstOrDefault(j => j.Id == id);
		}

		public ITorneo? Add(ITorneo entity)
		{
			var domainEntity = (Torneo)entity;
			var neeTorneo = _context.Torneos.Add(domainEntity);
			_context.SaveChanges();
			return neeTorneo.Entity;
		}

		public ITorneo? Update(ITorneo entity)
		{

			var domainEntity = (Torneo)entity;
			var itemToUpdate = _context.Torneos.Find(domainEntity.Id);

			if (itemToUpdate != null)
				_context.Entry(itemToUpdate).CurrentValues.SetValues(domainEntity);

			_context.SaveChanges();
			return itemToUpdate;
		}

		public void Delete(int id)
		{
			var itemToRemove = _context.Torneos.FirstOrDefault(j => j.Id == id);
			if (itemToRemove != null)
				_context.Torneos.Remove(itemToRemove);
			_context.SaveChanges();
		}
		public void AddRange(IEnumerable<ITorneo> entities)
		{
			var domainEntities = entities.Cast<Torneo>();
			_context.Torneos.AddRange(domainEntities);
			_context.SaveChanges();
		}

		public Torneo? FinalizarTorneo(int idTorneo)
		{

			var itemToUpdate = _context.Torneos.Find(idTorneo);

			if (itemToUpdate == null)
				return null;
			
			_context.Entry(itemToUpdate);

			itemToUpdate.FechaFinalizacion = DateTime.Today;

			_context.SaveChanges();

			return itemToUpdate;
		}
	}

}
