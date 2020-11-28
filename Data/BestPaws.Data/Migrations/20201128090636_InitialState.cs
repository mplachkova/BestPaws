using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BestPaws.Data.Migrations
{
    public partial class InitialState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AnimalBreeds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalBreeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimalTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    Specialization = table.Column<string>(maxLength: 100, nullable: false),
                    Biography = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PetOwners",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetOwners_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    TypeName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Age = table.Column<byte>(nullable: false),
                    Gender = table.Column<string>(maxLength: 10, nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    AnimalTypeId = table.Column<int>(nullable: false),
                    AnimalBreedId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_AnimalBreeds_AnimalBreedId",
                        column: x => x.AnimalBreedId,
                        principalTable: "AnimalBreeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pets_AnimalTypes_AnimalTypeId",
                        column: x => x.AnimalTypeId,
                        principalTable: "AnimalTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pets_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReferenceValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    MinValue = table.Column<decimal>(nullable: false),
                    MaxValue = table.Column<decimal>(nullable: false),
                    AnimalTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenceValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferenceValues_AnimalTypes_AnimalTypeId",
                        column: x => x.AnimalTypeId,
                        principalTable: "AnimalTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diagnoses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    DoctorId = table.Column<string>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnoses_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    PetId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PetId = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    DoctorId = table.Column<string>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    TestTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tests_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tests_TestType_TestTypeId",
                        column: x => x.TestTypeId,
                        principalTable: "TestType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    ReferenceValueId = table.Column<int>(nullable: false),
                    RefValueId = table.Column<int>(nullable: false),
                    TestTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestResults_ReferenceValues_ReferenceValueId",
                        column: x => x.ReferenceValueId,
                        principalTable: "ReferenceValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestResults_TestType_TestTypeId",
                        column: x => x.TestTypeId,
                        principalTable: "TestType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PetsDiagnoses",
                columns: table => new
                {
                    PetId = table.Column<int>(nullable: false),
                    DiagnosisId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetsDiagnoses", x => new { x.PetId, x.DiagnosisId });
                    table.ForeignKey(
                        name: "FK_PetsDiagnoses_Diagnoses_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnoses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PetsDiagnoses_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicamentsPrescriptions",
                columns: table => new
                {
                    MedicamentId = table.Column<int>(nullable: false),
                    PrescriptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentsPrescriptions", x => new { x.MedicamentId, x.PrescriptionId });
                    table.ForeignKey(
                        name: "FK_MedicamentsPrescriptions_Medicaments_MedicamentId",
                        column: x => x.MedicamentId,
                        principalTable: "Medicaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicamentsPrescriptions_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalBreeds_IsDeleted",
                table: "AnimalBreeds",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalTypes_IsDeleted",
                table: "AnimalTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_DoctorId",
                table: "Diagnoses",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_IsDeleted",
                table: "Diagnoses",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ApplicationUserId",
                table: "Doctors",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_IsDeleted",
                table: "Doctors",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Medicaments_IsDeleted",
                table: "Medicaments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentsPrescriptions_PrescriptionId",
                table: "MedicamentsPrescriptions",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_PetOwners_ApplicationUserId",
                table: "PetOwners",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PetOwners_IsDeleted",
                table: "PetOwners",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_AnimalBreedId",
                table: "Pets",
                column: "AnimalBreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_AnimalTypeId",
                table: "Pets",
                column: "AnimalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_ApplicationUserId",
                table: "Pets",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_IsDeleted",
                table: "Pets",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PetsDiagnoses_DiagnosisId",
                table: "PetsDiagnoses",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorId",
                table: "Prescriptions",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IsDeleted",
                table: "Prescriptions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PetId",
                table: "Prescriptions",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenceValues_AnimalTypeId",
                table: "ReferenceValues",
                column: "AnimalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenceValues_IsDeleted",
                table: "ReferenceValues",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_IsDeleted",
                table: "TestResults",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_ReferenceValueId",
                table: "TestResults",
                column: "ReferenceValueId");

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_TestTypeId",
                table: "TestResults",
                column: "TestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_DoctorId",
                table: "Tests",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_IsDeleted",
                table: "Tests",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_PetId",
                table: "Tests",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_TestTypeId",
                table: "Tests",
                column: "TestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TestType_IsDeleted",
                table: "TestType",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicamentsPrescriptions");

            migrationBuilder.DropTable(
                name: "PetOwners");

            migrationBuilder.DropTable(
                name: "PetsDiagnoses");

            migrationBuilder.DropTable(
                name: "TestResults");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Medicaments");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Diagnoses");

            migrationBuilder.DropTable(
                name: "ReferenceValues");

            migrationBuilder.DropTable(
                name: "TestType");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "AnimalBreeds");

            migrationBuilder.DropTable(
                name: "AnimalTypes");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "AspNetUsers");
        }
    }
}
