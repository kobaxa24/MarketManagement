using Market.DTO;
using Market.Repositories;
using Microsoft.Data.SqlClient;
using NUnit.Framework;

namespace Market.Tests
{
    [TestFixture]
    public class ProductAttributeValueRepositoryTests : BaseRepositoryTests
    {
        [Test]
        public void InsertTest_ShouldInsertCorrectData()
        {
            var productAttributeValueRepository = UnitOfWork.ProductAttributeValueRepository;

            var productAttributeValue = new ProductAttributeValue
            {
                ProductID = 7,
                AttributeID = 3,
                TextValue = "Test value",
                NumberValue = 25.50m,
                DateValue = new DateTime(2026, 1, 1),
                BooleanValue = true
            };

            var id =productAttributeValueRepository.Insert(productAttributeValue);

            var insertedProductAttributeValue =
            productAttributeValueRepository.GetById(
            (productAttributeValue.ProductID, productAttributeValue.AttributeID));



            Assert.That(insertedProductAttributeValue, Is.Not.Null,
                "The inserted product attribute value should not be null.");
            Assert.That(insertedProductAttributeValue.ProductID,
                Is.EqualTo(productAttributeValue.ProductID),
                "The product ID should match the inserted value.");
            Assert.That(insertedProductAttributeValue.AttributeID,
                Is.EqualTo(productAttributeValue.AttributeID),
                "The attribute ID should match the inserted value.");
            Assert.That(insertedProductAttributeValue.TextValue,
                Is.EqualTo(productAttributeValue.TextValue),
                "The text value should match the inserted value.");
            Assert.That(insertedProductAttributeValue.NumberValue,
                Is.EqualTo(productAttributeValue.NumberValue),
                "The number value should match the inserted value.");
            Assert.That(insertedProductAttributeValue.DateValue,
                Is.EqualTo(productAttributeValue.DateValue),
                "The date value should match the inserted value.");
            Assert.That(insertedProductAttributeValue.BooleanValue,
                Is.EqualTo(productAttributeValue.BooleanValue),
                "The boolean value should match the inserted value.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataProductID()
        {
            var productAttributeValueRepository = UnitOfWork.ProductAttributeValueRepository;

            var productAttributeValue = new ProductAttributeValue
            {
                ProductID = -1,
                AttributeID = 3,
                TextValue = "Test value"
            };

            Action act = () => productAttributeValueRepository.Insert(productAttributeValue);

            Assert.Throws<SqlException>(act,
                "Inserting a product attribute value with an invalid product ID should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataAttributeID()
        {
            var productAttributeValueRepository = UnitOfWork.ProductAttributeValueRepository;

            var productAttributeValue = new ProductAttributeValue
            {
                ProductID = 3,
                AttributeID = -1,
                TextValue = "Test value"
            };

            Action act = () => productAttributeValueRepository.Insert(productAttributeValue);

            Assert.Throws<SqlException>(act,
                "Inserting a product attribute value with an invalid attribute ID should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertDuplicateProductAttribute()
        {
            var productAttributeValueRepository = UnitOfWork.ProductAttributeValueRepository;

            var productAttributeValue = new ProductAttributeValue
            {
                ProductID = 5,
                AttributeID = 3,
                TextValue = "Test value"
            };

            productAttributeValueRepository.Insert(productAttributeValue);

            Action act = () => productAttributeValueRepository.Insert(productAttributeValue);

            Assert.Throws<SqlException>(act,
                "Inserting a duplicate product and attribute combination should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldAllowNullValues()
        {
            var productAttributeValueRepository = UnitOfWork.ProductAttributeValueRepository;

            var productAttributeValue = new ProductAttributeValue
            {
                ProductID = 3,
                AttributeID = 4,
                TextValue = null,
                NumberValue = null,
                DateValue = null,
                BooleanValue = null
            };
            Action act = () => productAttributeValueRepository.Insert(productAttributeValue);

            Assert.DoesNotThrow(act, "should allow all the null values");

        }

        [Test]
        public void GetAllTest_ShouldReturnList()
        {
            var productAttributeValueRepository = UnitOfWork.ProductAttributeValueRepository;

            var productAttributeValues = productAttributeValueRepository.GetAll();

            Assert.That(productAttributeValues, Is.Not.Null,
                "GetAll should not return null.");
        }
        [Test]
        public void GetByIdTest_ShouldReturnCorrectData()
        {
            var productAttributeValueRepository = UnitOfWork.ProductAttributeValueRepository;

            var result = productAttributeValueRepository.GetById((7, 10));

            Assert.That(result, Is.Not.Null,
                "The product attribute value should not be null.");

            Assert.That(result.ProductID,
                Is.EqualTo(7),
                "The product ID should match.");

            Assert.That(result.AttributeID,
                Is.EqualTo(10),
                "The attribute ID should match.");

            Assert.That(result.TextValue,
                Is.EqualTo("USA"),
                "The text value should match.");

            Assert.That(result.NumberValue,
                Is.Null,
                "The number value should be null.");

            Assert.That(result.DateValue,
                Is.Null,
                "The date value should be null.");

            Assert.That(result.BooleanValue,
                Is.Null,
                "The boolean value should be null.");
        }
    }
}