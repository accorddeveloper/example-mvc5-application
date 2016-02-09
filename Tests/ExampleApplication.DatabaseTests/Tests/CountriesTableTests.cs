namespace ExampleApplication.DatabaseTests.Tests
{
    using System.Linq;

    using ExampleApplication.Data.Entities;
    using ExampleApplication.Data.Repositories;
    using ExampleApplication.DatabaseTests.Migrations;

    using NUnit.Framework;

    /// <summary>
    /// The database tests.
    /// </summary>
    public class CountriesTableTests : TestSetup
    {
        protected string Connection => $"Name={Constants.ConnectionStringName}";

        /// <summary>
        /// Test GetAll Countries.
        /// </summary>
        [Test]
        public void TestGetAllCountries()
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