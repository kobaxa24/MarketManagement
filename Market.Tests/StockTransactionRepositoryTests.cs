using Market.DTO;
using Market.Repositories;
using Microsoft.Data.SqlClient;
using NUnit.Framework;

namespace Market.Tests
{
    [TestFixture]
    public class StockTransactionRepositoryTests : BaseRepositoryTests
    {
        [Test]
        public void InsertTest_ShouldInsertCorrectData()
        {
            var stockTransactionRepository = UnitOfWork.StockTransactionRepository;

            var stockTransaction = new StockTransaction
            {
                ProductID = 3,
                SupplierID = 3,
                EmployeeID = 3,
                Quantity = 10
            };

            Action act = () => stockTransactionRepository.Insert(stockTransaction);

            Assert.DoesNotThrow(act,
                "A valid stock transaction should be inserted without throwing an exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataProductID()
        {
            var stockTransactionRepository = UnitOfWork.StockTransactionRepository;

            var stockTransaction = new StockTransaction
            {
                ProductID = -1,
                SupplierID = 3,
                EmployeeID = 3,
                Quantity = 10
            };

            Action act = () => stockTransactionRepository.Insert(stockTransaction);

            Assert.Throws<SqlException>(act,
                "Inserting a stock transaction with an invalid product ID should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataSupplierID()
        {
            var stockTransactionRepository = UnitOfWork.StockTransactionRepository;

            var stockTransaction = new StockTransaction
            {
                ProductID = 3,
                SupplierID = -1,
                EmployeeID = 3,
                Quantity = 10
            };

            Action act = () => stockTransactionRepository.Insert(stockTransaction);

            Assert.Throws<SqlException>(act,
                "Inserting a stock transaction with an invalid supplier ID should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataEmployeeID()
        {
            var stockTransactionRepository = UnitOfWork.StockTransactionRepository;

            var stockTransaction = new StockTransaction
            {
                ProductID = 3,
                SupplierID = 3,
                EmployeeID = -1,
                Quantity = 10
            };

            Action act = () => stockTransactionRepository.Insert(stockTransaction);

            Assert.Throws<SqlException>(act,
                "Inserting a stock transaction with an invalid employee ID should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertNegativeQuantity()
        {
            var stockTransactionRepository = UnitOfWork.StockTransactionRepository;

            var stockTransaction = new StockTransaction
            {
                ProductID = 3,
                SupplierID = 3,
                EmployeeID = 3,
                Quantity = -10
            };

            Action act = () => stockTransactionRepository.Insert(stockTransaction);

            Assert.Throws<SqlException>(act,
                "Inserting a stock transaction with a negative quantity should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertZeroQuantity()
        {
            var stockTransactionRepository = UnitOfWork.StockTransactionRepository;

            var stockTransaction = new StockTransaction
            {
                ProductID = 3,
                SupplierID = 3,
                EmployeeID = 3,
                Quantity = 0
            };

            Action act = () => stockTransactionRepository.Insert(stockTransaction);

            Assert.Throws<SqlException>(act,
                "Inserting a stock transaction with zero quantity should throw a SQL exception.");
        }

        [Test]
        public void GetAllTest_ShouldReturnList()
        {
            var stockTransactionRepository = UnitOfWork.StockTransactionRepository;

            var stockTransactions = stockTransactionRepository.GetAll();

            Assert.That(stockTransactions, Is.Not.Null,
                "GetAll should not return null.");
        }

        [Test]
        public void GetByIdTest_ShouldThrowOnInvalidId()
        {
            var stockTransactionRepository = UnitOfWork.StockTransactionRepository;

            Action act = () => stockTransactionRepository.GetById(-1);

            Assert.Throws<SqlException>(act,
                "Getting stock transaction with invalid ID should throw.");
        }
    }
}