using Microsoft.EntityFrameworkCore;

namespace Repository.Tests;

public class UpdateTests
{
    [Fact]
    public async Task UpdateAsync_Returns_Entity_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var entity = await context.InitTestEntityAsync();
        //Act
        entity.Name = "Brian";
        await testRepo.UpdateAsync(entity);

        //Assert
        (await context.TestEntities.FirstAsync(e => e.Id == 1)).Should().NotBeNull();
        (await context.TestEntities.FirstAsync(e => e.Id == 1)).Should().BeEquivalentTo(entity);
    }

    [Fact]
    public async Task UpdateNoSave_Returns_Entity_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var entity = await context.InitTestEntityAsync();
        //Act
        entity.Name = "Brian";
        testRepo.UpdateNoSave(entity);

        //Assert
        (await testRepo.GetByIdAsync(1)).Should().NotBeNull();
        (await testRepo.GetByIdAsync(1)).Should().BeEquivalentTo(entity);
    }

    [Fact]
    public async Task UpdateRangeAsync_Returns_Entity_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var request = await context.InitTestEntitiesAsync();
        //Act
        request[0].Name = "Brian";
        request[1].Name = "Brian";
        await testRepo.UpdateRangeAsync(request);

        //Assert
        context.TestEntities.Should().NotBeNull();
        context.TestEntities.Should().BeEquivalentTo(request);
    }

    [Fact]
    public async Task UpdateNoSaveRange_Returns_Entity_When_Ok()
    {
        //Arrange
        await using var context = new TestDbContext();
        var testRepo = new TestRepository(context);

        var request = await context.InitTestEntitiesAsync();
        //Act
        request[0].Name = "Brian";
        request[1].Name = "Brian";
        testRepo.UpdateRangeNoSave(request);

        //Assert
        context.TestEntities.Should().NotBeNull();
        context.TestEntities.Should().BeEquivalentTo(request);
    }
}