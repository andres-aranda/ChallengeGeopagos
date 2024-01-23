using Data.Dominio;
using Data.Dominio.Interfaces;
using Data.Repositorios.Interfaces;

namespace Data.Repositorios
{
	public class RepositorioJugadoresFemeninos(ApplicationDbContext context) : IRepositorioJugadoresFemeninos
	{
		private readonly ApplicationDbContext _context = context;



		public IEnumerable<IJugadorFemenino> GetAll()
		{
			var jugadoras = _context.JugadoresFemeninos.ToList();
			return jugadoras;
		}

		public IEnumerable<IJugadorFemenino> GetFromQuery(System.Linq.Expressions.Expression<Func<IJugadorFemenino, bool>> query)
		{
			return _context.JugadoresFemeninos.Where(query).ToList();
		}

		public IJugadorFemenino? GetById(int id)
		{
			return _context.JugadoresFemeninos.FirstOrDefault(j => j.Id == id);
		}

		public IJugadorFemenino Add(IJugadorFemenino entity)
		{
			var domainEntity = (JugadorFemenino)entity;
			var newJugador = _context.JugadoresFemeninos.Add(domainEntity);
			_context.SaveChanges();
			return newJugador.Entity;

		}

		public IJugadorFemenino? Update(IJugadorFemenino entity)
		{

			var domainEntity = (JugadorFemenino)entity;
			var itemToUpdate = _context.JugadoresFemeninos.Find(domainEntity.Id);

			if (itemToUpdate != null)
				_context.Entry(itemToUpdate).CurrentValues.SetValues(domainEntity);

			_context.SaveChanges();

			return itemToUpdate;
		}

		public bool Delete(int id)
		{
			var itemToRemove = _context.JugadoresFemeninos.FirstOrDefault(j => j.Id == id);
			if (itemToRemove != null)
				_context.JugadoresFemeninos.Remove(itemToRemove);
			return _context.SaveChanges() > 0;
		}
		public void AddRange(IEnumerable<IJugadorFemenino> entities)
		{
			var domainEntities = entities.Cast<JugadorFemenino>();
			_context.JugadoresFemeninos.AddRange(domainEntities);
			_context.SaveChanges();
		}
	}


}
