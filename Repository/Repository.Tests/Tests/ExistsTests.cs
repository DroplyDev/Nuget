namespace Repository.Tests;

[TestCaseOrderer("Repository.Tests.CustomTestMethodOrderer", "Repository.Tests")]
public class ExistsTests
{
    [Fact]
    public async Task ExistsAsyncById_Returns_True_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        TestRepository testRepo = new TestRepository(context);

        var entity = await context.InitTestEntityAsync();
        //Act
        var response = await testRepo.ExistsAsync(entity.Id);
        //Assert
        response.Should().BeTrue();
    }
    [Fact]
    public async Task ExistsAsyncById_Returns_False_When_NotFound()
    {
        //Arrange
        await using var context = new TestDbContext();
        TestRepository testRepo = new TestRepository(context);

        await context.InitTestEntityAsync();
        //Act
        var response = await testRepo.ExistsAsync(2);
        //Assert
        response.Should().BeFalse();
    }
    [Fact]
    public async Task ExistsAsyncByExpression_Returns_True_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        TestRepository testRepo = new TestRepository(context);

        var entity = await context.InitTestEntityAsync();
        //Act
        var response = await testRepo.ExistsAsync(e => e.Name == entity.Name);
        //Assert
        response.Should().BeTrue();
    }
    [Fact]
    public async Task ExistsAsyncByExpression_Returns_False_When_NotFound()
    {
        //Arrange
        await using var context = new TestDbContext();
        TestRepository testRepo = new TestRepository(context);

        await context.InitTestEntityAsync();
        //Act
        var response = await testRepo.ExistsAsync(e => e.Name == "WrongName");
        //Assert
        response.Should().BeFalse();
    }
    [Fact]
    public async Task ExistsAsyncByEntity_Returns_True_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        TestRepository testRepo = new TestRepository(context);

        var entity = await context.InitTestEntityAsync();
        //Act
        var response = await testRepo.ExistsAsync(entity);
        //Assert
        response.Should().BeTrue();
    }
    [Fact]
    public async Task ExistsAsyncByEntity_Returns_False_When_NotFound()
    {
        //Arrange
        await using var context = new TestDbContext();
        TestRepository testRepo = new TestRepository(context);

        await context.InitTestEntityAsync();

        //Act
        var response = await testRepo.ExistsAsync(new TestEntity { Id = 2, Name = "WrongName" });
        //Assert
        response.Should().BeFalse();
    }
}