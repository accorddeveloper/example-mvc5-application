using FluentMigrator;

namespace ExampleApplication.Database.Migrations
{
    [Migration(201602062139)]
    public class CreateRadioStationsTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript(@"CreateRadioStationsTable.sql");
        }

        public override void Down()
        {
        }
    }
}