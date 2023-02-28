using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public partial class BaseRepo<TContext, TEntity> where TEntity : class where TContext : DbContext
    {
        public virtual void Attach(TEntity entity)
        {
            DbSet.Attach(entity);
        }

        public virtual void AttachRange(IEnumerable<TEntity> entities)
        {
            DbSet.AttachRange(entities);
        }
    }
}
