using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Repository.Implementation;

public partial class BaseRepo<TContext, TEntity> where TEntity : class where TContext : DbContext
{
    public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
    {
        return DbSet.Where(expression);
    }
}