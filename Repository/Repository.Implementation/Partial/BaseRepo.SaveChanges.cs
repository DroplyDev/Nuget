using Microsoft.EntityFrameworkCore;

namespace Repository.Implementation;

public partial class BaseRepo<TContext, TEntity> where TEntity : class where TContext : DbContext
{
    public async Task<int> SaveChangesAsync()
    {
        return await Context.SaveChangesAsync();
    }
}