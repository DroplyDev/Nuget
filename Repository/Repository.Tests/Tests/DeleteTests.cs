namespace Repository.Tests;

[TestCaseOrderer("Repository.Tests.CustomTestMethodOrderer", "Repository.Tests")]
public class DeleteTests
{
    [Fact]
    public async Task DeleteNoSave_Returns_FewElements_When_NotSaved()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var request = await context.InitTestEntitiesAsync();
        //Act
        testRepo.DeleteNoSave(request[0]);

        //Assert
        (await context.TestEntities.CountAsync()).Should().Be(3);
    }

    [Fact]
    public async Task DeleteAsync_Returns_0Elements_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var request = await context.InitTestEntityAsync();
        //Act
        await testRepo.DeleteAsync(request);

        //Assert
        (await context.TestEntities.CountAsync()).Should().Be(0);
    }

    [Fact]
    public async Task DeleteAsyncById_Ok_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var request = await context.InitTestEntityAsync();
        //Act
        await testRepo.DeleteAsync(request.Id);

        //Assert
        (await context.TestEntities.CountAsync()).Should().Be(0);
    }

    [Fact]
    public async Task DeleteAsyncById_ThrowsException_When_NotFound()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var request = await context.InitTestEntityAsync();
        //Act
        Func<Task> act = async () => await testRepo.DeleteAsync(25);

        //Assert
        await act.Should().ThrowAsync<NullReferenceException>();
    }

    [Fact]
    public async Task DeleteRangeAsync_0Elements_When_Okay()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var request = await context.InitTestEntitiesAsync();
        //Act
        await testRepo.DeleteRangeAsync(request);

        //Assert
        (await context.TestEntities.CountAsync()).Should().Be(0);
    }

    [Fact]
    public async Task DeleteRangeAsync_Returns_FewElements_When_NotSaved()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var request = await context.InitTestEntitiesAsync();
        //Act
        testRepo.DeleteNoSaveRange(request);

        //Assert
        (await context.TestEntities.CountAsync()).Should().Be(3);
    }
}