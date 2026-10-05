using Market.DTO;
using Market.Repositories;
using Microsoft.Data.SqlClient;
using NUnit.Framework;

namespace Market.Tests
{
    [TestFixture]
    public class EmployeeRoleRepositoryTests : BaseRepositoryTests
    {
        [Test]
        public void InsertTest_ShouldInsertCorrectData()
        {
            var employeeRoleRepository = UnitOfWork.EmployeeRoleRepository;

            var employeeRole = new EmployeeRole
            {
                RoleName = $"Role{Random.Shared.Next(1000, 10000)}"
            };

            var id = employeeRoleRepository.Insert(employeeRole);
            var insertedEmployeeRole = employeeRoleRepository.GetById(id);

            Assert.That(id, Is.GreaterThan(0), "The inserted employee role ID should be greater than 0.");
            Assert.That(insertedEmployeeRole, Is.Not.Null, "The inserted employee role should not be null.");
            Assert.That(insertedEmployeeRole.RoleName, Is.EqualTo(employeeRole.RoleName), "The role name should match the inserted value.");
        }

        [Test]
        public void InsertTest_ShouldInsertNullRoleName()
        {
            var employeeRoleRepository = UnitOfWork.EmployeeRoleRepository;

            var employeeRole = new EmployeeRole
            {
                RoleName = null
            };

            var id = employeeRoleRepository.Insert(employeeRole);
            var insertedEmployeeRole = employeeRoleRepository.GetById(id);

            Assert.That(id, Is.GreaterThan(0), "The inserted employee role ID should be greater than 0.");
            Assert.That(insertedEmployeeRole, Is.Not.Null, "The inserted employee role should not be null.");
            Assert.That(insertedEmployeeRole.RoleName, Is.Null, "The role name should be null.");
        }

        [Test]
        public void GetAllTest_ShouldReturnList()
        {
            var employeeRoleRepository = UnitOfWork.EmployeeRoleRepository;

            var employeeRoles = employeeRoleRepository.GetAll();

            Assert.That(employeeRoles, Is.Not.Null, "GetAll should not return null.");
        }

        [Test]
        public void GetByIdTest_ShouldThrowOnInvalidId()
        {
            var employeeRoleRepository = UnitOfWork.EmployeeRoleRepository;

            Action act = () => employeeRoleRepository.GetById(-1);

            Assert.Throws<SqlException>(act, "Getting employee role with invalid ID should throw.");
        }

        [Test]
        public void UpdateTest_ShouldUpdateCorrectData()
        {
            var employeeRoleRepository = UnitOfWork.EmployeeRoleRepository;

            var inserted = employeeRoleRepository.GetById(UpdateTestId);

            inserted.RoleName = "After update";

            employeeRoleRepository.Update(inserted);

            var updated = employeeRoleRepository.GetById(UpdateTestId);

            Assert.That(updated.RoleName, Is.EqualTo("After update"), "Role name should be updated.");
        }

        [Test]
        public void DeleteTest_ShouldDeleteCorrectData()
        {
            var employeeRoleRepository = UnitOfWork.EmployeeRoleRepository;

            employeeRoleRepository.Delete(DeleteTestId);

            Action act = () => employeeRoleRepository.GetById(DeleteTestId);

            Assert.Throws<SqlException>(act, "Getting a deleted employee role should throw.");
        }
    }
}