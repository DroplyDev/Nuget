using Repository.Tests.TestTypes.Database;
using Repository.Tests.TestTypes.Entities;
using Repository.Tests.TestTypes.Repos;

namespace Repository.Tests;

[TestCaseOrderer("Repository.Tests.CustomTestMethodOrderer", "Repository.Tests")]
public class SaveChangesTests
{
    [Fact]
    public async Task IsNotNull()
    {
        await using var context = new TestDbContext();
        // Creating repository
        TestRepository testRepo = new TestRepository(context);

        // Add some entities to database
        await context.AddAsync(new TestEntity { Id = 1, Name = "Lucy" });
        await context.AddAsync(new TestEntity { Id = 2, Name = "John" });
        await context.AddAsync(new TestEntity { Id = 3, Name = "Bob" });


        await testRepo.SaveChangesAsync();

        // Assert
        Assert.NotNull(testRepo.GetAll().ToList());
    }

    [Fact]
    public async Task IsCorrectType()
    {
        await using var context = new TestDbContext();
        // Creating repository
        TestRepository testRepo = new TestRepository(context);

        // Add some entities to database
        await context.AddAsync(new TestEntity { Id = 1, Name = "Lucy" });
        await context.AddAsync(new TestEntity { Id = 2, Name = "John" });
        await context.AddAsync(new TestEntity { Id = 3, Name = "Bob" });


        await testRepo.SaveChangesAsync();

        // Assert
        Assert.IsType<List<TestEntity>>(testRepo.GetAll().ToList());
    }

    [Fact]
    public async Task IsCorrectValue()
    {
        await using var context = new TestDbContext();
        // Creating repository
        TestRepository testRepo = new TestRepository(context);

        // Add some entities to database
        await context.AddAsync(new TestEntity { Id = 1, Name = "Lucy" });
        await context.AddAsync(new TestEntity { Id = 2, Name = "John" });
        await context.AddAsync(new TestEntity { Id = 3, Name = "Bob" });


        await testRepo.SaveChangesAsync();

        // Assert
        Assert.Equal(3, testRepo.GetAll().Count());
    }
}