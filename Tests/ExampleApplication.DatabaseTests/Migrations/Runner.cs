namespace ExampleApplication.DatabaseTests.Migrations
{
    using System.Reflection;

    using Database.Migrations;

    using FluentMigrator;
    using FluentMigrator.Runner;
    using FluentMigrator.Runner.Announcers;
    using FluentMigrator.Runner.Initialization;

    /// <summary>
    /// The migrations runner.
    /// </summary>
    public static class Runner
    {
        /// <summary>
        /// Migrate the database to the latest version.
        /// </summary>
        /// <param name="connectionStringName">The name of the connection string.</param>
        public static void MigrateToLatest(string connectionStringName)
        {
            var announcer = new NullAnnouncer();
            var assembly = Assembly.GetAssembly(typeof(CreateCountriesTable));

            var migrationContext = new RunnerContext(announcer)
            {
                Namespace = "ExampleApplication.Database.Migrations"
            };

            var options = new MigrationOptions { PreviewOnly = false, Timeout = 60 };
            var factory = new FluentMigrator.Runner.Processors.SqlServer.SqlServer2014ProcessorFactory();
            using (var processor = factory.Create(connectionStringName, announcer, options))
            {
                var runner = new MigrationRunner(assembly, migrationContext, processor);
                runner.MigrateUp(true);
            }
        }

        /// <summary>
        /// The migration options.
        /// </summary>
        private class MigrationOptions : IMigrationProcessorOptions
        {
            /// <summary>
            /// Gets or sets a value indicating whether to preview only.
            /// </summary>
            public bool PreviewOnly { get; set; }

            /// <summary>
            /// Gets the provider switches.
            /// </summary>
            public string ProviderSwitches => null;

            /// <summary>
            /// Gets or sets the timeout.
            /// </summary>
            public int Timeout { get; set; }
        }
    }
}