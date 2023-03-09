
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Repository.Tests;

public class CustomTestMethodOrderer : ITestCaseOrderer
{
    public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
    {
        var orderedTestCases = testCases
              .OrderBy(testCase => testCase.TestMethod.Method.Name)
              .ToList();

        return orderedTestCases;
    }
}