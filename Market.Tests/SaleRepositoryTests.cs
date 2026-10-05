using Market.DTO;
using Market.Repositories;
using Microsoft.Data.SqlClient;
using NUnit.Framework;

namespace Market.Tests
{
    [TestFixture]
    public class SaleRepositoryTests : BaseRepositoryTests
    {
        [Test]
        public void InsertTest_ShouldInsertCorrectData()
        {
            var saleRepository = UnitOfWork.SaleRepository;

            var sale = new Sale
            {
                CustomerID = 3,
                EmployeeID = 3
            };

            var id = saleRepository.Insert(sale);

            var insertedSale = saleRepository.GetById(id);

            Assert.That(id, Is.GreaterThan(0),
                "The inserted sale ID should be greater than 0.");
            Assert.That(insertedSale, Is.Not.Null,
                "The inserted sale should not be null.");
            Assert.That(insertedSale.CustomerID,
                Is.EqualTo(sale.CustomerID),
                "The customer ID should match the inserted value.");
            Assert.That(insertedSale.EmployeeID,
                Is.EqualTo(sale.EmployeeID),
                "The employee ID should match the inserted value.");
        }

        [Test]
        public void InsertTest_ShouldAllowNullCustomerID()
        {
            var saleRepository = UnitOfWork.SaleRepository;

            var sale = new Sale
            {
                CustomerID = null,
                EmployeeID = 3
            };

            Action act = () => saleRepository.Insert(sale);

            Assert.DoesNotThrow(act,
                "A sale should allow a null customer ID.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataEmployeeID()
        {
            var saleRepository = UnitOfWork.SaleRepository;

            var sale = new Sale
            {
                CustomerID = 3,
                EmployeeID = -1
            };

            Action act = () => saleRepository.Insert(sale);

            Assert.Throws<SqlException>(act,
                "Inserting a sale with an invalid employee ID should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataCustomerID()
        {
            var saleRepository = UnitOfWork.SaleRepository;

            var sale = new Sale
            {
                CustomerID = -1,
                EmployeeID = 3
            };

            Action act = () => saleRepository.Insert(sale);

            Assert.Throws<SqlException>(act,
                "Inserting a sale with an invalid customer ID should throw a SQL exception.");
        }

        [Test]
        public void GetAllTest_ShouldReturnList()
        {
            var saleRepository = UnitOfWork.SaleRepository;

            var sales = saleRepository.GetAll();

            Assert.That(sales, Is.Not.Null,
                "GetAll should not return null.");
        }

        [Test]
        public void GetByIdTest_ShouldThrowOnInvalidId()
        {
            var saleRepository = UnitOfWork.SaleRepository;

            Action act = () => saleRepository.GetById(-1);

            Assert.Throws<SqlException>(act,
                "Getting sale with invalid ID should throw.");
        }
  
    }
}