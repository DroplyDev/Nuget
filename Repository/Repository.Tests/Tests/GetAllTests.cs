namespace Repository.Tests;

[TestCaseOrderer("Repository.Tests.CustomTestMethodOrderer", "Repository.Tests")]
public class GetAllTests
{
    [Fact]
    public async Task GetAll_Returns_EntityList_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var entities = await context.InitTestEntitiesAsync();
        //Act
        var response = await testRepo.GetAll().ToListAsync();
        //Assert
        response.Should().BeEquivalentTo(entities);
    }

    [Fact]
    public async Task GetAll_Returns_EmptyList_When_Empty()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        //Act
        var response = await testRepo.GetAll().ToListAsync();
        //Assert
        response.Count.Should().Be(0);
    }
}