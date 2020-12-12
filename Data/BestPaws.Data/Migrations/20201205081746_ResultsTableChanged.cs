namespace BestPaws.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ResultsTableChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Units",
                table: "TestResults",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Units",
                table: "TestResults");
        }
    }
}
