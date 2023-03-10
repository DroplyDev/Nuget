namespace Repository.Tests;

[TestCaseOrderer("Repository.Tests.CustomTestMethodOrderer", "Repository.Tests")]
public class CreateTests
{
    [Fact]
    public async Task CreateNoSaveAsync_Returns_0Elements_When_NotSaved()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var request = new TestEntity { Id = 1, Name = "John" };
        //Act
        await testRepo.CreateNoSaveAsync(request);
        //Assert
        (await context.TestEntities.CountAsync()).Should().Be(0);
    }

    [Fact]
    public async Task CreateAsync_Returns_Entity_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var request = new TestEntity { Id = 1, Name = "John" };
        //Act
        var response = await testRepo.CreateAsync(request);
        //Assert
        response.Should().Be(request);
    }

    [Fact]
    public async Task CreateRangeAsync_Returns_CreatedEntities_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var request = new List<TestEntity>
        {
            new() {Id = 1, Name = "John"},
            new() {Id = 2, Name = "Bob"},
            new() {Id = 3, Name = "Lucy"}
        };
        //Act
        var response = await testRepo.CreateRangeAsync(request);
        //Assert
        response.Should().BeEquivalentTo(request);
    }
}