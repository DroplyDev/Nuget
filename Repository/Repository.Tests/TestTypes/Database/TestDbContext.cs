namespace Repository.Tests.TestTypes.Database;

public sealed class TestDbContext : DbContext
{
    public TestDbContext() : base(GetOptions())
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DbSet<TestEntity> TestEntities { get; set; } = null!;

    private static DbContextOptions<DbContext> GetOptions()
    {
        return new DbContextOptionsBuilder<DbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options
            ;
    }

    public override async ValueTask DisposeAsync()
    {
        // Perform async cleanup.
        await Database.EnsureDeletedAsync();
    }
}