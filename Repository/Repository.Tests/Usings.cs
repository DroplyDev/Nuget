global using Xunit;
global using FluentAssertions;
global using Repository.Tests.TestTypes.Database;
global using Repository.Tests.TestTypes.Entities;
global using Repository.Tests.TestTypes.Repos;
[assembly: TestCollectionOrderer("Repository.Tests.RepositoryTestsClassOrderer", "Repository.Tests")]