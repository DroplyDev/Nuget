namespace Repository.Tests;

public class FirstTests
{
    [Fact]
    public async Task First_Returns_Entity_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var entities = await context.InitTestEntitiesAsync();

        //Act
        var response = testRepo.First(e => e.Name == "John");

        //Assert
        response.Should().NotBeNull();
        response.Should().Be(entities[0]);
    }

    [Fact]
    public async Task FirstAsync_Returns_Entity_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var entities = await context.InitTestEntitiesAsync();

        //Act
        var response = await testRepo.FirstAsync(e => e.Name == "John");

        //Assert
        response.Should().NotBeNull();
        response.Should().Be(entities[0]);
    }

    [Fact]
    public async Task FirstOrDefault_Returns_Entity_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var entities = await context.InitTestEntitiesAsync();

        //Act
        var response = testRepo.FirstOrDefault(e => e.Name == "John");

        //Assert
        response.Should().NotBeNull();
        response.Should().Be(entities[0]);
    }
    [Fact]
    public async Task FirstOrDefault_Returns_Null_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var entities = await context.InitTestEntitiesAsync();

        //Act
        var response = testRepo.FirstOrDefault(e => e.Name == "Alexander");

        //Assert
        response.Should().BeNull();
    }

    [Fact]
    public async Task FirstOrDefaultAsync_Returns_Entity_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var entities = await context.InitTestEntitiesAsync();

        //Act
        var response = await testRepo.FirstOrDefaultAsync(e => e.Name == "John");

        //Assert
        response.Should().NotBeNull();
        response.Should().Be(entities[0]);
    }

    [Fact]
    public async Task FirstOrDefaultAsync_Returns_Null_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var entities = await context.InitTestEntitiesAsync();

        //Act
        var response =await  testRepo.FirstOrDefaultAsync(e => e.Name == "Alexander");

        //Assert
        response.Should().BeNull();
    }
}