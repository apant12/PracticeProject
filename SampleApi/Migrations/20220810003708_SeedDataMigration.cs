using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleApi.Migrations
{
    public partial class SeedDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "IsActive", "Name" },
                values: new object[] { 1L, true, "Ayush" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "IsActive", "Name" },
                values: new object[] { 2L, true, "Nirakar" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "IsActive", "Name" },
                values: new object[] { 3L, true, "Bentdkesh" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 3L);
        }
    }
}
