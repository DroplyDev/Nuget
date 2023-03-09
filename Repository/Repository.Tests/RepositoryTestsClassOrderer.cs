

using Xunit.Abstractions;

namespace Repository.Tests;

public class RepositoryTestsClassOrderer : ITestCollectionOrderer
{
    private readonly List<string> _classOrder = new List<string>
    {
        "Repository.Tests.GetById",
        "Repository.Tests.GetAllTests",
        "Repository.Tests.SaveChangesTests",
        "Repository.Tests.IsEmpty",
        "Repository.Tests.CreateTests",
        "Repository.Tests.ExistsTests",

    };

    public IEnumerable<ITestCollection> OrderTestCollections(IEnumerable<ITestCollection> testCollections)
    {
        var sortedCollections = new List<ITestCollection>();
        foreach (var className in _classOrder)
        {
            var collection = testCollections.SingleOrDefault(x => x.DisplayName.Contains(className));
            if (collection != null)
            {
                sortedCollections.Add(collection);
            }
        }
        return sortedCollections;
    }
}