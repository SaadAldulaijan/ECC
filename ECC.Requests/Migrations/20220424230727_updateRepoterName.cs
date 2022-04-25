using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECC.Requests.Migrations
{
    public partial class updateRepoterName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReporterByName",
                schema: "Requests",
                table: "EmergencyCodeRequests",
                newName: "ReporterName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReporterName",
                schema: "Requests",
                table: "EmergencyCodeRequests",
                newName: "ReporterByName");
        }
    }
}
