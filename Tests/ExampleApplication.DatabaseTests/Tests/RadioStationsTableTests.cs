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
    public class DatabaseTests : TestSetup
    {
        protected string Connection => $"Name={Constants.ConnectionStringName}";

        /// <summary>
        /// Test GetAll RadioStations.
        /// </summary>
        [Test]
        public void TestGetAllRadioStations()
        {
            string connection = $"Name={Constants.ConnectionStringName}";
            using (var db = new ExampleContext(Connection))
            {
                IRadioStationsRepository repository = new RadioStationsRepository(db);
                var radioStations = repository.GetAll();
                Assert.That(radioStations.Count(), Is.EqualTo(3));
            }
        }
    }
}