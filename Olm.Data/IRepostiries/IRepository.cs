using Olm.Data.Contexts;
using Olm.Domain.Commons;
using System.Linq.Expressions;

namespace Olm.Data.IRepostiries;

public interface IRepository<T> where T : Auditable
{
    Task CreateAsync(T entity);
    void Delete(T entity);
    void Destroy(T entity);
    void Update(T entity);
    Task<T> GetAsync(Expression<Func<T, bool>> expresstion, string[] includes = null);
    IQueryable<T> GetAll(Expression<Func<T, bool>> expresstion = null, bool isNoTracked = true, string[] includes = null);
    Task SaveAsync();
}
