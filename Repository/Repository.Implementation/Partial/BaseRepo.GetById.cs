using Microsoft.EntityFrameworkCore;

namespace Repository.Implementation;

public partial class BaseRepo<TContext, TEntity> where TEntity : class where TContext : DbContext
{
    public async Task<TEntity?> GetByIdAsync(object id, CancellationToken cancellationToken = default)
    {
        return await DbSet.FindAsync(new[] {id}, cancellationToken) ?? throw new NullReferenceException();
    }

    public TEntity? GetById(object id)
    {
        return DbSet.Find(id) ?? throw new NullReferenceException();
    }
}