using Market.DTO;
using Market.Repositories;
using Microsoft.Data.SqlClient;
using NUnit.Framework;

namespace Market.Tests
{
    [TestFixture]
    public class CustomerRepositoryTests : BaseRepositoryTests
    {
        [Test]
        public void InsertTest_ShouldInsertCorrectData()
        {
            var customerRepository = UnitOfWork.CustomerRepository;

            var customer = new Customer
            {
                FirstName = $"First{Random.Shared.Next(1000, 10000)}",
                LastName = $"Last{Random.Shared.Next(1000, 10000)}",
                CustomerLoyaltyPoints = 100
            };

            var id = customerRepository.Insert(customer);
            var insertedCustomer = customerRepository.GetById(id);

            Assert.That(id, Is.GreaterThan(0), "The inserted customer ID should be greater than 0.");
            Assert.That(insertedCustomer, Is.Not.Null, "The inserted customer should not be null.");
            Assert.That(insertedCustomer.FirstName, Is.EqualTo(customer.FirstName), "The first name should match the inserted value.");
            Assert.That(insertedCustomer.LastName, Is.EqualTo(customer.LastName), "The last name should match the inserted value.");
            Assert.That(insertedCustomer.CustomerLoyaltyPoints, Is.EqualTo(customer.CustomerLoyaltyPoints), "The loyalty points should match the inserted value.");
            Assert.That(insertedCustomer.CustomerLoyaltyPoints, Is.GreaterThanOrEqualTo(0), "The loyalty points should not be negative.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataFirstName()
        {
            var customerRepository = UnitOfWork.CustomerRepository;

            var customer = new Customer
            {
                FirstName = null,
                LastName = $"Last{Random.Shared.Next(1000, 10000)}",
                CustomerLoyaltyPoints = 100
            };

            Action act = () => customerRepository.Insert(customer);

            Assert.Throws<SqlException>(act,
                "Inserting a customer with a null first name should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataLastName()
        {
            var customerRepository = UnitOfWork.CustomerRepository;

            var customer = new Customer
            {
                FirstName = $"First{Random.Shared.Next(1000, 10000)}",
                LastName = null,
                CustomerLoyaltyPoints = 100
            };

            Action act = () => customerRepository.Insert(customer);

            Assert.Throws<SqlException>(act,
                "Inserting a customer with a null last name should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertNegativeLoyaltyPoints()
        {
            var customerRepository = UnitOfWork.CustomerRepository;

            var customer = new Customer
            {
                FirstName = $"First{Random.Shared.Next(1000, 10000)}",
                LastName = $"Last{Random.Shared.Next(1000, 10000)}",
                CustomerLoyaltyPoints = -10
            };

            Action act = () => customerRepository.Insert(customer);

            Assert.Throws<SqlException>(act,
                "Inserting a customer with negative loyalty points should throw a SQL exception.");
        }

        [Test]
        public void GetAllTest_ShouldReturnList()
        {
            var customerRepository = UnitOfWork.CustomerRepository;

            var customers = customerRepository.GetAll();

            Assert.That(customers, Is.Not.Null, "GetAll should not return null.");
        }

        [Test]
        public void GetByIdTest_ShouldThrowOnInvalidId()
        {
            var customerRepository = UnitOfWork.CustomerRepository;

            Action act = () => customerRepository.GetById(-1);

            Assert.Throws<SqlException>(act, "Getting customer with invalid ID should throw.");
        }

        [Test]
        public void UpdateTest_ShouldUpdateCorrectData()
        {
            var customerRepository = UnitOfWork.CustomerRepository;

            var inserted = customerRepository.GetById(UpdateTestId);

            inserted.FirstName = "After update";
            inserted.LastName = "Updated LastName";
            inserted.CustomerLoyaltyPoints = 500;

            customerRepository.Update(inserted);

            var updated = customerRepository.GetById(UpdateTestId);

            Assert.That(updated.FirstName, Is.EqualTo("After update"), "Customer first name should be updated.");
            Assert.That(updated.LastName, Is.EqualTo("Updated LastName"), "Customer last name should be updated.");
            Assert.That(updated.CustomerLoyaltyPoints, Is.EqualTo(500), "Customer loyalty points should be updated.");
        }
    }
}