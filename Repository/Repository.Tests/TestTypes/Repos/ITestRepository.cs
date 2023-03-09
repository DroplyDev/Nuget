using Repository.Interfaces;
using Repository.Tests.TestTypes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Tests.TestTypes.Repos;

public interface ITestRepository : IBaseRepo<TestEntity>
{
}