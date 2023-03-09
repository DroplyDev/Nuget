using Microsoft.EntityFrameworkCore;
using Repository.Tests.TestTypes.Entities;


namespace Repository.Tests.TestTypes.Database
{
    public class TestDbContext : DbContext, IAsyncDisposable
    {
        public TestDbContext() : base(GetOptions())
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        private static DbContextOptions<DbContext> GetOptions()
        {
            return new DbContextOptionsBuilder<DbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options
                ;
        }

        public override async ValueTask DisposeAsync()
        {
            // Perform async cleanup.
             Database.EnsureDeleted();
        }

        public DbSet<TestEntity> TestEntities { get; set; }
    }
}
