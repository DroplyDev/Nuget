namespace Repository.Tests;

[TestCaseOrderer("Repository.Tests.CustomTestMethodOrderer", "Repository.Tests")]
public class SaveChangesTests
{
    [Fact]
    public async Task SaveChangesAsync_Returns_SavedEntity_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);
        var entities = new List<TestEntity>
        {
            new() {Id = 1, Name = "Lucy"},
            new() {Id = 2, Name = "John"}
        };
        await context.AddRangeAsync(entities);
        //Act
        await testRepo.SaveChangesAsync();
        //Assert
        context.TestEntities.Should().BeEquivalentTo(entities);
    }
}