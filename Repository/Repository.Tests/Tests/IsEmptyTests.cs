using Repository.Tests.TestTypes.Database;
using Repository.Tests.TestTypes.Entities;
using Repository.Tests.TestTypes.Repos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Tests
{
    public class IsEmptyTests
    {

        [Fact]
        public async Task IsEmpty()
        {
            using (var context = new TestDbContext())
            {
                // Creating repository
                TestRepository testRepo = new TestRepository(context);

                // retrieve user from the repository
                var isEmpty = await testRepo.IsEmptyAsync();

                // assert that the user is not null
                Assert.True(isEmpty);
            }
        }

        [Fact]
        public async Task IsNotEmpty()
        {
            using (var context = new TestDbContext())
            {
                // Creating repository
                TestRepository testRepo = new TestRepository(context);

                // Add some entities to database
                await context.AddAsync(new TestEntity { Id = 1, Name = "John" });
                await context.AddAsync(new TestEntity { Id = 2, Name = "Jack" });
                await testRepo.SaveChangesAsync();

                // retrieve user from the repository
                var isEmpty = await testRepo.IsEmptyAsync();

                // assert that the user is not null
                Assert.False(isEmpty);
            }
        }
    }
}
