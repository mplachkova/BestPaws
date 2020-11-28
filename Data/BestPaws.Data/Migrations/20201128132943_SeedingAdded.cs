namespace BestPaws.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class SeedingAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureLocation",
                table: "Doctors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureLocation",
                table: "Doctors");
        }
    }
}
