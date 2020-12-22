using Microsoft.EntityFrameworkCore.Migrations;

namespace BestPaws.Data.Migrations
{
    public partial class DoctorAndOwnerFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_ApplicationUserId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_ApplicationUserId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Pets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Pets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_ApplicationUserId",
                table: "Pets",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_ApplicationUserId",
                table: "Pets",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
