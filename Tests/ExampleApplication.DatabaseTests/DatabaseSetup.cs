namespace ExampleApplication.DatabaseTests
{
    using ExampleApplication.Data.Entities;
    using ExampleApplication.DatabaseTests.Migrations;
    using ExampleApplication.Utilities;

    using NUnit.Framework;

    /// <summary>
    /// The base class for unit-testing.
    /// </summary>
    [TestFixture]
    public abstract class DatabaseSetup
    {
        protected static string Connection => $"Name={Constants.ConnectionStringName}";

        [OneTimeSetUp]
        public void Setup()
        {
            DropAllTables();

            var connectionString = AppSettings.ProvideConnectionString(Constants.ConnectionStringName);

            Runner.MigrateToLatest(connectionString);
        }

        private static void DropAllTables()
        {
            using (var db = new ExampleContext(Connection))
            {
                const string DropConstraints = @"exec sp_MSforeachtable ""declare @name nvarchar(max); set @name = parsename('?', 1); exec sp_MSdropconstraints @name""";
                db.Database.ExecuteSqlCommand(DropConstraints);
                const string DropTables = @"exec sp_MSforeachtable ""drop table ?"";";
                db.Database.ExecuteSqlCommand(DropTables);
            }
        }
    }
}