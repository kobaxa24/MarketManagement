namespace Market.Tests;

[SetUpFixture]
public class GlobalTestSetup
{
    [OneTimeSetUp]
    public void Setup()
    {
        BaseRepositoryTests.ClearDatabase();
        BaseRepositoryTests.SeedDatabase();
    }
}