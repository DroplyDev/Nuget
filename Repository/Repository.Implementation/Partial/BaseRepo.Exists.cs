using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Repository.Implementation;

public partial class BaseRepo<TContext, TEntity> where TEntity : class where TContext : DbContext
{
    public virtual async Task<bool> ExistsAsync(object id, CancellationToken cancellationToken = default)
    {
        try
        {
            return await GetByIdAsync(id, cancellationToken) is not null;
        }
        catch(Exception ex)
        {
            return false;
        }  
    }


    public virtual async Task<bool> ExistsAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return await DbSet.AnyAsync(item => item.Equals(entity), cancellationToken);
    }


    public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression,
        CancellationToken cancellationToken = default)
    {
        return await DbSet.AnyAsync(expression, cancellationToken);
    }
}