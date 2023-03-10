using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Implementation;

public abstract partial class BaseRepo<TContext, TEntity> : IBaseRepo<TEntity>
    where TEntity : class where TContext : DbContext
{
    protected readonly TContext Context;
    protected readonly DbSet<TEntity> DbSet;

    protected BaseRepo(TContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }
}