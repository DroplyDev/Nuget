//using Repository.Tests.TestTypes.Database;
//using Repository.Tests.TestTypes.Entities;
//using Repository.Tests.TestTypes.Repos;

//namespace Repository.Tests
//{
//    public class SaveChangesTests
//    {
//        public SaveChangesTests()
//        {

//        }
//        [Fact]
//        public async Task SaveChangesAsync()
//        {
//            using (var context = new TestDbContext())
//            {
//                Creating repository
//                TestRepository testRepo = new TestRepository(context);

//                Add some entities to database
//               await testRepo.CreateNoSaveAsync(new TestEntity { Id = 1, Name = "John" });
//                await testRepo.CreateNoSaveAsync(new TestEntity { Id = 2, Name = "Jane" });
//                await testRepo.CreateNoSaveAsync(new TestEntity { Id = 3, Name = "Bob" });
//                await testRepo.SaveChangesAsync();
//                retrieve all users from the repository
//                var allUsers = testRepo.GetAll().ToList();

//                assert that the list of users is not null and has the correct number of items
//                Assert.NotNull(allUsers);
//                Assert.IsType<TestEntity>(allUsers.First());
//                Assert.Equal(3, allUsers.Count);
//            }
//        }
//    }
//}
