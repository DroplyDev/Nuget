using Repository.Tests.TestTypes.Database;
using Repository.Tests.TestTypes.Entities;
using Repository.Tests.TestTypes.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Tests;

[TestCaseOrderer("Repository.Tests.CustomTestMethodOrderer", "Repository.Tests")]
public class CreateTests
{
    [Fact]
    public async Task IsCorrectNoSave()
    {
        await using var context = new TestDbContext();
        // Creating repository
        TestRepository testRepo = new TestRepository(context);

        // Add some entities to database
        await testRepo.CreateNoSaveAsync(new TestEntity { Id = 1, Name = "John" });

        // assert that the user is not null
        Assert.Equal(0, context.TestEntities.Count());
    }

    [Fact]
    public async Task IsCorrectCount()
    {
        await using var context = new TestDbContext();
        // Creating repository
        TestRepository testRepo = new TestRepository(context);

        // Add some entities to database
        await testRepo.CreateAsync(new TestEntity { Id = 1, Name = "John" });

        // assert that the user is not null
        Assert.Equal(1, context.TestEntities.Count());
    }

    [Fact]
    public async Task IsCorrectType()
    {
        await using var context = new TestDbContext();
        // Creating repository
        TestRepository testRepo = new TestRepository(context);

        // Add some entities to database
        await testRepo.CreateAsync(new TestEntity { Id = 1, Name = "John" });

        var userById = testRepo.GetById(1);

        // assert that the user is not null
        Assert.IsType<TestEntity>(userById);
    }

    [Fact]
    public async Task IsCorrectValue()
    {
        await using var context = new TestDbContext();
        // Creating repository
        TestRepository testRepo = new TestRepository(context);

        // Add some entities to database
        await testRepo.CreateAsync(new TestEntity { Id = 1, Name = "John" });

        var userById = testRepo.GetById(1);

        // assert that the user is not null
        Assert.Equal("John", userById.Name);
    }

    [Fact]
    public async Task IsCorrectRangeCount()
    {
        await using var context = new TestDbContext();
        // Creating repository
        TestRepository testRepo = new TestRepository(context);

        // Add some entities to database
        var list = new List<TestEntity> {
            new TestEntity { Id = 1, Name = "John"},
            new TestEntity { Id = 2, Name = "Bob"},
            new TestEntity { Id = 3, Name = "Lucy"}
        };
        await testRepo.CreateRangeAsync(list);

        var usersAllCount = testRepo.GetAll().Count();

        // assert that the user is not null
        Assert.Equal(3, usersAllCount);
    }

    [Fact]
    public async Task IsCorrectRangeValues()
    {
        await using var context = new TestDbContext();
        // Creating repository
        TestRepository testRepo = new TestRepository(context);

        // Add some entities to database
        var list = new List<TestEntity> {
            new TestEntity { Id = 1, Name = "John"},
            new TestEntity { Id = 2, Name = "Bob"},
            new TestEntity { Id = 3, Name = "Lucy"}
        };
        await testRepo.CreateRangeAsync(list);

        var usersAllCount = testRepo.GetAll().ToList();

        // assert that the user is not null
        Assert.True(
            usersAllCount[0].Name == "John"
            && usersAllCount[1].Name == "Bob"
            && usersAllCount[2].Name == "Lucy"
        );
    }
}