namespace Repository.Tests;

public class AttachTests
{
    [Fact]
    public async Task AttachAsync_Returns_Entity_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var request = new TestEntity { Id = 1, Name = "John" };
        //Act
        await testRepo.CreateAsync(request);
        await testRepo.AttachAsync(request);
        //Assert
        context.TestEntities.Should().HaveCount(1);
        context.TestEntities.Should().BeEquivalentTo(new List<TestEntity>() { request });
    }

    [Fact]
    public async Task AttachRangeAsync_Returns_AttachedEntities_When_Ok()
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
        await testRepo.CreateRangeAsync(request);
        await testRepo.AttachRangeAsync(request);
        //Assert
        context.TestEntities.Should().HaveCount(3);
        context.TestEntities.Should().BeEquivalentTo(request);
    }
}