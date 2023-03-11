namespace Repository.Tests;

[TestCaseOrderer("Repository.Tests.CustomTestMethodOrderer", "Repository.Tests")]
public class GetByIdTests
{
    [Fact]
    public async Task GetByIdAsync_Returns_Entity_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var entity = await context.InitTestEntityAsync();
        var request = 1;
        //Act
        var response = await testRepo.GetByIdAsync(request);
        //Assert
        response.Should().NotBeNull();
        response.Should().Be(entity);
    }

    [Fact]
    public async Task GetByIdAsync_Returns_Null_When_EntityWithIdNotFound()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var request = await context.InitTestEntityAsync();
        //Act
        Func<Task> act = async () => await testRepo.GetByIdAsync(25);

        //Assert
        await act.Should().ThrowAsync<NullReferenceException>();
    }
}