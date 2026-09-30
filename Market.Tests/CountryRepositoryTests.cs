using Market.DTO;
using Microsoft.Data.SqlClient;

namespace Market.Tests
{
    [TestFixture]
    public class CountryRepositoryTests : BaseRepositoryTests
    {
        [Test]
        public void InsertTest_ShouldInsertCorrectData()
        {
            var countryRepository = UnitOfWork.CountryRepository;
            var country = new Country
            {
                CountryName = $"Country{Random.Shared.Next(1000, 10000)}"
            };

            var id = countryRepository.Insert(country);
            var insertedCountry = countryRepository.GetById(id);

            Assert.That(id, Is.GreaterThan(0), "The inserted country ID should be greater than 0.");
            Assert.That(insertedCountry, Is.Not.Null, "The inserted country should not be null.");
            Assert.That(insertedCountry.CountryName, Is.EqualTo(country.CountryName), "The country name should match the inserted value.");
        }

        [Test]
        public void InsertTest_ShouldNotInsertWrongDataName()
        {
            var countryRepository = UnitOfWork.CountryRepository;
            var country = new Country
            {
                CountryName = null
            };

            Action act = () => countryRepository.Insert(country);

            Assert.Throws<SqlException>(act,
                "Inserting a country with a null country name should throw a SQL exception.");
        }

        [Test]
        public void GetAllTest_ShouldReturnList()
        {
            var countryRepository = UnitOfWork.CountryRepository;
            var countries = countryRepository.GetAll();

            Assert.That(countries, Is.Not.Null, "GetAll should not return null.");
        }

        [Test]
        public void GetByIdTest_ShouldThrowOnInvalidId()
        {
            var countryRepository = UnitOfWork.CountryRepository;

            Action act = () => countryRepository.GetById(-1);

            Assert.Throws<SqlException>(act, "Getting country with invalid ID should throw.");
        }

        [Test]
        public void UpdateTest_ShouldUpdateCorrectData()
        {
            var countryRepository = UnitOfWork.CountryRepository;
 
            var inserted = countryRepository.GetById(UpdateTestId);

            inserted.CountryName = "After update";
            countryRepository.Update(inserted);
            var updated = countryRepository.GetById(UpdateTestId);

            Assert.That(updated.CountryName, Is.EqualTo("After update"), "Country name should be updated.");
        }

        [Test]
        public void DeleteTest_ShouldDeleteCorrectData()
        {
            var countryRepository = UnitOfWork.CountryRepository;
 
            countryRepository.Delete(DeleteTestId);
            Action act = () => countryRepository.GetById(DeleteTestId);

            Assert.Throws<SqlException>(act, "Getting a deleted country should throw.");
        }
    }
}

