using Microsoft.Extensions.Configuration;

namespace Market.Tests;

public static class TestConfiguration
{
    public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .SetBasePath(AppContext.BaseDirectory)
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

    public static string ConnectionString =>
        Configuration.GetConnectionString("MarketTestDatabase")
        ?? throw new InvalidOperationException(
            "Connection string 'MarketTestDatabase' is missing in appsettings.json.");
}