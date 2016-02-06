using FluentMigrator;

namespace ExampleApplication.Database.Migrations
{
    [Migration(201602062124)]
    public class CreateCountriesTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript(@"CreateCountriesTable.sql");
        }

        public override void Down()
        {
        }
    }
}