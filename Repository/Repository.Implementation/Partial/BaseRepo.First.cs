using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository.Implementation;

public partial class BaseRepo<TContext, TEntity> where TEntity : class where TContext : DbContext
{
    public virtual TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> expression,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null)
    {
        return IncludeIfNotNull(includes).FirstOrDefault(expression);
    }

    public virtual async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression,
        CancellationToken cancellationToken = default,
        Func<IQueryable<TEntity>,
            IQueryable<TEntity>>? includes = null)
    {
        return await IncludeIfNotNull(includes).FirstOrDefaultAsync(expression, cancellationToken);
    }


    public virtual TEntity First(Expression<Func<TEntity, bool>> expression,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null)
    {
        return IncludeIfNotNull(includes).First(expression);
    }

    public virtual async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> expression,
        CancellationToken cancellationToken = default,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null)
    {
        return await IncludeIfNotNull(includes).FirstAsync(expression, cancellationToken);
    }

    protected IQueryable<TEntity> IncludeIfNotNull(
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null)
    {
        return includes is null ? DbSet : includes(DbSet);
    }
}