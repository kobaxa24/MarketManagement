using Market.DTO;
using Market.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyModel;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Tests
{
    [TestFixture]
    public class AttributeRepositoryTests : BaseRepositoryTests
    {

        [Test]
        public void InsertTest_ShouldInsertCorrectData()
        {
            var attributeRepository = UnitOfWork.AttributeRepository;
            var attribute = new DTO.Attribute
            {
                AttributeName = $"Attribute{Random.Shared.Next(1000, 10000)}",
                AttributeType = 1
            };

            var id = attributeRepository.Insert(attribute);
            var insertedAttribute = attributeRepository.GetById(id);

            Assert.That(id, Is.GreaterThan(0), "The inserted attribute ID should be greater than 0.");
            Assert.That(insertedAttribute, Is.Not.Null, "The inserted attribute should not be null.");
            Assert.That(insertedAttribute.AttributeName, Is.EqualTo(attribute.AttributeName), "The attribute name should match the inserted value.");
            Assert.That(insertedAttribute.AttributeType, Is.EqualTo(attribute.AttributeType), "The attribute type should match the inserted value.");
            Assert.That(insertedAttribute.AttributeType, Is.InRange(1, 4), "The attribute type should be between 1 and 4.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataName()
        {
            var attributeRepository = UnitOfWork.AttributeRepository;
            var attribute = new DTO.Attribute
            {
                AttributeName = null,
                AttributeType = 1
            };

            Action act = () => attributeRepository.Insert(attribute);

            Assert.Throws<SqlException>(act,
                "Inserting a attribute with a null attribute name should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataType()
        {
            var attributeRepository = UnitOfWork.AttributeRepository;
            var attribute = new DTO.Attribute
            {
                AttributeName = $"Attribute{Random.Shared.Next(1000, 10000)}",
                AttributeType = 6
            };

            Action act = () => attributeRepository.Insert(attribute);

            Assert.Throws<SqlException>(act,
                "Inserting a attribute with a type numbered more than four should throw a SQL exception.");
        }

        [Test]
        public void GetAllTest_ShouldReturnList()
        {
            var attributeRepository = UnitOfWork.AttributeRepository;
            var attributes = attributeRepository.GetAll();

            Assert.That(attributes, Is.Not.Null, "GetAll should not return null.");
        }

        [Test]
        public void GetByIdTest_ShouldThrowOnInvalidId()
        {
            var attributeRepository = UnitOfWork.AttributeRepository;

            Action act = () => attributeRepository.GetById(-1);

            Assert.Throws<SqlException>(act, "Getting attribute with invalid ID should throw.");
        }

        [Test]
        public void UpdateTest_ShouldUpdateCorrectData()
        {
            var attributeRepository = UnitOfWork.AttributeRepository;           
            var inserted = attributeRepository.GetById(UpdateTestId);

            inserted.AttributeName = "After update";
            attributeRepository.Update(inserted);
            var updated = attributeRepository.GetById(UpdateTestId);

            Assert.That(updated.AttributeName, Is.EqualTo("After update"), "Attribute name should be updated.");
        }

        [Test]
        public void DeleteTest_ShouldDeleteCorrectData()
        {
            var attributeRepository = UnitOfWork.AttributeRepository;
  
            attributeRepository.Delete(DeleteTestId);
            Action act = () => attributeRepository.GetById(DeleteTestId);

            Assert.Throws<SqlException>(act, "Getting a deleted attribute should throw.");
        }
    }
}
