using Microsoft.EntityFrameworkCore;

namespace Repository.Implementation;

public partial class BaseRepo<TContext, TEntity> where TEntity : class where TContext : DbContext
{
    public virtual async Task AttachAsync(TEntity entity)
    {
        DbSet.Attach(entity);
        await SaveChangesAsync();
    }

    public virtual async Task AttachRangeAsync(IEnumerable<TEntity> entities)
    {
        DbSet.AttachRange(entities);
        await SaveChangesAsync();
    }
}