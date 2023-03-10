using Repository.Implementation;

namespace Repository.Tests.TestTypes.Repos;

public class TestRepository : BaseRepo<DbContext, TestEntity>, ITestRepository
{
    public TestRepository(DbContext context) : base(context)
    {
    }
}