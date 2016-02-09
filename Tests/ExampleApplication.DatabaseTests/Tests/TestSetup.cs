namespace ExampleApplication.DatabaseTests.Tests
{
    using Data.Entities;

    using ExampleApplication.DatabaseTests.Migrations;
    using ExampleApplication.Utilities;

    using NUnit.Framework;

    /// <summary>
    /// The base class for unit-testing.
    /// </summary>
    [TestFixture]
    public abstract class TestSetup
    {
        [OneTimeSetUp]
        public void DatabaseSetup()
        {
            DropAllTables();

            var connectionString = AppSettings.ProvideConnectionString(Constants.ConnectionStringName);

            Runner.MigrateToLatest(connectionString);
        }

        private static void DropAllTables()
        {
            string connection = $"Name={Constants.ConnectionStringName}";
            using (var db = new ExampleContext(connection))
            {
                var sql1 = @"exec sp_MSforeachtable ""declare @name nvarchar(max); set @name = parsename('?', 1); exec sp_MSdropconstraints @name""";
                db.Database.ExecuteSqlCommand(sql1);
                var sql2 = @"exec sp_MSforeachtable ""drop table ?"";";
                db.Database.ExecuteSqlCommand(sql2);
            }
        }
    }
}