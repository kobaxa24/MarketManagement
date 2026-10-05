using Market.DTO;
using Market.Repositories;
using Microsoft.Data.SqlClient;
using NUnit.Framework;

namespace Market.Tests
{
    [TestFixture]
    public class UserAccountRepositoryTests : BaseRepositoryTests
    {
        [Test]
        public void InsertTest_ShouldInsertCorrectData()
        {
            var userAccountRepository = UnitOfWork.UserAccountRepository;

            var userAccount = new UserAccount
            {
                EmployeeID = 11,
                Username = $"User{Random.Shared.Next(1000, 10000)}",
                PasswordHash = new byte[] { 1, 2, 3, 4, 5 }
            };

            userAccountRepository.Insert(userAccount);

            var insertedUserAccount =
                userAccountRepository.GetById(userAccount.EmployeeID);

            Assert.That(insertedUserAccount, Is.Not.Null,
                "The inserted user account should not be null.");
            Assert.That(insertedUserAccount.EmployeeID,
                Is.EqualTo(userAccount.EmployeeID),
                "The employee ID should match the inserted value.");
            Assert.That(insertedUserAccount.Username,
                Is.EqualTo(userAccount.Username),
                "The username should match the inserted value.");
            Assert.That(insertedUserAccount.PasswordHash,
                Is.EqualTo(userAccount.PasswordHash),
                "The password hash should match the inserted value.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertNullUsername()
        {
            var userAccountRepository = UnitOfWork.UserAccountRepository;

            var userAccount = new UserAccount
            {
                EmployeeID = 4,
                Username = null,
                PasswordHash = new byte[] { 1, 2, 3, 4, 5 }
            };

            Action act = () => userAccountRepository.Insert(userAccount);

            Assert.Throws<SqlException>(act,
                "Inserting a user account with a null username should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertEmptyUsername()
        {
            var userAccountRepository = UnitOfWork.UserAccountRepository;

            var userAccount = new UserAccount
            {
                EmployeeID = 4,
                Username = "",
                PasswordHash = new byte[] { 1, 2, 3, 4, 5 }
            };

            Action act = () => userAccountRepository.Insert(userAccount);

            Assert.Throws<SqlException>(act,
                "Inserting a user account with an empty username should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWhitespaceUsername()
        {
            var userAccountRepository = UnitOfWork.UserAccountRepository;

            var userAccount = new UserAccount
            {
                EmployeeID = 4,
                Username = "   ",
                PasswordHash = new byte[] { 1, 2, 3, 4, 5 }
            };

            Action act = () => userAccountRepository.Insert(userAccount);

            Assert.Throws<SqlException>(act,
                "Inserting a user account with a whitespace username should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataEmployeeID()
        {
            var userAccountRepository = UnitOfWork.UserAccountRepository;

            var userAccount = new UserAccount
            {
                EmployeeID = -1,
                Username = $"User{Random.Shared.Next(1000, 10000)}",
                PasswordHash = new byte[] { 1, 2, 3, 4, 5 }
            };

            Action act = () => userAccountRepository.Insert(userAccount);

            Assert.Throws<SqlException>(act,
                "Inserting a user account with an invalid employee ID should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertDuplicateUsername()
        {
            var userAccountRepository = UnitOfWork.UserAccountRepository;

            var username = $"User{Random.Shared.Next(1000, 10000)}";

            var firstUserAccount = new UserAccount
            {
                EmployeeID = 12,
                Username = username,
                PasswordHash = new byte[] { 1, 2, 3, 4, 5 }
            };

            userAccountRepository.Insert(firstUserAccount);

            var secondUserAccount = new UserAccount
            {
                EmployeeID = 13,
                Username = username,
                PasswordHash = new byte[] { 6, 7, 8, 9, 10 }
            };

            Action act = () => userAccountRepository.Insert(secondUserAccount);

            Assert.Throws<SqlException>(act,
                "Inserting a user account with an existing username should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertSecondAccountForEmployee()
        {
            var userAccountRepository = UnitOfWork.UserAccountRepository;

            var firstUserAccount = new UserAccount
            {
                EmployeeID = 14,
                Username = $"User{Random.Shared.Next(1000, 10000)}",
                PasswordHash = new byte[] { 1, 2, 3, 4, 5 }
            };

            userAccountRepository.Insert(firstUserAccount);

            var secondUserAccount = new UserAccount
            {
                EmployeeID = 14,
                Username = $"User{Random.Shared.Next(1000, 10000)}",
                PasswordHash = new byte[] { 6, 7, 8, 9, 10 }
            };

            Action act = () => userAccountRepository.Insert(secondUserAccount);

            Assert.Throws<SqlException>(act,
                "An employee should not have more than one user account.");
        }

        [Test]
        public void GetAllTest_ShouldReturnList()
        {
            var userAccountRepository = UnitOfWork.UserAccountRepository;

            var userAccounts = userAccountRepository.GetAll();

            Assert.That(userAccounts, Is.Not.Null,
                "GetAll should not return null.");
        }

        [Test]
        public void GetByIdTest_ShouldThrowOnInvalidId()
        {
            var userAccountRepository = UnitOfWork.UserAccountRepository;

            Action act = () => userAccountRepository.GetById(-1);

            Assert.Throws<SqlException>(act,
                "Getting user account with invalid employee ID should throw.");
        }
    }
}