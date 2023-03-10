namespace Repository.Tests;

public class IsEmptyTests
{
    [Fact]
    public async Task IsEmptyAsync_Returns_True_When_Empty()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        //Act
        var response = await testRepo.IsEmptyAsync();
        //Assert
        response.Should().BeTrue();
    }

    [Fact]
    public async Task IsEmptyAsync_Returns_False_When_NotEmpty()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        await context.InitTestEntitiesAsync();
        //Act
        var response = await testRepo.IsEmptyAsync();
        //Assert
        response.Should().BeFalse();
    }
}