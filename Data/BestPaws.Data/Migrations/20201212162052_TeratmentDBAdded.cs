using Microsoft.EntityFrameworkCore.Migrations;

namespace BestPaws.Data.Migrations
{
    public partial class TeratmentDBAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetsTreatments_Treatment_TreatmentId",
                table: "PetsTreatments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Treatment",
                table: "Treatment");

            migrationBuilder.RenameTable(
                name: "Treatment",
                newName: "Treatments");

            migrationBuilder.RenameIndex(
                name: "IX_Treatment_IsDeleted",
                table: "Treatments",
                newName: "IX_Treatments_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Treatments",
                table: "Treatments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetsTreatments_Treatments_TreatmentId",
                table: "PetsTreatments",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetsTreatments_Treatments_TreatmentId",
                table: "PetsTreatments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Treatments",
                table: "Treatments");

            migrationBuilder.RenameTable(
                name: "Treatments",
                newName: "Treatment");

            migrationBuilder.RenameIndex(
                name: "IX_Treatments_IsDeleted",
                table: "Treatment",
                newName: "IX_Treatment_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Treatment",
                table: "Treatment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetsTreatments_Treatment_TreatmentId",
                table: "PetsTreatments",
                column: "TreatmentId",
                principalTable: "Treatment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
