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
    public partial class BaseRepo<TContext, TEntity> : IBaseRepo<TEntity> where TEntity : class where TContext : DbContext
    {
        protected readonly TContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected BaseRepo(TContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }
    }

}
