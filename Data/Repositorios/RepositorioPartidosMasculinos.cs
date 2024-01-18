using Data.Dominio;
using Data.Dominio.Interfaces;
using Data.Repositorios.Interfaces;

namespace Data.Repositorios
{
	public class RepositorioPartidosMasculinos : IRepositorioPartidosMasculinos
	{
		private readonly ApplicationDbContext _context;

		public RepositorioPartidosMasculinos(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<IPartidoMasculino> GetAll()
		{
			return _context.PartidosMasculinos.ToList();
		}

		public IEnumerable<IPartidoMasculino> GetFromQuery(System.Linq.Expressions.Expression<Func<IPartidoMasculino, bool>> query)
		{
			return _context.PartidosMasculinos.Where(query).ToList();
		}

		public IPartidoMasculino? GetById(int id)
		{
			return _context.PartidosMasculinos.FirstOrDefault(j => j.Id == id);
		}

		public void Add(IPartidoMasculino entity)
		{
			var domainEntity = (PartidoMasculino)entity;
			_context.PartidosMasculinos.Add(domainEntity);
			_context.SaveChanges();
		}

		public void Update(IPartidoMasculino entity)
		{

			var domainEntity = (PartidoMasculino)entity;
			var itemToUpdate = _context.PartidosMasculinos.Find(domainEntity.Id);

			if (itemToUpdate != null)
				_context.Entry(itemToUpdate).CurrentValues.SetValues(domainEntity);

			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var itemToRemove = _context.PartidosMasculinos.FirstOrDefault(j => j.Id == id);
			if (itemToRemove != null)
				_context.PartidosMasculinos.Remove(itemToRemove);
			_context.SaveChanges();
		}
		public void AddRange(IEnumerable<IPartidoMasculino> entities)
		{
			var domainEntities = entities.Cast<PartidoMasculino>();
			_context.PartidosMasculinos.AddRange(domainEntities);
			_context.SaveChanges();
		}
	}

}
