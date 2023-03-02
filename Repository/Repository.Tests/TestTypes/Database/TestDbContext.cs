using Microsoft.EntityFrameworkCore;
using Repository.Tests.TestTypes.Entities;


namespace Repository.Tests.TestTypes.Database
{
    public class TestDbContext : DbContext, IAsyncDisposable
    {
        public DbSet<TestEntity> TestEntities { get; set; }

        public TestDbContext() : base(GetOptions())
        {
            Database.EnsureCreated();
        }

        private static DbContextOptions<DbContext> GetOptions()
        {
            return new DbContextOptionsBuilder<DbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        public override async ValueTask DisposeAsync()
        {
            // Perform async cleanup.
            await Database.EnsureDeletedAsync();
        }

    }
}
