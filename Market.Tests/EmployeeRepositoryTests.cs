using Market.DTO;
using Market.Repositories;
using Microsoft.Data.SqlClient;
using NUnit.Framework;

namespace Market.Tests
{
    [TestFixture]
    public class EmployeeRepositoryTests : BaseRepositoryTests
    {
        [Test]
        public void InsertTest_ShouldInsertCorrectData()
        {
            var employeeRepository = UnitOfWork.EmployeeRepository;

            var employee = new Employee
            {
                EmployeeRoleID = 3,
                FirstName = $"First{Random.Shared.Next(1000, 10000)}",
                LastName = $"Last{Random.Shared.Next(1000, 10000)}"
            };

            var id = employeeRepository.Insert(employee);
            var insertedEmployee = employeeRepository.GetById(id);

            Assert.That(id, Is.GreaterThan(0), "The inserted employee ID should be greater than 0.");
            Assert.That(insertedEmployee, Is.Not.Null, "The inserted employee should not be null.");
            Assert.That(insertedEmployee.EmployeeRoleID, Is.EqualTo(employee.EmployeeRoleID), "The employee role ID should match the inserted value.");
            Assert.That(insertedEmployee.FirstName, Is.EqualTo(employee.FirstName), "The first name should match the inserted value.");
            Assert.That(insertedEmployee.LastName, Is.EqualTo(employee.LastName), "The last name should match the inserted value.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataEmployeeRoleID()
        {
            var employeeRepository = UnitOfWork.EmployeeRepository;

            var employee = new Employee
            {
                EmployeeRoleID = -1,
                FirstName = $"First{Random.Shared.Next(1000, 10000)}",
                LastName = $"Last{Random.Shared.Next(1000, 10000)}"
            };

            Action act = () => employeeRepository.Insert(employee);

            Assert.Throws<SqlException>(act,
                "Inserting an employee with an invalid employee role ID should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataFirstName()
        {
            var employeeRepository = UnitOfWork.EmployeeRepository;

            var employee = new Employee
            {
                EmployeeRoleID = 3,
                FirstName = null,
                LastName = $"Last{Random.Shared.Next(1000, 10000)}"
            };

            Action act = () => employeeRepository.Insert(employee);

            Assert.Throws<SqlException>(act,
                "Inserting an employee with a null first name should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataLastName()
        {
            var employeeRepository = UnitOfWork.EmployeeRepository;

            var employee = new Employee
            {
                EmployeeRoleID = 3,
                FirstName = $"First{Random.Shared.Next(1000, 10000)}",
                LastName = null
            };

            Action act = () => employeeRepository.Insert(employee);

            Assert.Throws<SqlException>(act,
                "Inserting an employee with a null last name should throw a SQL exception.");
        }

        [Test]
        public void GetAllTest_ShouldReturnList()
        {
            var employeeRepository = UnitOfWork.EmployeeRepository;

            var employees = employeeRepository.GetAll();

            Assert.That(employees, Is.Not.Null, "GetAll should not return null.");
        }

        [Test]
        public void GetByIdTest_ShouldThrowOnInvalidId()
        {
            var employeeRepository = UnitOfWork.EmployeeRepository;

            Action act = () => employeeRepository.GetById(-1);

            Assert.Throws<SqlException>(act, "Getting employee with invalid ID should throw.");
        }

        [Test]
        public void UpdateTest_ShouldUpdateCorrectData()
        {
            var employeeRepository = UnitOfWork.EmployeeRepository;

            var inserted = employeeRepository.GetById(UpdateTestId);

            inserted.EmployeeRoleID = 3;
            inserted.FirstName = "After update";
            inserted.LastName = "Updated LastName";

            employeeRepository.Update(inserted);

            var updated = employeeRepository.GetById(UpdateTestId);

            Assert.That(updated.EmployeeRoleID, Is.EqualTo(3), "Employee role ID should be updated.");
            Assert.That(updated.FirstName, Is.EqualTo("After update"), "First name should be updated.");
            Assert.That(updated.LastName, Is.EqualTo("Updated LastName"), "Last name should be updated.");
        }

        [Test]
        public void DeleteTest_ShouldDeleteCorrectData()
        {
            var employeeRepository = UnitOfWork.EmployeeRepository;

            employeeRepository.Delete(DeleteTestId);

            Action act = () => employeeRepository.GetById(DeleteTestId);

            Assert.Throws<SqlException>(act, "Getting a deleted employee should throw.");
        }
    }
}