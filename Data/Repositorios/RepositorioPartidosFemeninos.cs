using Data.Dominio;
using Data.Dominio.Interfaces;
using Data.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositorios
{
	public class RepositorioPartidosFemeninos(ApplicationDbContext context) : IRepositorioPartidosFemeninos
	{
		private readonly ApplicationDbContext _context = context;


		public IEnumerable<IPartidoFemenino> GetAll()
		{
			var conn = _context.Database.GetDbConnection();
			return _context.PartidosFemeninos.ToList();
		}

		public IEnumerable<IPartidoFemenino> GetFromQuery(System.Linq.Expressions.Expression<Func<IPartidoFemenino, bool>> query)
		{
			return _context.PartidosFemeninos.Where(query).ToList();
		}

		public IPartidoFemenino? GetById(int id)
		{
			return _context.PartidosFemeninos.FirstOrDefault(j => j.Id == id);
		}

		public IPartidoFemenino? Add(IPartidoFemenino entity)
		{
			var domainEntity = (PartidoFemenino)entity;
			var newPartidor = _context.PartidosFemeninos.Add(domainEntity);
			_context.SaveChanges();
			return newPartidor.Entity;

		}

		public IPartidoFemenino? Update(IPartidoFemenino entity)
		{

			var domainEntity = (PartidoFemenino)entity;
			var itemToUpdate = _context.PartidosFemeninos.Find(domainEntity.Id);

			if (itemToUpdate != null)
				_context.Entry(itemToUpdate).CurrentValues.SetValues(domainEntity);

			_context.SaveChanges();
			return itemToUpdate;

		}

		public bool Delete(int id)
		{
			var itemToRemove = _context.PartidosFemeninos.FirstOrDefault(j => j.Id == id);
			if (itemToRemove != null)
				_context.PartidosFemeninos.Remove(itemToRemove);
			return _context.SaveChanges() > 0;
		}
		public void AddRange(IEnumerable<IPartidoFemenino> entities)
		{
			var domainEntities = entities.Cast<PartidoFemenino>();
			_context.PartidosFemeninos.AddRange(domainEntities);
			_context.SaveChanges();
		}
	}

}
