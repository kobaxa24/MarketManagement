using System.Linq.Expressions;

namespace Market.Services.Interfaces.Repositories;

public interface IRepository<T> where T : class
{
    T? GetById(object id);
    IEnumerable<T> GetAll();
    IEnumerable<T> Query(Expression<Func<T, bool>> predicate);
    object Insert(T entity);
    void Update(T entity);
    void Delete(object id);
}
