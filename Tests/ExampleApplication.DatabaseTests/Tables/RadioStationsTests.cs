namespace ExampleApplication.DatabaseTests.Tables
{
    using System.Linq;

    using ExampleApplication.Data.Entities;
    using ExampleApplication.Data.Repositories;

    using NUnit.Framework;

    /// <summary>
    /// The database tests.
    /// </summary>
    public class RadioStationsTests : TestSetup
    {
        /// <summary>
        /// Test GetAll RadioStations.
        /// </summary>
        [Test]
        public void TestGetAllRadioStations()
        {
            using (var db = new ExampleContext(this.Connection))
            {
                IRadioStationsRepository repository = new RadioStationsRepository(db);
                var radioStations = repository.GetAll();
                Assert.That(radioStations.Count(), Is.EqualTo(3));
            }
        }
    }
}