using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Repository.Implementation;

public partial class BaseRepo<TContext, TEntity> where TEntity : class where TContext : DbContext
{
    public async Task<bool> IsEmptyAsync(CancellationToken cancellationToken = default)
    {
        return !await DbSet.AnyAsync(cancellationToken);
    }


    public async Task<bool> IsEmptyAsync(Expression<Func<TEntity, bool>> expression,
        CancellationToken cancellationToken = default)
    {
        return !await DbSet.AnyAsync(expression, cancellationToken);
    }
}