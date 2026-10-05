using Market.DTO;
using Market.Repositories;
using Microsoft.Data.SqlClient;
using NUnit.Framework;

namespace Market.Tests
{
    [TestFixture]
    public class EmployeeContactRepositoryTests : BaseRepositoryTests
    {
        [Test]
        public void InsertTest_ShouldInsertCorrectData()
        {
            var employeeContactRepository = UnitOfWork.EmployeeContactsRepository;

            var employeeContact = new EmployeeContact
            {
                EmployeeID = 3,
                ContactType = 1,
                ContactValue = "555123456"
            };

            var id = employeeContactRepository.Insert(employeeContact);
            var insertedEmployeeContact = employeeContactRepository.GetById(id);

            Assert.That(id, Is.GreaterThan(0), "The inserted employee contact ID should be greater than 0.");
            Assert.That(insertedEmployeeContact, Is.Not.Null, "The inserted employee contact should not be null.");
            Assert.That(insertedEmployeeContact.EmployeeID, Is.EqualTo(employeeContact.EmployeeID), "The employee ID should match the inserted value.");
            Assert.That(insertedEmployeeContact.ContactType, Is.EqualTo(employeeContact.ContactType), "The contact type should match the inserted value.");
            Assert.That(insertedEmployeeContact.ContactValue, Is.EqualTo(employeeContact.ContactValue), "The contact value should match the inserted value.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataEmployeeID()
        {
            var employeeContactRepository = UnitOfWork.EmployeeContactsRepository;

            var employeeContact = new EmployeeContact
            {
                EmployeeID = -1,
                ContactType = 1,
                ContactValue = "555123456"
            };

            Action act = () => employeeContactRepository.Insert(employeeContact);

            Assert.Throws<SqlException>(act,
                "Inserting an employee contact with an invalid employee ID should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataContactType()
        {
            var employeeContactRepository = UnitOfWork.EmployeeContactsRepository;

            var employeeContact = new EmployeeContact
            {
                EmployeeID = 3,
                ContactType = 3,
                ContactValue = "555123456"
            };

            Action act = () => employeeContactRepository.Insert(employeeContact);

            Assert.Throws<SqlException>(act,
                "Inserting an employee contact with an invalid contact type should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataContactValue()
        {
            var employeeContactRepository = UnitOfWork.EmployeeContactsRepository;

            var employeeContact = new EmployeeContact
            {
                EmployeeID = 3,
                ContactType = 1,
                ContactValue = null
            };

            Action act = () => employeeContactRepository.Insert(employeeContact);

            Assert.Throws<SqlException>(act,
                "Inserting an employee contact with a null contact value should throw a SQL exception.");
        }

        [Test]
        public void GetAllTest_ShouldReturnList()
        {
            var employeeContactRepository = UnitOfWork.EmployeeContactsRepository;

            var employeeContacts = employeeContactRepository.GetAll();

            Assert.That(employeeContacts, Is.Not.Null, "GetAll should not return null.");
        }

        [Test]
        public void GetByIdTest_ShouldThrowOnInvalidId()
        {
            var employeeContactRepository = UnitOfWork.EmployeeContactsRepository;

            Action act = () => employeeContactRepository.GetById(-1);

            Assert.Throws<SqlException>(act, "Getting employee contact with invalid ID should throw.");
        }

        [Test]
        public void UpdateTest_ShouldUpdateCorrectData()
        {
            var employeeContactRepository = UnitOfWork.EmployeeContactsRepository;

            var inserted = employeeContactRepository.GetById(UpdateTestId);

            inserted.EmployeeID = 3;
            inserted.ContactType = 2;
            inserted.ContactValue = "555987654";

            employeeContactRepository.Update(inserted);

            var updated = employeeContactRepository.GetById(UpdateTestId);

            Assert.That(updated.EmployeeID, Is.EqualTo(3), "Employee ID should be updated.");
            Assert.That(updated.ContactType, Is.EqualTo(2), "Contact type should be updated.");
            Assert.That(updated.ContactValue, Is.EqualTo("555987654"), "Contact value should be updated.");
        }

        [Test]
        public void DeleteTest_ShouldDeleteCorrectData()
        {
            var employeeContactRepository = UnitOfWork.EmployeeContactsRepository;

            employeeContactRepository.Delete(DeleteTestId);

            Action act = () => employeeContactRepository.GetById(DeleteTestId);

            Assert.Throws<SqlException>(act, "Getting a deleted employee contact should throw.");
        }
    }
}