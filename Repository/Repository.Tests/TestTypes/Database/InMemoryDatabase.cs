using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
using Repository.Tests.TestTypes.Entities;
using System.Linq.Expressions;


namespace Repository.Tests.TestTypes.Database
{
    public class InMemoryDatabase : IDatabase
    {
        // implement the IDatabase interface using an in-memory dictionary
        private readonly IDictionary<int, TestEntity> _data = new Dictionary<int, TestEntity>();

        public void Add(TestEntity entity)
        {
            _data[entity.Id] = entity;
        }

        public Func<QueryContext, TResult> CompileQuery<TResult>(Expression query, bool async)
        {
            throw new NotImplementedException();
        }

        public TestEntity GetById(int id)
        {
            return _data.TryGetValue(id, out var entity) ? entity : null;
        }

        public int SaveChanges(IList<IUpdateEntry> entries)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(IList<IUpdateEntry> entries, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
