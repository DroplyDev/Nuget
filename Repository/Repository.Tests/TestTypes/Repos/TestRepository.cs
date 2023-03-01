using Microsoft.EntityFrameworkCore;
using Repository.Implementation;
using Repository.Tests.TestTypes.Entities;

namespace Repository.Tests.TestTypes.Repos
{
    public class TestRepository : BaseRepo<DbContext, TestEntity>, ITestRepository
    {

        public TestRepository(DbContext context) : base(context)
        {
        }
    }
}
