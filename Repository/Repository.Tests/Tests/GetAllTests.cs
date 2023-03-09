using Repository.Tests.TestTypes.Database;
using Repository.Tests.TestTypes.Entities;
using Repository.Tests.TestTypes.Repos;

namespace Repository.Tests;

[TestCaseOrderer("Repository.Tests.CustomTestMethodOrderer", "Repository.Tests")]
public class GetAllTests
{
    [Fact]
    public async Task IsNotNull()
    {
        await using var context = new TestDbContext();
        // Creating repository
        TestRepository testRepo = new TestRepository(context);

        // Add some entities to database
        await context.AddAsync(new TestEntity { Id = 1, Name = "John" });
        await context.AddAsync(new TestEntity { Id = 2, Name = "Jack" });

        // retrieve user from the repository
        var usersAll = testRepo.GetAll();

        // assert that the user is not null
        Assert.NotNull(usersAll);
    }

    [Fact]
    public async Task IsCorrectType()
    {
        await using var context = new TestDbContext();
        // Creating repository
        TestRepository testRepo = new TestRepository(context);

        // Add some entities to database
        await context.AddAsync(new TestEntity { Id = 1, Name = "John" });
        await context.AddAsync(new TestEntity { Id = 2, Name = "Jack" });

        // retrieve user from the repository
        var usersAll = testRepo.GetAll().ToList();

        // assert that the user is not null
        Assert.IsType<List<TestEntity>>(usersAll);
    }

    [Fact]
    public async Task IsCorrectValue()
    {
        await using var context = new TestDbContext();
        // Creating repository
        TestRepository testRepo = new TestRepository(context);

        // Add some entities to database
        await context.AddAsync(new TestEntity { Id = 1, Name = "John" });
        await context.AddAsync(new TestEntity { Id = 2, Name = "Jack" });
        await context.SaveChangesAsync();
        // retrieve user from the repository
        var usersAll = testRepo.GetAll();

        Assert.Equal(2, usersAll.Count());
        // assert that the user is not null
        //Assert.Equal("John", usersAll[0].Name);
        //Assert.Equal("Jack", usersAll[1].Name);
    }

}