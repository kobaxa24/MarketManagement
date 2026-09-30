
using Market.DTO;
using Market.Repositories;
using Microsoft.Data.SqlClient;
using NUnit.Framework;

namespace Market.Tests
{
    [TestFixture]
    public class SupplierRepositoryTests : BaseRepositoryTests
    {
        
        [Test]
        public void InsertTest_ShouldInsertCorrectData()
        {
            var supplierRepository = UnitOfWork.SupplierRepository;

            var supplier = new Supplier
            {
                CountryID = 3,
                SupplierName = $"Supplier{Random.Shared.Next(1000, 10000)}"
            };

            var id = supplierRepository.Insert(supplier);
            var insertedSupplier = supplierRepository.GetById(id);

            Assert.That(id, Is.GreaterThan(0), "The inserted supplier ID should be greater than 0.");
            Assert.That(insertedSupplier, Is.Not.Null, "The inserted supplier should not be null.");
            Assert.That(insertedSupplier.CountryID, Is.EqualTo(supplier.CountryID), "The country ID should match the inserted value.");
            Assert.That(insertedSupplier.SupplierName, Is.EqualTo(supplier.SupplierName), "The supplier name should match the inserted value.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataName()
        {
            var supplierRepository = UnitOfWork.SupplierRepository;

            var supplier = new Supplier
            {
                CountryID = 2,
                SupplierName = null
            };

            Action act = () => supplierRepository.Insert(supplier);

            Assert.Throws<SqlException>(act,
                "Inserting a supplier with a null supplier name should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataCountryID()
        {
            var supplierRepository = UnitOfWork.SupplierRepository;

            var supplier = new Supplier
            {
                CountryID = -1,
                SupplierName = $"Supplier{Random.Shared.Next(1000, 10000)}"
            };

            Action act = () => supplierRepository.Insert(supplier);

            Assert.Throws<SqlException>(act,
                "Inserting a supplier with an invalid country ID should throw a SQL exception.");
        }

        [Test]
        public void GetAllTest_ShouldReturnList()
        {
            var supplierRepository = UnitOfWork.SupplierRepository;

            var suppliers = supplierRepository.GetAll();

            Assert.That(suppliers, Is.Not.Null, "GetAll should not return null.");
        }

        [Test]
        public void GetByIdTest_ShouldThrowOnInvalidId()
        {
            var supplierRepository = UnitOfWork.SupplierRepository;

            Action act = () => supplierRepository.GetById(-1);

            Assert.Throws<SqlException>(act, "Getting supplier with invalid ID should throw.");
        }

        [Test]
        public void UpdateTest_ShouldUpdateCorrectData()
        {
            var supplierRepository = UnitOfWork.SupplierRepository;

            var inserted = supplierRepository.GetById(UpdateTestId);

            inserted.SupplierName = "After update";
            supplierRepository.Update(inserted);

            var updated = supplierRepository.GetById(UpdateTestId);

            Assert.That(updated.SupplierName, Is.EqualTo("After update"), "Supplier name should be updated.");
        }

        [Test]
        public void DeleteTest_ShouldDeleteCorrectData()
        {
            var supplierRepository = UnitOfWork.SupplierRepository;

            supplierRepository.Delete(DeleteTestId);

            Action act = () => supplierRepository.GetById(DeleteTestId);

            Assert.Throws<SqlException>(act, "Getting a deleted supplier should throw.");
        }
    }
}
