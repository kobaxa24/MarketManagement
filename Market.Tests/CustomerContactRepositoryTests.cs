using Market.DTO;
using Market.Repositories;
using Microsoft.Data.SqlClient;
using NUnit.Framework;

namespace Market.Tests
{
    [TestFixture]
    public class CustomerContactRepositoryTests : BaseRepositoryTests
    {
        [Test]
        public void InsertTest_ShouldInsertCorrectData()
        {
            var customerContactRepository = UnitOfWork.CustomerContactRepository;

            var customerContact = new CustomerContact
            {
                CustomerEmail = $"test{Random.Shared.Next(1000, 10000)}@email.com",
                CustomerID = 3,
                ContactType = 1,
                ContactValue = "555123456"
            };

            var id = customerContactRepository.Insert(customerContact);
            var insertedCustomerContact = customerContactRepository.GetById(id);

            Assert.That(id, Is.GreaterThan(0), "The inserted customer contact ID should be greater than 0.");
            Assert.That(insertedCustomerContact, Is.Not.Null, "The inserted customer contact should not be null.");
            Assert.That(insertedCustomerContact.CustomerEmail, Is.EqualTo(customerContact.CustomerEmail), "The customer email should match the inserted value.");
            Assert.That(insertedCustomerContact.CustomerID, Is.EqualTo(customerContact.CustomerID), "The customer ID should match the inserted value.");
            Assert.That(insertedCustomerContact.ContactType, Is.EqualTo(customerContact.ContactType), "The contact type should match the inserted value.");
            Assert.That(insertedCustomerContact.ContactValue, Is.EqualTo(customerContact.ContactValue), "The contact value should match the inserted value.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataCustomerEmail()
        {
            var customerContactRepository = UnitOfWork.CustomerContactRepository;

            var customerContact = new CustomerContact
            {
                CustomerEmail = null,
                CustomerID = 3,
                ContactType = 1,
                ContactValue = "555123456"
            };

            Action act = () => customerContactRepository.Insert(customerContact);

            Assert.Throws<SqlException>(act,
                "Inserting a customer contact with a null email should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataCustomerID()
        {
            var customerContactRepository = UnitOfWork.CustomerContactRepository;

            var customerContact = new CustomerContact
            {
                CustomerEmail = "test@email.com",
                CustomerID = -1,
                ContactType = 1,
                ContactValue = "555123456"
            };

            Action act = () => customerContactRepository.Insert(customerContact);

            Assert.Throws<SqlException>(act,
                "Inserting a customer contact with an invalid customer ID should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataContactType()
        {
            var customerContactRepository = UnitOfWork.CustomerContactRepository;

            var customerContact = new CustomerContact
            {
                CustomerEmail = "test@email.com",
                CustomerID = 3,
                ContactType = 3,
                ContactValue = "555123456"
            };

            Action act = () => customerContactRepository.Insert(customerContact);

            Assert.Throws<SqlException>(act,
                "Inserting a customer contact with an invalid contact type should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataContactValue()
        {
            var customerContactRepository = UnitOfWork.CustomerContactRepository;

            var customerContact = new CustomerContact
            {
                CustomerEmail = "test@email.com",
                CustomerID = 3,
                ContactType = 1,
                ContactValue = null
            };

            Action act = () => customerContactRepository.Insert(customerContact);

            Assert.Throws<SqlException>(act,
                "Inserting a customer contact with a null contact value should throw a SQL exception.");
        }

        [Test]
        public void GetAllTest_ShouldReturnList()
        {
            var customerContactRepository = UnitOfWork.CustomerContactRepository;

            var customerContacts = customerContactRepository.GetAll();

            Assert.That(customerContacts, Is.Not.Null, "GetAll should not return null.");
        }

        [Test]
        public void GetByIdTest_ShouldThrowOnInvalidId()
        {
            var customerContactRepository = UnitOfWork.CustomerContactRepository;

            Action act = () => customerContactRepository.GetById(-1);

            Assert.Throws<SqlException>(act, "Getting customer contact with invalid ID should throw.");
        }

        [Test]
        public void UpdateTest_ShouldUpdateCorrectData()
        {
            var customerContactRepository = UnitOfWork.CustomerContactRepository;

            var inserted = customerContactRepository.GetById(UpdateTestId);

            inserted.CustomerEmail = "updated@email.com";
            inserted.CustomerID = 3;
            inserted.ContactType = 2;
            inserted.ContactValue = "555987654";
            

            customerContactRepository.Update(inserted);

            var updated = customerContactRepository.GetById(UpdateTestId);

            Assert.That(updated.CustomerEmail, Is.EqualTo("updated@email.com"), "Customer email should be updated.");
            Assert.That(updated.CustomerID, Is.EqualTo(3), "Customer ID should be updated.");
            Assert.That(updated.ContactType, Is.EqualTo(2), "Contact type should be updated.");
            Assert.That(updated.ContactValue, Is.EqualTo("555987654"), "Contact value should be updated.");
        }
    }
}