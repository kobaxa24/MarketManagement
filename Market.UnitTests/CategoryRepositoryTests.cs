//using Market.DTO;
//using Market.Repositories;
//using Microsoft.Data.SqlClient;

//namespace Market.Tests;

//[TestFixture]
//public class CategoryRepositoryTests
//{
//    private const string ConnectionString = "Server=.;Database=G08_Market_Test;Integrated security = true;Trustservercertificate = true;";

//    [Test]
//    public void InsertTest_ShouldInsertCorrectData()
//    {
//        // Arrange
//        var connection = new SqlConnection(ConnectionString);
//        var categoryRepository = new CategoryRepository(connection);
//        var category = new Category
//        {
//            CategoryName = $"Category{Random.Shared.Next(1000, 10000)}",
//            Description = "This is a test category."
//        };

//        // Act
//        int id = categoryRepository.Insert(category);
//        var insertedCategory = categoryRepository.GetById(id);

//        // Assert
//        Assert.That(id, Is.GreaterThan(0), "The inserted category ID should be greater than 0.");
//        Assert.That(insertedCategory, Is.Not.Null, "The inserted category should not be null.");
//        Assert.That(insertedCategory.CategoryName, Is.EqualTo(category.CategoryName), "The category name should match the inserted value.");
//        Assert.That(insertedCategory.Description, Is.EqualTo(category.Description), "The category description should match the inserted value.");
//    }

//    [Test]
//    public void InsertTest_ShouldNotInsertWrongData()
//    {
//        // Arrange
//        var connection = new SqlConnection(ConnectionString);
//        var categoryRepository = new CategoryRepository(connection);
//        var category = new Category
//        {
//            CategoryName = null,
//            Description = "This is a test category."
//        };

//        // Act and Assert
//        Assert.Throws<SqlException>(() => categoryRepository.Insert(category), "Inserting a category with a null name should throw a SqlException.");
//    }
//}