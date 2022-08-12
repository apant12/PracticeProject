using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleApi.Migrations
{
    public partial class LatandLongnamefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lat",
                table: "Projects",
                newName: "Lat");

            migrationBuilder.RenameColumn(
                name: "lng",
                table: "Projects",
                newName: "Long");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lat",
                table: "Projects",
                newName: "lat");

            migrationBuilder.RenameColumn(
                name: "Long",
                table: "Projects",
                newName: "lng");
        }
    }
}
