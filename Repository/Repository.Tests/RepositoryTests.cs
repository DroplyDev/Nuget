using Repository.Tests.TestTypes.Database;
using Repository.Tests.TestTypes.Entities;
using Repository.Tests.TestTypes.Repos;
using System.Linq.Expressions;

namespace Repository.Tests
{
    public class RepositoryTests
    {
        public RepositoryTests()
        {        
        }

        #region Create

        [Fact]
        public async Task CreateAsync()
        {
            using (var context = new TestDbContext())
            {
                // Creating repository
                TestRepository testRepo = new TestRepository(context);

                // Add some entities to database
                await testRepo.CreateAsync(new TestEntity { Id = 1, Name = "John" });
                await testRepo.CreateAsync(new TestEntity { Id = 2, Name = "Jane" });
                await testRepo.CreateAsync(new TestEntity { Id = 3, Name = "Bob" });

                // retrieve all users from the repository
                var allUsers = testRepo.GetAll().ToList();

                // assert that the list of users is not null and has the correct number of items
                Assert.NotNull(allUsers);
                Assert.Equal(3, allUsers.Count);
            }
        }

        #endregion
    }
}
