using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECC.Requests.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Requests");

            migrationBuilder.CreateTable(
                name: "Codes",
                schema: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasClear = table.Column<bool>(type: "bit", nullable: false),
                    HasPhases = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Codes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistories",
                schema: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                schema: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestType = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CallRequests",
                schema: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    OnSet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientMRN = table.Column<int>(type: "int", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CallRequests_Requests_Id",
                        column: x => x.Id,
                        principalSchema: "Requests",
                        principalTable: "Requests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmergencyCodeRequests",
                schema: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CodeId = table.Column<int>(type: "int", nullable: false),
                    ReporterByName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReporterExtension = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClearedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phase = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyCodeRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmergencyCodeRequests_Codes_CodeId",
                        column: x => x.CodeId,
                        principalSchema: "Requests",
                        principalTable: "Codes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmergencyCodeRequests_Requests_Id",
                        column: x => x.Id,
                        principalSchema: "Requests",
                        principalTable: "Requests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CallRequestMedicalHistories",
                schema: "Requests",
                columns: table => new
                {
                    CallRequestId = table.Column<int>(type: "int", nullable: false),
                    MedicalHistoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallRequestMedicalHistories", x => new { x.CallRequestId, x.MedicalHistoryId });
                    table.ForeignKey(
                        name: "FK_CallRequestMedicalHistories_CallRequests_CallRequestId",
                        column: x => x.CallRequestId,
                        principalSchema: "Requests",
                        principalTable: "CallRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallRequestMedicalHistories_MedicalHistories_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalSchema: "Requests",
                        principalTable: "MedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CallRequestMedicalHistories_MedicalHistoryId",
                schema: "Requests",
                table: "CallRequestMedicalHistories",
                column: "MedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyCodeRequests_CodeId",
                schema: "Requests",
                table: "EmergencyCodeRequests",
                column: "CodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallRequestMedicalHistories",
                schema: "Requests");

            migrationBuilder.DropTable(
                name: "EmergencyCodeRequests",
                schema: "Requests");

            migrationBuilder.DropTable(
                name: "CallRequests",
                schema: "Requests");

            migrationBuilder.DropTable(
                name: "MedicalHistories",
                schema: "Requests");

            migrationBuilder.DropTable(
                name: "Codes",
                schema: "Requests");

            migrationBuilder.DropTable(
                name: "Requests",
                schema: "Requests");
        }
    }
}
