using Dapper;
using Market.Repositories;
using Market.Services.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Market.Tests
{
    public abstract class BaseRepositoryTests
    {
        protected const int UpdateTestId = 1;
        protected const int DeleteTestId = 2;
        protected static string ConnectionString => TestConfiguration.ConnectionString;
        protected SqlConnection Connection;
        protected IUnitOfWork UnitOfWork;

        [SetUp]
        public void BaseSetup()
        {
            Connection = new SqlConnection(ConnectionString);
            UnitOfWork = new UnitOfWork(Connection);
        }

        [TearDown]
        public void BaseTearDown()
        {
            UnitOfWork.Dispose();
            Connection.Dispose();
        }
    }
}
