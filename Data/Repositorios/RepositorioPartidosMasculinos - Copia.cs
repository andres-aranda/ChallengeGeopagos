using Data.Dominio;
using Data.Dominio.Interfaces;
using Data.Repositorios.Interfaces;

namespace Data.Repositorios
{
	public class RepositorioTorneos : IRepositorioTorneos
	{
		private readonly ApplicationDbContext _context;

		public RepositorioTorneos(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<ITorneo> GetAll()
		{
			return _context.Torneos.ToList();
		}

		public IEnumerable<ITorneo> GetFromQuery(System.Linq.Expressions.Expression<Func<ITorneo, bool>> query)
		{
			return _context.Torneos.Where(query).ToList();
		}

		public ITorneo? GetById(int id)
		{
			return _context.Torneos.FirstOrDefault(j => j.Id == id);
		}

		public void Add(ITorneo entity)
		{
			var domainEntity = (Torneo)entity;
			_context.Torneos.Add(domainEntity);
			_context.SaveChanges();
		}

		public void Update(ITorneo entity)
		{

			var domainEntity = (Torneo)entity;
			var itemToUpdate = _context.Torneos.Find(domainEntity.Id);

			if (itemToUpdate != null)
				_context.Entry(itemToUpdate).CurrentValues.SetValues(domainEntity);

			_context.SaveChanges();
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
	}

}
