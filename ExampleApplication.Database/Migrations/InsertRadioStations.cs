namespace ExampleApplication.Database.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Inserts radio stations.
    /// </summary>
    [Migration(201602072207)]
    public class InsertRadioStations : Migration
    {
        /// <summary>
        /// The up script.
        /// </summary>
        public override void Up()
        {
            Execute.EmbeddedScript(@"InsertRadioStations.sql");
        }

        /// <summary>
        /// The down script.
        /// </summary>
        public override void Down()
        {
        }
    }
}