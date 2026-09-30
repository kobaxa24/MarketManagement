using Market.DTO;
using Microsoft.Data.SqlClient;

namespace Market.Tests;

[TestFixture]
public class CategoryRepositoryTests : BaseRepositoryTests
{
    [Test]
    public void InsertTest_ShouldInsertCorrectData()
    {
        var categoryRepository = UnitOfWork.CategoryRepository;
        var category = new Category
        {
            CategoryName = $"Category{Random.Shared.Next(1000, 10000)}",
            Description = "This is a test category."
        };

        var id = categoryRepository.Insert(category);
        var insertedCategory = categoryRepository.GetById(id);

        Assert.That(id, Is.GreaterThan(0), "The inserted category ID should be greater than 0.");
        Assert.That(insertedCategory, Is.Not.Null, "The inserted category should not be null.");
        Assert.That(insertedCategory.CategoryName, Is.EqualTo(category.CategoryName), "The category name should match the inserted value.");
        Assert.That(insertedCategory.Description, Is.EqualTo(category.Description), "The category description should match the inserted value.");
    }

    [Test]
    public void InsertTest_ShouldNotInsertWrongData()
    {
        var categoryRepository = UnitOfWork.CategoryRepository;
        var category = new Category
        {
            CategoryName = null,
            Description = "categoria"
        };

        Action act = () => categoryRepository.Insert(category);

        Assert.Throws<SqlException>(act,
            "Inserting a category with a null category name should throw a SQL exception.");
    }

    [Test]
    public void GetAllTest_ShouldReturnList()
    {
        var categoryRepository = UnitOfWork.CategoryRepository;
        var categories = categoryRepository.GetAll();

        Assert.That(categories, Is.Not.Empty, "GetAll should return a non-empty list.");
    }

    [Test]
    public void GetByIdTest_ShouldThrowOnInvalidId()
    {
        var categoryRepository = UnitOfWork.CategoryRepository;

        Action act = () => categoryRepository.GetById(-1);

        Assert.Throws<SqlException>(act, "Getting category with invalid ID should throw.");
    }

    [Test]
    public void UpdateTest_ShouldUpdateCorrectData()
    {
        var categoryRepository = UnitOfWork.CategoryRepository;

        var existing = categoryRepository.GetById(UpdateTestId);

        existing!.Description = "After update";
        categoryRepository.Update(existing);
        var updated = categoryRepository.GetById(UpdateTestId);

        Assert.That(updated!.Description, Is.EqualTo(existing.Description), "Description should be updated.");
    }

    [Test]
    public void DeleteTest_ShouldDeleteCorrectData()
    {
        var categoryRepository = UnitOfWork.CategoryRepository;
       
        categoryRepository.Delete(DeleteTestId);
        Action act = () => categoryRepository.GetById(DeleteTestId);

        Assert.Throws<SqlException>(act, "Getting a deleted category should throw.");
    }
}