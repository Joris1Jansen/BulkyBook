using System.Linq.Expressions;

namespace BulkyBook.DataAccess.Repository.IRepository;

public interface IRepository<T> where T : class
{
    // T - Category
    T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true);
    IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
    void Add(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}