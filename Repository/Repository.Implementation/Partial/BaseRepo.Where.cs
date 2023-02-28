using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public partial class BaseRepo<TContext, TEntity> where TEntity : class where TContext : DbContext
    {
        public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.Where(expression);
        }
    }
}
