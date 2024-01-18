using System.Linq.Expressions;

namespace Data.Repositorios.Interfaces
{
	public interface IRepositorio<T> where T : class
	{
		IEnumerable<T> GetAll();
		IEnumerable<T> GetFromQuery(Expression<Func<T, bool>> query);
		T? GetById(int id);
		void Add(T entity);
		void AddRange(IEnumerable<T> entities);
		void Update(T entity);
		void Delete(int id);
	}
}
