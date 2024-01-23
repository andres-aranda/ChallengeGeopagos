using Data.Dominio;
using Data.Dominio.Interfaces;
using Data.Repositorios.Interfaces;

namespace Data.Repositorios
{
	public class RepositorioJugadoresMasculinos : IRepositorioJugadoresMasculinos
	{
		private readonly ApplicationDbContext _context;

		public RepositorioJugadoresMasculinos(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<IJugadorMasculino> GetAll()
		{
			var x = _context.JugadoresMasculinos.ToList();
			return x;
		}

		public IEnumerable<IJugadorMasculino> GetFromQuery(System.Linq.Expressions.Expression<Func<IJugadorMasculino, bool>> query)
		{
			return _context.JugadoresMasculinos.Where(query).ToList();
		}

		public IJugadorMasculino? GetById(int id)
		{
			return _context.JugadoresMasculinos.FirstOrDefault(j => j.Id == id);
		}

		public IJugadorMasculino? Add(IJugadorMasculino entity)
		{
			var domainEntity = (JugadorMasculino)entity;
			_context.JugadoresMasculinos.Add(domainEntity);
			_context.SaveChanges();
			return domainEntity;

		}

		public IJugadorMasculino? Update(IJugadorMasculino entity)
		{

			var domainEntity = (JugadorMasculino)entity;
			var itemToUpdate = _context.JugadoresMasculinos.Find(domainEntity.Id);

			if (itemToUpdate != null)
				_context.Entry(itemToUpdate).CurrentValues.SetValues(domainEntity);

			_context.SaveChanges();

			return itemToUpdate;
		}

		public bool Delete(int id)
		{
			var itemToRemove = _context.JugadoresMasculinos.FirstOrDefault(j => j.Id == id);
			if (itemToRemove != null)
				_context.JugadoresMasculinos.Remove(itemToRemove);
			return _context.SaveChanges() > 0;
		}
		public void AddRange(IEnumerable<IJugadorMasculino> entities)
		{
			var domainEntities = entities.Cast<JugadorMasculino>();
			_context.JugadoresMasculinos.AddRange(domainEntities);
			_context.SaveChanges();
		}
	}

}
