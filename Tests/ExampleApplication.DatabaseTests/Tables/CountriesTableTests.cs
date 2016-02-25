namespace ExampleApplication.DatabaseTests.Tables
{
    using System.Linq;

    using ExampleApplication.Data.Entities;
    using ExampleApplication.Data.Repositories;

    using NUnit.Framework;

    /// <summary>
    /// The database tests.
    /// </summary>
    public class CountriesTableTests : DatabaseSetup
    {
        /// <summary>
        /// Test GetAll Countries.
        /// </summary>
        [Test]
        public void GetAllCountries()
        {
            using (var db = new ExampleContext(Connection))
            {
                ICountriesRepository repository = new CountriesRepository(db);
                var countries = repository.GetAll();
                Assert.That(countries.Count(), Is.EqualTo(3));
            }
        }
    }
}