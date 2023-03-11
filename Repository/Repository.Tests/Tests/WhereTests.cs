namespace Repository.Tests;

public class WhereTests
{
    [Fact]
    public async Task Where_Returns_Entity_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var entity = await context.InitTestEntitiesAsync();
        //Act
        var response = testRepo.Where(e => e.Name == "John");
        //Assert
        response.Should().NotBeNull();
        response.Should().HaveCount(1);
        response.Should().Contain(entity[0]);
    }
}