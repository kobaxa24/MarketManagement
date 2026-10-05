using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Market.Tests;

[SetUpFixture]
public class GlobalTestSetup 
{
    [OneTimeSetUp]
    public void Setup()
    {
        ClearDatabase();
        SeedDatabase();
    }
    public static void ClearDatabase()
    {
        using var connection = new SqlConnection(TestConfiguration.ConnectionString);
        connection.Open();

        connection.Execute(
            "sp_ClearDatabase",
            commandType: CommandType.StoredProcedure);
    }

    public static void SeedDatabase()
    {
        using var connection = new SqlConnection(TestConfiguration.ConnectionString);
        connection.Open();

        connection.Execute(
            "sp_SeedDatabase",
            commandType: CommandType.StoredProcedure);
    }
}