using Market.DTO;
using Market.Repositories;
using Microsoft.Data.SqlClient;
using NUnit.Framework;

namespace Market.Tests
{
    [TestFixture]
    public class ProductRepositoryTests : BaseRepositoryTests
    {
        

        [Test]
        public void InsertTest_ShouldInsertCorrectData()
        {
            var productRepository = UnitOfWork.ProductRepository;

            var product = new Product
            {
                CategoryID = 3,
                SupplierID = 3,
                ProductName = $"Product{Random.Shared.Next(1000, 10000)}",
                Price = 25.50m
            };

            var id = productRepository.Insert(product);
            var insertedProduct = productRepository.GetById(id);

            Assert.That(id, Is.GreaterThan(0), "The inserted product ID should be greater than 0.");
            Assert.That(insertedProduct, Is.Not.Null, "The inserted product should not be null.");
            Assert.That(insertedProduct.CategoryID, Is.EqualTo(product.CategoryID), "The category ID should match the inserted value.");
            Assert.That(insertedProduct.SupplierID, Is.EqualTo(product.SupplierID), "The supplier ID should match the inserted value.");
            Assert.That(insertedProduct.ProductName, Is.EqualTo(product.ProductName), "The product name should match the inserted value.");
            Assert.That(insertedProduct.Price, Is.EqualTo(product.Price), "The price should match the inserted value.");
            Assert.That(insertedProduct.Price, Is.GreaterThan(0), "The price should not be negative.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataName()
        {
            var productRepository = UnitOfWork.ProductRepository;

            var product = new Product
            {
                CategoryID = 2,
                SupplierID = 2,
                ProductName = null,
                Price = 25.50m
            };

            Action act = () => productRepository.Insert(product);

            Assert.Throws<SqlException>(act,
                "Inserting a product with a null product name should throw a SQL exception.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertNegativePrice()
        {
            var productRepository = UnitOfWork.ProductRepository;

            var product = new Product
            {
                CategoryID = 2,
                SupplierID = 2,
                ProductName = $"Product{Random.Shared.Next(1000, 10000)}",
                Price = -10.00m
            };

            Action act = () => productRepository.Insert(product);

            Assert.Throws<SqlException>(act,
                "Inserting a product with a negative price should throw a SQL exception.");
        }

        [Test]
        public void GetAllTest_ShouldReturnList()
        {
            var productRepository = UnitOfWork.ProductRepository;

            var products = productRepository.GetAll();

            Assert.That(products, Is.Not.Null, "GetAll should not return null.");
        }

        [Test]
        public void GetByIdTest_ShouldThrowOnInvalidId()
        {
            var productRepository = UnitOfWork.ProductRepository;

            Action act = () => productRepository.GetById(-1);

            Assert.Throws<SqlException>(act, "Getting product with invalid ID should throw.");
        }

        [Test]
        public void UpdateTest_ShouldUpdateCorrectData()
        {
            var productRepository = UnitOfWork.ProductRepository;
            
            var inserted = productRepository.GetById(UpdateTestId);

            inserted.ProductName = "After update";
            inserted.Price = 50.75m;

            productRepository.Update(inserted);

            var updated = productRepository.GetById(UpdateTestId);

            Assert.That(updated.ProductName, Is.EqualTo("After update"), "Product name should be updated.");
            Assert.That(updated.Price, Is.EqualTo(50.75m), "Product price should be updated.");
        }

        [Test]
        public void DeleteTest_ShouldDeleteCorrectData()
        {
            var productRepository = UnitOfWork.ProductRepository;

            productRepository.Delete(DeleteTestId);

            Action act = () => productRepository.GetById(DeleteTestId);

            Assert.Throws<SqlException>(act, "Getting a deleted product should throw.");
        }
        [Test]
        public void GetProductsByCategoryTest_ShouldReturnProducts()
        {
            var productRepository = UnitOfWork.ProductRepository;

            var products = productRepository.GetProductsByCategory(4);

            Assert.That(products, Is.Not.Null, "GetProductsByCategory should not return null.");

        }
    }
}


