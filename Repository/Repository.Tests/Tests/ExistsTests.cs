using Repository.Tests.TestTypes.Database;
using Repository.Tests.TestTypes.Entities;
using Repository.Tests.TestTypes.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Tests
{
    [TestCaseOrderer("Repository.Tests.CustomTestMethodOrderer", "Repository.Tests")]
    public class ExistsTests
    {
        public ExistsTests()
        {

        }

        [Fact]
        public async Task ConditionById()
        {
            using (var context = new TestDbContext())
            {
                // Creating repository
                TestRepository testRepo = new TestRepository(context);

                // Add some entities to database
                await testRepo.CreateAsync(new TestEntity { Id = 1, Name = "John" });

                // retrieve user from the repository
                var isExists = await testRepo.ExistsAsync(1);

                // assert that the user is not null
                Assert.True(isExists);
            }
        }

        [Fact]
        public async Task ConditionByName()
        {
            using (var context = new TestDbContext())
            {
                // Creating repository
                TestRepository testRepo = new TestRepository(context);

                // Add some entities to database
                await testRepo.CreateAsync(new TestEntity { Id = 1, Name = "John" });

                // retrieve user from the repository
                var isExists = await testRepo.ExistsAsync(e => e.Name == "John");

                // assert that the user is not null
                Assert.True(isExists);
            }
        }

        [Fact]
        public async Task ConditionByEntity()
        {
            using (var context = new TestDbContext())
            {
                // Creating repository
                TestRepository testRepo = new TestRepository(context);

                // Add some entities to database
                var entity = new TestEntity { Id = 1, Name = "John" };
                await testRepo.CreateAsync(entity);

                // retrieve user from the repository
                var isExists = await testRepo.ExistsAsync(entity);

                // assert that the user is not null
                Assert.True(isExists);
            }
        }

        [Fact]
        public async Task WrongConditionById()
        {
            using (var context = new TestDbContext())
            {
                // Creating repository
                TestRepository testRepo = new TestRepository(context);

                // Add some entities to database
                await testRepo.CreateAsync(new TestEntity { Id = 1, Name = "John" });

                // retrieve user from the repository
                var isExists = await testRepo.ExistsAsync(2);

                // assert that the user is not null
                Assert.False(isExists);
            }
        }

        [Fact]
        public async Task WrongConditionByName()
        {
            using (var context = new TestDbContext())
            {
                // Creating repository
                TestRepository testRepo = new TestRepository(context);

                // Add some entities to database
                await testRepo.CreateAsync(new TestEntity { Id = 1, Name = "John" });

                // retrieve user from the repository
                var isExists = await testRepo.ExistsAsync(e => e.Name == "Lucy");

                // assert that the user is not null
                Assert.False(isExists);
            }
        }

        [Fact]
        public async Task WrongConditionByEntity()
        {
            using (var context = new TestDbContext())
            {
                // Creating repository
                TestRepository testRepo = new TestRepository(context);

                // Add some entities to database
                await testRepo.CreateAsync(new TestEntity { Id = 1, Name = "John" });

                // retrieve user from the repository
                var isExists = await testRepo.ExistsAsync(new TestEntity { Id = 2, Name = "Bob"});

                // assert that the user is not null
                Assert.False(isExists);
            }
        }
    }
}
