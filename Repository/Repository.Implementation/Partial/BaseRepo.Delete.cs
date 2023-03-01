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
        public async Task DeleteAsync(TEntity entity)
        {
            DeleteNoSave(entity);
            await SaveChangesAsync();
        }


        public async Task DeleteAsync(object id)
        {
            var entity = await GetByIdAsync(id, CancellationToken.None)
                         ?? throw new NullReferenceException();

            DeleteNoSave(entity);
            await SaveChangesAsync();
        }


        public virtual void DeleteNoSave(TEntity entity)
        {
            DbSet.Remove(entity);
        }


        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            DeleteNoSaveRange(entities);
            await SaveChangesAsync();
        }


        public virtual void DeleteNoSaveRange(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }
    }
}
