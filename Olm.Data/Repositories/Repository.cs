using Microsoft.EntityFrameworkCore;
using Olm.Data.Contexts;
using Olm.Data.IRepostiries;
using Olm.Domain.Commons;
using System.Linq.Expressions;

namespace Olm.Data.Repositories;

public class Repository<T> : IRepository<T> where T : Auditable
{
    private readonly AppDbContext appDbContext;
    private readonly DbSet<T> dbSet;
    public Repository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
        this.dbSet = appDbContext.Set<T>();
    }
    public async Task CreateAsync(T entity)
    {
       await this.dbSet.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        entity.IsDeleted = true;
    }

    public void Update(T entity)
    {
        dbSet.Entry(entity).State = EntityState.Modified;
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> expresstion, string[] includes = null)
    {
        IQueryable<T> query = dbSet.Where(expresstion).AsQueryable();
        if (includes is not null) 
            foreach (var include in includes)
                query = query.Include(include);
        var entity= await query.FirstOrDefaultAsync(expresstion);
        return entity;
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> expresstion = null, bool isNoTracked = true, string[] includes = null)
    {
        IQueryable<T> query = expresstion is null ? dbSet.AsQueryable() : dbSet.Where(expresstion).AsQueryable();
        query = isNoTracked ? query.AsNoTracking() : query;
        
        if (includes is not null)
            foreach (var include in includes) 
                query = query.Include(include);
        return query;
    }

    public void Destroy(T entity)
    {
        this.dbSet.Remove(entity);
    }

    public async Task SaveAsync()
    {
        await this.appDbContext.SaveChangesAsync();
    }
}
