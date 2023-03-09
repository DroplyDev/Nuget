﻿using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Implementation;

public partial class BaseRepo<TContext, TEntity> where TEntity : class where TContext : DbContext
{
    public virtual IQueryable<TEntity> GetAll()
    {
        return DbSet;
    }
}