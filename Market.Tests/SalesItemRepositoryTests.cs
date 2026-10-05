using Market.DTO;
using Market.Repositories;
using Microsoft.Data.SqlClient;
using NUnit.Framework;

namespace Market.Tests
{
    [TestFixture]
    public class SalesItemRepositoryTests : BaseRepositoryTests
    {
        [Test]
        public void InsertTest_ShouldInsertCorrectData()
        {
            var salesItemRepository = UnitOfWork.SaleItemRepository;

            var salesItem = new SalesItem
            {
                SaleID = 3,
                ProductID = 3,
                Quantity = 2,
                UnitPrice = 25.50m,
                Discount = 5
            };

            var id = salesItemRepository.Insert(salesItem);

            var insertedSalesItem = salesItemRepository.GetById(id);

            Assert.That(id, Is.GreaterThan(0),
                "The inserted sales item ID should be greater than 0.");
            Assert.That(insertedSalesItem, Is.Not.Null,
                "The inserted sales item should not be null.");
            Assert.That(insertedSalesItem.SaleID,
                Is.EqualTo(salesItem.SaleID),
                "The sale ID should match the inserted value.");
            Assert.That(insertedSalesItem.ProductID,
                Is.EqualTo(salesItem.ProductID),
                "The product ID should match the inserted value.");
            Assert.That(insertedSalesItem.Quantity,
                Is.EqualTo(salesItem.Quantity),
                "The quantity should match the inserted value.");
            Assert.That(insertedSalesItem.UnitPrice,
                Is.EqualTo(salesItem.UnitPrice),
                "The unit price should match the inserted value.");
            Assert.That(insertedSalesItem.Discount,
                Is.EqualTo(salesItem.Discount),
                "The discount should match the inserted value.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataSaleID()
        {
            var salesItemRepository = UnitOfWork.SaleItemRepository;

            var salesItem = new SalesItem
            {
                SaleID = -1,
                ProductID = 3,
                Quantity = 2,
                UnitPrice = 25.50m
            };

            Action act = () => salesItemRepository.Insert(salesItem);

            Assert.Throws<SqlException>(act,
                "Inserting a sales item with an invalid sale ID should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataProductID()
        {
            var salesItemRepository = UnitOfWork.SaleItemRepository;

            var salesItem = new SalesItem
            {
                SaleID = 3,
                ProductID = -1,
                Quantity = 2,
                UnitPrice = 25.50m
            };

            Action act = () => salesItemRepository.Insert(salesItem);

            Assert.Throws<SqlException>(act,
                "Inserting a sales item with an invalid product ID should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertNegativeQuantity()
        {
            var salesItemRepository = UnitOfWork.SaleItemRepository;

            var salesItem = new SalesItem
            {
                SaleID = 3,
                ProductID = 3,
                Quantity = -2,
                UnitPrice = 25.50m
            };

            Action act = () => salesItemRepository.Insert(salesItem);

            Assert.Throws<SqlException>(act,
                "Inserting a sales item with a negative quantity should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertZeroQuantity()
        {
            var salesItemRepository = UnitOfWork.SaleItemRepository;

            var salesItem = new SalesItem
            {
                SaleID = 3,
                ProductID = 3,
                Quantity = 0,
                UnitPrice = 25.50m
            };

            Action act = () => salesItemRepository.Insert(salesItem);

            Assert.Throws<SqlException>(act,
                "Inserting a sales item with zero quantity should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertNegativeUnitPrice()
        {
            var salesItemRepository = UnitOfWork.SaleItemRepository;

            var salesItem = new SalesItem
            {
                SaleID = 3,
                ProductID = 3,
                Quantity = 2,
                UnitPrice = -25.50m
            };

            Action act = () => salesItemRepository.Insert(salesItem);

            Assert.Throws<SqlException>(act,
                "Inserting a sales item with a negative unit price should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertNegativeDiscount()
        {
            var salesItemRepository = UnitOfWork.SaleItemRepository;

            var salesItem = new SalesItem
            {
                SaleID = 3,
                ProductID = 3,
                Quantity = 2,
                UnitPrice = 25.50m,
                Discount = -5
            };

            Action act = () => salesItemRepository.Insert(salesItem);

            Assert.Throws<SqlException>(act,
                "Inserting a sales item with a negative discount should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldUseDefaultDiscount()
        {
            var salesItemRepository = UnitOfWork.SaleItemRepository;

            var salesItem = new SalesItem
            {
                SaleID = 4,
                ProductID = 4,
                Quantity = 2,
                UnitPrice = 25.50m
            };

            var id = salesItemRepository.Insert(salesItem);

            var insertedSalesItem = salesItemRepository.GetById(id);

            Assert.That(insertedSalesItem, Is.Not.Null,
                "The inserted sales item should not be null.");
            Assert.That(insertedSalesItem.Discount,
                Is.EqualTo(0),
                "The discount should default to 0.");
        }

        [Test]
        public void GetAllTest_ShouldReturnList()
        {
            var salesItemRepository = UnitOfWork.SaleItemRepository;

            var salesItems = salesItemRepository.GetAll();

            Assert.That(salesItems, Is.Not.Null,
                "GetAll should not return null.");
        }

        [Test]
        public void GetByIdTest_ShouldThrowOnInvalidId()
        {
            var salesItemRepository = UnitOfWork.SaleItemRepository;

            Action act = () => salesItemRepository.GetById(-1);

            Assert.Throws<SqlException>(act,
                "Getting sales item with invalid ID should throw.");
        }
    }
}