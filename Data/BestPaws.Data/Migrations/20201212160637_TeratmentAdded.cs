using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BestPaws.Data.Migrations
{
    public partial class TeratmentAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PetsTreatments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    PetId = table.Column<int>(nullable: false),
                    TreatmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetsTreatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetsTreatments_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PetsTreatments_Treatment_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetsTreatments_IsDeleted",
                table: "PetsTreatments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PetsTreatments_PetId",
                table: "PetsTreatments",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_PetsTreatments_TreatmentId",
                table: "PetsTreatments",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_IsDeleted",
                table: "Treatment",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetsTreatments");

            migrationBuilder.DropTable(
                name: "Treatment");
        }
    }
}
