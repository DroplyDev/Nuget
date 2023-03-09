using Repository.Tests.TestTypes.Database;
using Repository.Tests.TestTypes.Entities;
using Repository.Tests.TestTypes.Repos;

namespace Repository.Tests
{
    [TestCaseOrderer("Repository.Tests.CustomTestMethodOrderer", "Repository.Tests")]
    public class GetByIdTests
    {
        public GetByIdTests()
        {

        }

        [Fact]
        public async Task IsNotNull()
        {
            using (var context = new TestDbContext())
            {
                // Creating repository
                TestRepository testRepo = new TestRepository(context);

                // Add some entities to database
                await context.AddAsync(new TestEntity { Id = 1, Name = "John" });

                // retrieve user from the repository
                var userById = testRepo.GetById(1);

                // assert that the user is not null
                Assert.NotNull(userById);
            }
        }

        [Fact]
        public async Task IsCorrectType()
        {
            using (var context = new TestDbContext())
            {
                // Creating repository
                TestRepository testRepo = new TestRepository(context);

                // Add some entities to database
                await context.AddAsync(new TestEntity { Id = 1, Name = "Lucy" });

                // retrieve user from the repository
                var userById = testRepo.GetById(1);

                // assert that the user is not null
                Assert.IsType<TestEntity>(userById);
            }
        }

        [Fact]
        public async Task IsCorrectValue()
        {
            using (var context = new TestDbContext())
            {
                // Creating repository
                TestRepository testRepo = new TestRepository(context);

                // Add some entities to database
                await context.AddAsync(new TestEntity { Id = 1, Name = "Alex" });

                // retrieve user from the repository
                var userById = testRepo.GetById(1);

                // assert that the user is not null
                Assert.Equal("Alex", userById.Name);
            }
        }
    }
}
