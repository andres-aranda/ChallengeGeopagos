using Data.Dominio;
using Data.Dominio.Interfaces;
using Data.Repositorios.Interfaces;

namespace Data.Repositorios
{
	public class RepositorioJugadoresFemeninos : IRepositorioJugadoresFemeninos
	{
		private readonly ApplicationDbContext _context;

		public RepositorioJugadoresFemeninos(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<IJugadorFemenino> GetAll()
		{
			return _context.JugadoresFemeninos.ToList();
		}

		public IEnumerable<IJugadorFemenino> GetFromQuery(System.Linq.Expressions.Expression<Func<IJugadorFemenino, bool>> query)
		{
			return _context.JugadoresFemeninos.Where(query).ToList();
		}

		public IJugadorFemenino? GetById(int id)
		{
			return _context.JugadoresFemeninos.FirstOrDefault(j => j.Id == id);
		}

		public void Add(IJugadorFemenino entity)
		{
			var domainEntity = (JugadorFemenino)entity;
			_context.JugadoresFemeninos.Add(domainEntity);
			_context.SaveChanges();
		}

		public void Update(IJugadorFemenino entity)
		{

			var domainEntity = (JugadorFemenino)entity;
			var itemToUpdate = _context.JugadoresFemeninos.Find(domainEntity.Id);

			if (itemToUpdate != null)
				_context.Entry(itemToUpdate).CurrentValues.SetValues(domainEntity);

			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var itemToRemove = _context.JugadoresFemeninos.FirstOrDefault(j => j.Id == id);
			if (itemToRemove != null)
				_context.JugadoresFemeninos.Remove(itemToRemove);
			_context.SaveChanges();
		}
		public void AddRange(IEnumerable<IJugadorFemenino> entities)
		{
			var domainEntities = entities.Cast<JugadorFemenino>();
			_context.JugadoresFemeninos.AddRange(domainEntities);
			_context.SaveChanges();
		}
	}


}
