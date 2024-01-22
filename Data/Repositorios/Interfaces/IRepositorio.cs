using System.Linq.Expressions;

namespace Data.Repositorios.Interfaces
{
	public interface IRepositorio<T> where T : class
	{
		IEnumerable<T> GetAll();
		IEnumerable<T> GetFromQuery(Expression<Func<T, bool>> query);
		T? GetById(int id);
		T? Add(T entity);
		void AddRange(IEnumerable<T> entities);
		T? Update(T entity);
		void Delete(int id);
	}
}
