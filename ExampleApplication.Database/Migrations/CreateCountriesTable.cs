namespace ExampleApplication.Database.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Create countries table.
    /// </summary>
    [Migration(201602062124)]
    public class CreateCountriesTable : Migration
    {
        /// <summary>
        /// The up script.
        /// </summary>
        public override void Up()
        {
            Execute.EmbeddedScript(@"CreateCountriesTable.sql");
        }

        /// <summary>
        /// The down script.
        /// </summary>
        public override void Down()
        {
        }
    }
}