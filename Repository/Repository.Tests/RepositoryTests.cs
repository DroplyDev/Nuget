//using Repository.Tests.TestTypes.Database;
//using Repository.Tests.TestTypes.Entities;
//using Repository.Tests.TestTypes.Repos;
//using System.Linq.Expressions;

//namespace Repository.Tests
//{
//    public class RepositoryTests
//    {

//        public RepositoryTests()
//        {

//        }

//        #region GetAll

//        [Fact]
//        public async Task GetAll()
//        {
//            using (var context = new TestDbContext())
//            {
//                // Creating repository
//                TestRepository testRepo = new TestRepository(context);

//                // Add some entities to database
//                IEnumerable<TestEntity> list = new List<TestEntity>()
//                {
//                    new TestEntity { Id = 1, Name = "John" },
//                    new TestEntity { Id = 2, Name = "Jane" },
//                    new TestEntity { Id = 3, Name = "Bob" }
//                };
//                // Add some entities to database
//                await testRepo.CreateRangeAsync(list);

//                // retrieve all users from the repository
//                var allUsers = testRepo.GetAll().ToList();

//                // assert that the list of users is not null and has the correct number of items
//                Assert.NotNull(allUsers);
//                Assert.Equal(3, allUsers.Count);
//                Assert.IsType<TestEntity>(allUsers.First());
//                Assert.IsType<List<TestEntity>>(allUsers);
//            }
//        }

//        #endregion


//        #region Create

//        [Fact]
//        public async Task CreateAsync()
//        {
//            using (var context = new TestDbContext())
//            {
//                // Creating repository
//                TestRepository testRepo = new TestRepository(context);

//                // Add some entities to database
//                await testRepo.CreateAsync(new TestEntity { Id = 1, Name = "John" });
//                await testRepo.CreateAsync(new TestEntity { Id = 2, Name = "Jane" });
//                await testRepo.CreateAsync(new TestEntity { Id = 3, Name = "Bob" });

//                // retrieve all users from the repository
//                var allUsers = testRepo.GetAll().ToList();

//                // assert that the list of users is not null and has the correct number of items
//                Assert.NotNull(allUsers);
//                Assert.Equal(3, allUsers.Count);
//            }
//        }


//        [Fact]
//        public async Task CreateRangeAsync()
//        {
//            using (var context = new TestDbContext())
//            {
//                // Creating repository
//                TestRepository testRepo = new TestRepository(context);

//                IEnumerable<TestEntity> list = new List<TestEntity>()
//                {
//                    new TestEntity { Id = 1, Name = "John" },
//                    new TestEntity { Id = 2, Name = "Jane" },
//                    new TestEntity { Id = 3, Name = "Bob" }
//                };
//                // Add some entities to database
//                await testRepo.CreateRangeAsync(list);

//                // retrieve all users from the repository
//                var allUsers = testRepo.GetAll().ToList();

//                // assert that the list of users is not null and has the correct number of items
//                Assert.NotNull(allUsers);
//                Assert.Equal(3, allUsers.Count);
//            }
//        }

//        [Fact]
//        public async Task CreateNoSaveAsync()
//        {
//            using (var context = new TestDbContext())
//            {
//                // Creating repository
//                TestRepository testRepo = new TestRepository(context);

//                // Add some entities to database
//                await testRepo.CreateNoSaveAsync(new TestEntity { Id = 1, Name = "John" });
//                await testRepo.CreateNoSaveAsync(new TestEntity { Id = 2, Name = "Jane" });
//                await testRepo.CreateNoSaveAsync(new TestEntity { Id = 3, Name = "Bob" });

//                // retrieve all users from the repository
//                var allUsers = testRepo.GetAll().ToList();

//                // assert that the list of users is not null and has the correct number of items
//                Assert.NotNull(allUsers);
//                Assert.Empty(allUsers);
//            }
//        }

//        #endregion


//        //#region Update

//        //Task UpdateAsync(TEntity entity);
//        //void UpdateNoSave(TEntity entity);
//        //Task UpdateRangeAsync(IEnumerable<TEntity> entities);
//        //void UpdateRangeNoSave(IEnumerable<TEntity> entities);
//        //void Attach(TEntity entity);
//        //void AttachRange(IEnumerable<TEntity> entities);

//        //#endregion

//        //#region Delete

//        //Task DeleteAsync(TEntity entity);
//        //Task DeleteAsync(object id);
//        //void DeleteNoSave(TEntity entity);
//        //Task DeleteRangeAsync(IEnumerable<TEntity> entities);
//        //void DeleteNoSaveRange(IEnumerable<TEntity> entities);

//        //#endregion


//        //#region Exists

//        //Task<bool> ExistsAsync(object id, CancellationToken cancellationToken = default);

//        //Task<bool> ExistsAsync(TEntity entity, CancellationToken cancellationToken = default);

//        //Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);

//        //#endregion

//        //#region IsEmpty

//        //Task<bool> IsEmptyAsync(CancellationToken cancellationToken = default);

//        //Task<bool> IsEmptyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);

//        //#endregion

//        //#region First

//        //TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> expression,
//        //                        Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null);

//        //Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression,
//        //                                   CancellationToken cancellationToken = default,
//        //                                   Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes =
//        //                                       null);

//        //TEntity First(Expression<Func<TEntity, bool>> expression,
//        //              Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null);

//        //Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default,
//        //                         Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null);

//        //#endregion

//        //#region GetAll

//        //IQueryable<TEntity> GetAll();

//        //#endregion

//        //#region Where

//        //IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);

//        //#endregion
//    }
//}
