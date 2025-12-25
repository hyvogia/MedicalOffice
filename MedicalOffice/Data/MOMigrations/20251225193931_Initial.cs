using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalOffice.Data.MOMigrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MO");

            migrationBuilder.CreateTable(
                name: "Doctors",
                schema: "MO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                schema: "MO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OHIP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpYrVisits = table.Column<byte>(type: "tinyint", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalSchema: "MO",
                        principalTable: "Doctors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DoctorID",
                schema: "MO",
                table: "Patients",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_OHIP",
                schema: "MO",
                table: "Patients",
                column: "OHIP",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients",
                schema: "MO");

            migrationBuilder.DropTable(
                name: "Doctors",
                schema: "MO");
        }
    }
}
