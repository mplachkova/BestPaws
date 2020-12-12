using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BestPaws.Data.Migrations
{
    public partial class DBContextChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_ReferenceValues_ReferenceValueId",
                table: "TestResults");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_TestType_TestTypeId",
                table: "TestResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestResults",
                table: "TestResults");

            migrationBuilder.DropIndex(
                name: "IX_TestResults_ReferenceValueId",
                table: "TestResults");

            migrationBuilder.DropIndex(
                name: "IX_TestResults_TestTypeId",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "TestType");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "RefValueId",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "ReferenceValueId",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "TestTypeId",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "Units",
                table: "TestResults");

            migrationBuilder.RenameTable(
                name: "TestResults",
                newName: "TestResult");

            migrationBuilder.RenameIndex(
                name: "IX_TestResults_IsDeleted",
                table: "TestResult",
                newName: "IX_TestResult_IsDeleted");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TestType",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestResultId",
                table: "Tests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Units",
                table: "ReferenceValues",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestResult",
                table: "TestResult",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TestIndicators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    Units = table.Column<string>(nullable: true),
                    ReferenceValueId = table.Column<int>(nullable: true),
                    RefValueId = table.Column<int>(nullable: false),
                    TestResultId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestIndicators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestIndicators_ReferenceValues_ReferenceValueId",
                        column: x => x.ReferenceValueId,
                        principalTable: "ReferenceValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestIndicators_TestResult_TestResultId",
                        column: x => x.TestResultId,
                        principalTable: "TestResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tests_TestResultId",
                table: "Tests",
                column: "TestResultId");

            migrationBuilder.CreateIndex(
                name: "IX_TestIndicators_IsDeleted",
                table: "TestIndicators",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TestIndicators_ReferenceValueId",
                table: "TestIndicators",
                column: "ReferenceValueId");

            migrationBuilder.CreateIndex(
                name: "IX_TestIndicators_TestResultId",
                table: "TestIndicators",
                column: "TestResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_TestResult_TestResultId",
                table: "Tests",
                column: "TestResultId",
                principalTable: "TestResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_TestResult_TestResultId",
                table: "Tests");

            migrationBuilder.DropTable(
                name: "TestIndicators");

            migrationBuilder.DropIndex(
                name: "IX_Tests_TestResultId",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestResult",
                table: "TestResult");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TestType");

            migrationBuilder.DropColumn(
                name: "TestResultId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Units",
                table: "ReferenceValues");

            migrationBuilder.RenameTable(
                name: "TestResult",
                newName: "TestResults");

            migrationBuilder.RenameIndex(
                name: "IX_TestResult_IsDeleted",
                table: "TestResults",
                newName: "IX_TestResults_IsDeleted");

            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "TestType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TestResults",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "TestResults",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "RefValueId",
                table: "TestResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReferenceValueId",
                table: "TestResults",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestTypeId",
                table: "TestResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Units",
                table: "TestResults",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestResults",
                table: "TestResults",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_ReferenceValueId",
                table: "TestResults",
                column: "ReferenceValueId");

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_TestTypeId",
                table: "TestResults",
                column: "TestTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_ReferenceValues_ReferenceValueId",
                table: "TestResults",
                column: "ReferenceValueId",
                principalTable: "ReferenceValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_TestType_TestTypeId",
                table: "TestResults",
                column: "TestTypeId",
                principalTable: "TestType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
