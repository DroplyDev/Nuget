namespace Repository.Tests;

public static class InitHelpers
{
    public static async Task<TestEntity> InitTestEntityAsync(this DbContext context, int id = 1, string name = "John")
    {
        var entity = new TestEntity
        {
            Id = id,
            Name = name
        };
        await context.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public static async Task<List<TestEntity>> InitTestEntitiesAsync(this DbContext context)
    {
        var entities = new List<TestEntity>
        {
            new() {Id = 1, Name = "John"},
            new() {Id = 2, Name = "Bob"},
            new() {Id = 3, Name = "Lucy"}
        };
        await context.AddRangeAsync(entities);
        await context.SaveChangesAsync();
        return entities;
    }
}