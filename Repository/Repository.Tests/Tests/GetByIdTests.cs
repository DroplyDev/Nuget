namespace Repository.Tests;

[TestCaseOrderer("Repository.Tests.CustomTestMethodOrderer", "Repository.Tests")]
public class GetByIdTests
{
    [Fact]
    public async Task GetByIdAsync_Returns_Entity_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        TestRepository testRepo = new TestRepository(context);

        var entity = await context.InitTestEntityAsync();
        var request = 1;
        //Act
        var response = await testRepo.GetByIdAsync(request);
        //Assert
        response.Should().NotBeNull();
        response.Should().Be(entity);
    }
    [Fact]
    public async Task GetByIdAsync_Returns_Bull_When_EntityWithIdNotFound()
    {
        //Arrange
        await using var context = new TestDbContext();
        TestRepository testRepo = new TestRepository(context);

        await context.InitTestEntityAsync();
        var request = 2;
        //Act
        var response = await testRepo.GetByIdAsync(request);
        //Assert
        response.Should().BeNull();
    }
}