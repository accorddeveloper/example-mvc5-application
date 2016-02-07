namespace ExampleApplication.Database.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Create radio stations table.
    /// </summary>
    [Migration(201602062139)]
    public class CreateRadioStationsTable : Migration
    {
        /// <summary>
        /// The up script.
        /// </summary>
        public override void Up()
        {
            Execute.EmbeddedScript(@"CreateRadioStationsTable.sql");
        }

        /// <summary>
        /// The down script.
        /// </summary>
        public override void Down()
        {
        }
    }
}