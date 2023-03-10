using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository.Implementation;

public partial class BaseRepo<TContext, TEntity> where TEntity : class where TContext : DbContext
{
    public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
    {
        return DbSet.Where(expression);
    }
}